using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public partial class FormReservas : Form
    {
        private bool isAdmin;
        private string usuarioLogadoId;
        private bool filtroAtivo = false;

        public FormReservas()
        {
            InitializeComponent();
            isAdmin = FormLogin.IsAdmin;
            usuarioLogadoId = FormLogin.UsuarioId.ToString();

            ConfigurarColunasDataGridView();
            ConfigurarFiltros();
            CarregarReservas();
        }

        private void FormReservas_Load(object sender, EventArgs e)
        {
            ConfigurarPermissoes();
            cmbFiltroStatus.SelectedIndex = 0;
        }

        private void ConfigurarColunasDataGridView()
        {
            dgvReservas.Columns.Clear();

            dgvReservas.Columns.Add("Id", "ID");
            dgvReservas.Columns.Add("Cliente", "CLIENTE");
            dgvReservas.Columns.Add("Email", "E-MAIL");
            dgvReservas.Columns.Add("Computador", "COMPUTADOR");
            dgvReservas.Columns.Add("Data", "DATA");
            dgvReservas.Columns.Add("Horario", "HORÁRIO");
            dgvReservas.Columns.Add("Status", "STATUS");
            dgvReservas.Columns.Add("Valor", "VALOR");
            dgvReservas.Columns.Add("UsuarioCriador", "CRIADO POR");

            dgvReservas.Columns["UsuarioCriador"].Visible = false;

            foreach (DataGridViewColumn coluna in dgvReservas.Columns)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Larguras específicas
            dgvReservas.Columns["Id"].Width = 120;
            dgvReservas.Columns["Data"].Width = 100;
            dgvReservas.Columns["Status"].Width = 140;
            dgvReservas.Columns["Valor"].Width = 100;
        }

        private void ConfigurarFiltros()
        {
            // Configurar ComboBox de status
            cmbFiltroStatus.Items.Clear();
            cmbFiltroStatus.Items.AddRange(new object[] {
                "📋 Todas",
                "● CONFIRMADA",
                "🟡 PENDENTE",
                "✅ CONCLUÍDA",
                "❌ CANCELADA"
            });
            cmbFiltroStatus.SelectedIndex = 0;

            // Configurar DateTimePicker
            dtpFiltroData.Value = DateTime.Now;
        }

        private void ConfigurarPermissoes()
        {
            if (!isAdmin)
            {
                btnRelatorio.Visible = false;
                btnApagarReserva.Visible = false;
            }
        }

        private void CarregarReservas()
        {
            try
            {
                dgvReservas.Rows.Clear();

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            r.Id, r.ClienteNome, r.ClienteEmail,
                            c.Nome as ComputadorNome,
                            r.DataReserva, r.HoraInicio, r.HoraFim,
                            r.Status, r.ValorTotal,
                            r.UsuarioId as UsuarioCriador
                        FROM Reservas r
                        JOIN Computadores c ON r.ComputadorId = c.Id
                        WHERE 1=1";

                    // Aplicar filtro de status
                    if (cmbFiltroStatus.SelectedIndex > 0)
                    {
                        string statusFiltro = cmbFiltroStatus.Text.Replace("🟡 ", "")
                                                                    .Replace("✅ ", "")
                                                                    .Replace("❌ ", "")
                                                                    .Replace("● ", "");
                        query += " AND r.Status LIKE @Status";
                    }

                    // Aplicar filtro de data (se checkbox ativado)
                    if (filtroAtivo)
                    {
                        query += " AND r.DataReserva = @Data";
                    }

                    // Ordenação
                    query += " ORDER BY r.DataReserva DESC, r.HoraInicio DESC";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        if (cmbFiltroStatus.SelectedIndex > 0)
                        {
                            string statusFiltro = cmbFiltroStatus.Text.Replace("🟡 ", "")
                                                                        .Replace("✅ ", "")
                                                                        .Replace("❌ ", "")
                                                                        .Replace("● ", "")
                                                                        .Replace("📋 ", "");
                            cmd.Parameters.AddWithValue("@Status", $"%{statusFiltro}%");
                        }

                        if (filtroAtivo)
                        {
                            cmd.Parameters.AddWithValue("@Data", dtpFiltroData.Value.Date);
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvReservas.Rows.Add(
                                    reader["Id"].ToString(),
                                    reader["ClienteNome"].ToString(),
                                    reader["ClienteEmail"].ToString(),
                                    reader["ComputadorNome"].ToString(),
                                    Convert.ToDateTime(reader["DataReserva"]).ToString("dd/MM/yyyy"),
                                    $"{reader["HoraInicio"]} - {reader["HoraFim"]}",
                                    reader["Status"].ToString(),
                                    $"R$ {Convert.ToDecimal(reader["ValorTotal"]):F2}",
                                    reader["UsuarioCriador"].ToString()
                                );
                            }
                        }
                    }
                }

                AplicarCoresStatus();
                VerificarPermissoesBotoes();
                AtualizarEstatisticas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar reservas:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarCoresStatus()
        {
            foreach (DataGridViewRow row in dgvReservas.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    Color cor = Color.Black;

                    if (status.Contains("CONFIRMADA")) cor = Color.Green;
                    else if (status.Contains("PENDENTE")) cor = Color.Orange;
                    else if (status.Contains("CANCELADA")) cor = Color.Red;
                    else if (status.Contains("CONCLUÍDA")) cor = Color.Blue;

                    row.Cells["Status"].Style.ForeColor = cor;
                    row.Cells["Status"].Style.Font = new Font(dgvReservas.Font, FontStyle.Bold);
                }
            }
        }

        private void VerificarPermissoesBotoes()
        {
            btnEditarReserva.Enabled = false;
            btnCancelarReserva.Enabled = false;
            btnConcluirReserva.Enabled = false;
            btnApagarReserva.Enabled = false;

            if (dgvReservas.CurrentRow == null) return;

            string status = dgvReservas.CurrentRow.Cells["Status"].Value.ToString();
            string usuarioCriador = dgvReservas.CurrentRow.Cells["UsuarioCriador"].Value.ToString();

            bool podeEditar = isAdmin || (usuarioCriador == usuarioLogadoId);
            bool podeCancelar = isAdmin || (usuarioCriador == usuarioLogadoId);
            bool podeConcluir = isAdmin;
            bool podeApagar = isAdmin;

            btnEditarReserva.Enabled = podeEditar &&
                                     !status.Contains("CONCLUÍDA") &&
                                     !status.Contains("CANCELADA");

            btnCancelarReserva.Enabled = podeCancelar &&
                                       !status.Contains("CONCLUÍDA") &&
                                       !status.Contains("CANCELADA");

            btnConcluirReserva.Enabled = podeConcluir &&
                                       !status.Contains("CONCLUÍDA") &&
                                       !status.Contains("CANCELADA");

            btnApagarReserva.Enabled = podeApagar;

            AtualizarTextosBotoes(podeEditar, podeCancelar, podeConcluir);
        }

        private void AtualizarTextosBotoes(bool podeEditar, bool podeCancelar, bool podeConcluir)
        {
            btnEditarReserva.Text = (isAdmin || podeEditar) ? "✏️ EDITAR" : "👁️ VISUALIZAR";
            btnCancelarReserva.Text = "❌ CANCELAR";
            btnConcluirReserva.Text = "✅ CONCLUIR";
            btnApagarReserva.Text = "🗑️ APAGAR";

            if (!podeEditar && !isAdmin)
            {
                btnEditarReserva.BackColor = Color.Gray;
                btnEditarReserva.ForeColor = Color.White;
            }
            else
            {
                btnEditarReserva.BackColor = Color.FromArgb(255, 193, 7);
                btnEditarReserva.ForeColor = Color.Black;
            }

            if (!podeCancelar && !isAdmin)
            {
                btnCancelarReserva.BackColor = Color.Gray;
                btnCancelarReserva.Enabled = false;
            }
            else
            {
                btnCancelarReserva.BackColor = Color.FromArgb(220, 53, 69);
            }
        }

        private void AtualizarEstatisticas()
        {
            int total = dgvReservas.Rows.Count;

            // Calcular estatísticas
            decimal valorTotal = 0;
            int confirmadas = 0;
            int canceladas = 0;
            int concluidas = 0;

            foreach (DataGridViewRow row in dgvReservas.Rows)
            {
                string status = row.Cells["Status"].Value.ToString();

                if (status.Contains("CONFIRMADA")) confirmadas++;
                if (status.Contains("CANCELADA")) canceladas++;
                if (status.Contains("CONCLUÍDA")) concluidas++;

                // Somar apenas reservas não canceladas
                if (!status.Contains("CANCELADA"))
                {
                    string valorStr = row.Cells["Valor"].Value.ToString()
                                         .Replace("R$ ", "")
                                         .Replace(",", ".");
                    if (decimal.TryParse(valorStr, out decimal valor))
                        valorTotal += valor;
                }
            }

            lblTitulo.Text = $"📅 GERENCIAR RESERVAS ({total} encontrada{(total != 1 ? "s" : "")} | " +
                           $"Confirmadas: {confirmadas} | Concluídas: {concluidas} | Canceladas: {canceladas} | " +
                           $"Total: R$ {valorTotal:F2})";
        }

        // EVENTOS DE BOTÕES
        private void btnNovaReserva_Click(object sender, EventArgs e)
        {
            using (var form = new FormNovaReserva())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CarregarReservas();
                    MessageBox.Show("✅ Reserva criada com sucesso!", "Sucesso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma reserva para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reservaId = dgvReservas.CurrentRow.Cells["Id"].Value.ToString();
            string status = dgvReservas.CurrentRow.Cells["Status"].Value.ToString();
            string usuarioCriador = dgvReservas.CurrentRow.Cells["UsuarioCriador"].Value.ToString();

            if (usuarioCriador != usuarioLogadoId && !isAdmin)
            {
                MessageBox.Show("❌ Você só pode editar suas próprias reservas.",
                    "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (status.Contains("CONCLUÍDA") || status.Contains("CANCELADA"))
            {
                MessageBox.Show("❌ Não é possível editar reservas concluídas ou canceladas.",
                    "Operação Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new FormEditarReserva(reservaId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CarregarReservas();
                    MessageBox.Show("✅ Reserva atualizada com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnConcluirReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma reserva para concluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem concluir reservas.",
                    "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reservaId = dgvReservas.CurrentRow.Cells["Id"].Value.ToString();
            string cliente = dgvReservas.CurrentRow.Cells["Cliente"].Value.ToString();
            string status = dgvReservas.CurrentRow.Cells["Status"].Value.ToString();

            if (status.Contains("CONCLUÍDA"))
            {
                MessageBox.Show("ℹ️ Esta reserva já está concluída.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (status.Contains("CANCELADA"))
            {
                MessageBox.Show("❌ Não é possível concluir uma reserva cancelada.",
                    "Operação Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Confirmar conclusão da reserva?\n\nCliente: {cliente}\nReserva: {reservaId}",
                "Concluir Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE Reservas SET Status = '✅ CONCLUÍDA' WHERE Id = @Id";

                        using (var cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", reservaId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    CarregarReservas();
                    MessageBox.Show("✅ Reserva concluída com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao concluir reserva:\n{ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma reserva para cancelar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reservaId = dgvReservas.CurrentRow.Cells["Id"].Value.ToString();
            string cliente = dgvReservas.CurrentRow.Cells["Cliente"].Value.ToString();
            string status = dgvReservas.CurrentRow.Cells["Status"].Value.ToString();
            string usuarioCriador = dgvReservas.CurrentRow.Cells["UsuarioCriador"].Value.ToString();

            if (usuarioCriador != usuarioLogadoId && !isAdmin)
            {
                MessageBox.Show("❌ Você só pode cancelar suas próprias reservas.",
                    "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (status.Contains("CANCELADA"))
            {
                MessageBox.Show("ℹ️ Esta reserva já está cancelada.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (status.Contains("CONCLUÍDA"))
            {
                MessageBox.Show("❌ Não é possível cancelar uma reserva já concluída.",
                    "Operação Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialogResult = MessageBox.Show(
                $"Confirmar cancelamento da reserva?\n\nCliente: {cliente}\nReserva: {reservaId}",
                "Cancelar Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE Reservas SET Status = '❌ CANCELADA', ValorTotal = 0 WHERE Id = @Id";

                        using (var cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", reservaId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    CarregarReservas();
                    MessageBox.Show("✅ Reserva cancelada com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cancelar reserva:\n{ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnApagarReserva_Click_1(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma reserva para apagar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem apagar reservas.",
                    "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reservaId = dgvReservas.CurrentRow.Cells["Id"].Value.ToString();
            string cliente = dgvReservas.CurrentRow.Cells["Cliente"].Value.ToString();

            var resultado = MessageBox.Show(
                $"🚨 ATENÇÃO! Você está prestes a APAGAR PERMANENTEMENTE esta reserva:\n\n" +
                $"Cliente: {cliente}\nReserva: {reservaId}\n\n" +
                $"Esta ação NÃO PODE ser desfeita!\nTem certeza?",
                "CONFIRMAR EXCLUSÃO PERMANENTE",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();

                        // Apaga de UsoComputadores primeiro (se existir)
                        try
                        {
                            string queryDeleteUso = "DELETE FROM UsoComputadores WHERE ReservaId = @ReservaId";
                            using (var cmdUso = new SqlCommand(queryDeleteUso, connection))
                            {
                                cmdUso.Parameters.AddWithValue("@ReservaId", reservaId);
                                cmdUso.ExecuteNonQuery();
                            }
                        }
                        catch { }

                        // Apaga da tabela Reservas
                        string queryDeleteReserva = "DELETE FROM Reservas WHERE Id = @Id";
                        using (var cmd = new SqlCommand(queryDeleteReserva, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", reservaId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("✅ Reserva apagada permanentemente!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CarregarReservas();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao apagar reserva:\n{ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem acessar relatórios.",
                    "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var form = new FormRelatorios();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir relatórios:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarReservas();
            MessageBox.Show("✅ Lista de reservas atualizada!", "Sucesso",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // EVENTOS DE FILTROS
        private void cmbFiltroStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarReservas();
        }

        private void dtpFiltroData_ValueChanged(object sender, EventArgs e)
        {
            if (filtroAtivo)
                CarregarReservas();
        }

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            cmbFiltroStatus.SelectedIndex = 0;
            dtpFiltroData.Value = DateTime.Now;
            filtroAtivo = false;
            CarregarReservas();
        }

        // EVENTOS DO DATAGRID
        private void dgvReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEditarReserva_Click(sender, e);
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            VerificarPermissoesBotoes();
        }
    }
}