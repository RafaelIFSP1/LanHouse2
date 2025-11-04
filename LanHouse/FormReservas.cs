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

        public FormReservas()
        {
            InitializeComponent();
            isAdmin = FormLogin.IsAdmin;

            // CONVERTE int PARA string
            usuarioLogadoId = FormLogin.UsuarioId.ToString();

            ConfigurarColunasDataGridView();
            CarregarReservas();
        }

        private void FormReservas_Load(object sender, EventArgs e)
        {
            ConfigurarPermissoes();
        }

        private void ConfigurarColunasDataGridView()
        {
            // Limpa colunas existentes
            dgvReservas.Columns.Clear();

            // Adiciona colunas manualmente
            dgvReservas.Columns.Add("Id", "ID");
            dgvReservas.Columns.Add("Cliente", "CLIENTE");
            dgvReservas.Columns.Add("Email", "E-MAIL");
            dgvReservas.Columns.Add("Computador", "COMPUTADOR");
            dgvReservas.Columns.Add("Data", "DATA");
            dgvReservas.Columns.Add("Horario", "HORÁRIO");
            dgvReservas.Columns.Add("Status", "STATUS");
            dgvReservas.Columns.Add("Valor", "VALOR");
            dgvReservas.Columns.Add("UsuarioCriador", "CRIADO POR");

            // Oculta a coluna do usuário criador
            dgvReservas.Columns["UsuarioCriador"].Visible = false;

            // Configuração das colunas
            foreach (DataGridViewColumn coluna in dgvReservas.Columns)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
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

                    query += " ORDER BY r.DataReserva DESC, r.HoraInicio DESC";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        if (cmbFiltroStatus.SelectedIndex > 0)
                            cmd.Parameters.AddWithValue("@Status", cmbFiltroStatus.Text);

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
                AtualizarEstatisticas(dgvReservas.Rows.Count);
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
            // Inicialmente desabilita os botões
            btnEditarReserva.Enabled = false;
            btnCancelarReserva.Enabled = false;
            btnConcluirReserva.Enabled = false;
            btnApagarReserva.Enabled = false;

            // Se não há linha selecionada, mantém desabilitado
            if (dgvReservas.CurrentRow == null) return;

            string reservaId = dgvReservas.CurrentRow.Cells["Id"].Value.ToString();
            string status = dgvReservas.CurrentRow.Cells["Status"].Value.ToString();
            string usuarioCriador = dgvReservas.CurrentRow.Cells["UsuarioCriador"].Value.ToString();

            // ✅ ADMIN tem acesso total a todas as reservas
            // ✅ Usuário comum só tem acesso às próprias reservas
            bool podeEditar = isAdmin || (usuarioCriador == usuarioLogadoId);
            bool podeCancelar = isAdmin || (usuarioCriador == usuarioLogadoId);
            bool podeConcluir = isAdmin; // Apenas admin pode concluir reservas
            bool podeApagar = isAdmin;   // ← APENAS ADMIN pode apagar

            // Habilita/desabilita botões baseado nas permissões
            btnEditarReserva.Enabled = podeEditar &&
                                     !status.Contains("CONCLUÍDA") &&
                                     !status.Contains("CANCELADA");

            btnCancelarReserva.Enabled = podeCancelar &&
                                       !status.Contains("CONCLUÍDA") &&
                                       !status.Contains("CANCELADA");

            btnConcluirReserva.Enabled = podeConcluir &&
                                       !status.Contains("CONCLUÍDA") &&
                                       !status.Contains("CANCELADA");

            btnApagarReserva.Enabled = podeApagar; // ← SEMPRE que for admin

            // Atualiza os textos dos botões para mostrar permissões
            AtualizarTextosBotoes(podeEditar, podeCancelar, podeConcluir);
        }

        private void AtualizarTextosBotoes(bool podeEditar, bool podeCancelar, bool podeConcluir)
        {
            // ✅ Admin sempre vê "EDITAR", usuário comum vê "VISUALIZAR" quando não é dono
            btnEditarReserva.Text = (isAdmin || podeEditar) ? "✏️ EDITAR" : "👁️ VISUALIZAR";
            btnCancelarReserva.Text = "❌ CANCELAR";
            btnConcluirReserva.Text = "✅ CONCLUIR";
            btnApagarReserva.Text = "🗑️ APAGAR";

            // Muda cores para indicar permissões
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

        private void AtualizarEstatisticas(int total)
        {
            lblTitulo.Text = $"📅 GERENCIAR RESERVAS ({total} encontrada{(total != 1 ? "s" : "")})";
        }

        private void btnNovaReserva_Click(object sender, EventArgs e)
        {
            using (var form = new FormNovaReserva())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CarregarReservas();
                    MessageBox.Show("✅ Reserva criada com sucesso e lista atualizada!", "Sucesso",
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

            // Verifica permissão para editar
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

            // Apenas admin pode concluir reservas
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
            decimal valorReserva = 0;

            // Obter o valor da reserva antes de cancelar (para relatório)
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string queryValor = "SELECT ValorTotal FROM Reservas WHERE Id = @Id";
                    using (var cmd = new SqlCommand(queryValor, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", reservaId);
                        var valorResult = cmd.ExecuteScalar();
                        if (valorResult != null && valorResult != DBNull.Value)
                        {
                            valorReserva = Convert.ToDecimal(valorResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter valor da reserva: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica permissão para cancelar
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
                $"Confirmar cancelamento da reserva?\n\nCliente: {cliente}\nReserva: {reservaId}\nValor: R$ {valorReserva:F2}",
                "Cancelar Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();

                        // Atualiza o status para cancelada e zera o valor
                        string query = @"UPDATE Reservas 
               SET Status = '❌ CANCELADA', 
                   ValorTotal = 0
               WHERE Id = @Id";

                        using (var cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", reservaId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    CarregarReservas();
                    MessageBox.Show($"✅ Reserva cancelada com sucesso!\nValor removido do relatório: R$ {valorReserva:F2}",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cancelar reserva:\n{ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnApagarReserva_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botão APAGAR clicado!", "Debug",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma reserva para apagar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Apenas admin pode apagar reservas
            if (!isAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem apagar reservas.",
                    "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Admin confirmado - prosseguindo com exclusão...", "Debug",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Resto do código...
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
                var dt = DatabaseHelper.ObterRelatorioUso();

                string relatorio = "📊 RELATÓRIO DE USO - COMPUTADORES\n";
                relatorio += $"Data: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n";

                decimal receitaTotal = 0;
                decimal horasTotal = 0;
                int reservasTotal = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string nome = row["ComputadorNome"].ToString();
                    int reservas = Convert.ToInt32(row["TotalReservas"]);
                    decimal receita = Convert.ToDecimal(row["ReceitaTotal"]);
                    decimal horas = Convert.ToDecimal(row["TotalHorasUtilizadas"]);
                    decimal precoHora = Convert.ToDecimal(row["PrecoHora"]);

                    receitaTotal += receita;
                    horasTotal += horas;
                    reservasTotal += reservas;

                    relatorio += $"🖥️ {nome}\n";
                    relatorio += $"   📅 Reservas: {reservas}\n";
                    relatorio += $"   ⏱️ Horas: {horas:F1}h\n";
                    relatorio += $"   💰 Receita: R$ {receita:F2}\n";
                    relatorio += $"   💵 Preço/Hora: R$ {precoHora:F2}\n\n";
                }

                relatorio += "=" + new string('=', 40) + "\n";
                relatorio += $"📈 TOTAIS:\n";
                relatorio += $"   Reservas: {reservasTotal}\n";
                relatorio += $"   Horas: {horasTotal:F1}h\n";
                relatorio += $"   Receita: R$ {receitaTotal:F2}\n";

                if (horasTotal > 0)
                    relatorio += $"   Média/Hora: R$ {(receitaTotal / horasTotal):F2}";

                MessageBox.Show(relatorio, "Relatório de Uso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarReservas();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFiltroStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarReservas();
        }

        private void dtpFiltroData_ValueChanged(object sender, EventArgs e)
        {
            CarregarReservas();
        }

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            cmbFiltroStatus.SelectedIndex = 0;
            dtpFiltroData.Value = DateTime.Now;
            CarregarReservas();
        }

        private void dgvReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEditarReserva_Click(sender, e);
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            VerificarPermissoesBotoes();
        }

        private void btnApagarReserva_Click_1(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma reserva para apagar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Apenas admin pode apagar reservas
            if (!isAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem apagar reservas.",
                    "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reservaId = dgvReservas.CurrentRow.Cells["Id"].Value.ToString();
            string cliente = dgvReservas.CurrentRow.Cells["Cliente"].Value.ToString();
            string computador = dgvReservas.CurrentRow.Cells["Computador"].Value.ToString();
            string data = dgvReservas.CurrentRow.Cells["Data"].Value.ToString();
            string horario = dgvReservas.CurrentRow.Cells["Horario"].Value.ToString();

            // Confirmação EXTRA para apagar (ação irreversível)
            var resultado = MessageBox.Show(
                $"🚨🚨🚨 ATENÇÃO 🚨🚨🚨\n\n" +
                $"Você está prestes a APAGAR PERMANENTEMENTE esta reserva:\n\n" +
                $"Cliente: {cliente}\n" +
                $"Computador: {computador}\n" +
                $"Data: {data}\n" +
                $"Horário: {horario}\n\n" +
                $"✅ CONCLUÍDA - Apaga do histórico\n" +
                $"❌ CANCELADA - Remove completamente\n" +
                $"🟢 CONFIRMADA - Cancela e remove\n\n" +
                $"Esta ação NÃO PODE ser desfeita!\n" +
                $"Tem certeza absoluta que deseja continuar?",
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

                        // Primeiro apaga da tabela filha (UsoComputadores) se existir
                        try
                        {
                            string queryDeleteUso = "DELETE FROM UsoComputadores WHERE ReservaId = @ReservaId";
                            using (var cmdUso = new SqlCommand(queryDeleteUso, connection))
                            {
                                cmdUso.Parameters.AddWithValue("@ReservaId", reservaId);
                                cmdUso.ExecuteNonQuery();
                            }
                        }
                        catch (Exception)
                        {
                            // Pode ignorar se a tabela não existir ou não tiver registros
                            Console.WriteLine("Info: Nenhum registro em UsoComputadores para esta reserva");
                        }

                        // Depois apaga da tabela Reservas
                        string queryDeleteReserva = "DELETE FROM Reservas WHERE Id = @Id";
                        using (var cmd = new SqlCommand(queryDeleteReserva, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", reservaId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("✅ Reserva apagada permanentemente do banco de dados!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                CarregarReservas();
                            }
                            else
                            {
                                MessageBox.Show("❌ Nenhuma reserva foi apagada.", "Erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
    
}