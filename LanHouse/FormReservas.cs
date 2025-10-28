using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace lanhause
{
    public class FormReservas : Form
    {
        private DataGridView dataGridViewReservas;
        private Button btnNovaReserva, btnEditarReserva, btnCancelarReserva, btnFechar, btnRelatorio;
        private Label lblTitulo;
        private GroupBox groupBox1;

        public FormReservas()
        {
            InitializeComponent();
            CarregarReservas();
        }

        private void InitializeComponent()
        {
            // Configuração básica do form
            this.Text = "📅 Reservas - Lan House System";
            this.Size = new Size(1000, 600);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label título
            lblTitulo = new Label();
            lblTitulo.Text = "📅 GERENCIAR RESERVAS";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(111, 66, 193);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(400, 30);
            this.Controls.Add(lblTitulo);

            // GroupBox
            groupBox1 = new GroupBox();
            groupBox1.Text = "Lista de Reservas";
            groupBox1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            groupBox1.Location = new Point(20, 60);
            groupBox1.Size = new Size(960, 400);
            this.Controls.Add(groupBox1);

            // DataGridView
            dataGridViewReservas = new DataGridView();
            dataGridViewReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReservas.BackgroundColor = Color.White;
            dataGridViewReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReservas.Location = new Point(20, 25);
            dataGridViewReservas.Size = new Size(920, 350);
            dataGridViewReservas.ReadOnly = true;
            dataGridViewReservas.RowHeadersVisible = false;
            dataGridViewReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBox1.Controls.Add(dataGridViewReservas);

            // Botão Nova Reserva
            btnNovaReserva = new Button();
            btnNovaReserva.Text = "➕ NOVA RESERVA";
            btnNovaReserva.BackColor = Color.FromArgb(40, 167, 69);
            btnNovaReserva.FlatStyle = FlatStyle.Flat;
            btnNovaReserva.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnNovaReserva.ForeColor = Color.White;
            btnNovaReserva.Location = new Point(20, 480);
            btnNovaReserva.Size = new Size(160, 40);
            btnNovaReserva.Click += new EventHandler(btnNovaReserva_Click);
            this.Controls.Add(btnNovaReserva);

            // Botão Editar
            btnEditarReserva = new Button();
            btnEditarReserva.Text = "✏️ EDITAR";
            btnEditarReserva.BackColor = Color.FromArgb(255, 193, 7);
            btnEditarReserva.FlatStyle = FlatStyle.Flat;
            btnEditarReserva.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnEditarReserva.ForeColor = Color.Black;
            btnEditarReserva.Location = new Point(190, 480);
            btnEditarReserva.Size = new Size(140, 40);
            btnEditarReserva.Click += new EventHandler(btnEditarReserva_Click);
            this.Controls.Add(btnEditarReserva);

            // Botão Cancelar
            btnCancelarReserva = new Button();
            btnCancelarReserva.Text = "❌ CANCELAR";
            btnCancelarReserva.BackColor = Color.FromArgb(220, 53, 69);
            btnCancelarReserva.FlatStyle = FlatStyle.Flat;
            btnCancelarReserva.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCancelarReserva.ForeColor = Color.White;
            btnCancelarReserva.Location = new Point(340, 480);
            btnCancelarReserva.Size = new Size(140, 40);
            btnCancelarReserva.Click += new EventHandler(btnCancelarReserva_Click);
            this.Controls.Add(btnCancelarReserva);

            // Botão Relatório
            btnRelatorio = new Button();
            btnRelatorio.Text = "📊 RELATÓRIO";
            btnRelatorio.BackColor = Color.FromArgb(111, 66, 193);
            btnRelatorio.FlatStyle = FlatStyle.Flat;
            btnRelatorio.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRelatorio.ForeColor = Color.White;
            btnRelatorio.Location = new Point(490, 480);
            btnRelatorio.Size = new Size(140, 40);
            btnRelatorio.Click += new EventHandler(btnRelatorio_Click);
            this.Controls.Add(btnRelatorio);

            // Botão Fechar
            btnFechar = new Button();
            btnFechar.Text = "🔙 VOLTAR";
            btnFechar.BackColor = Color.FromArgb(108, 117, 125);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(860, 480);
            btnFechar.Size = new Size(120, 40);
            btnFechar.Click += new EventHandler(btnFechar_Click); // ADICIONEI O EVENTO CLICK AQUI
            this.Controls.Add(btnFechar);
        }

        private void CarregarReservas()
        {
            try
            {
                dataGridViewReservas.Columns.Clear();
                dataGridViewReservas.Rows.Clear();

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // CONSULTA SIMPLIFICADA - EVITAR CONVERSÕES AUTOMÁTICAS
                    string query = @"
                SELECT 
                    r.Id as ReservaId,
                    r.ClienteNome,
                    c.Nome as ComputadorNome,
                    r.DataReserva as DataStr,
                    r.HoraInicio,
                    r.HoraFim,
                    r.Status,
                    r.ValorTotal
                FROM Reservas r
                JOIN Computadores c ON r.ComputadorId = c.Id
                ORDER BY r.DataReserva DESC, r.HoraInicio DESC";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        // Adicionar colunas
                        dataGridViewReservas.Columns.Add("Id", "ID");
                        dataGridViewReservas.Columns.Add("Cliente", "CLIENTE");
                        dataGridViewReservas.Columns.Add("Computador", "COMPUTADOR");
                        dataGridViewReservas.Columns.Add("Data", "DATA");
                        dataGridViewReservas.Columns.Add("Horario", "HORÁRIO");
                        dataGridViewReservas.Columns.Add("Status", "STATUS");
                        dataGridViewReservas.Columns.Add("Valor", "VALOR");

                        while (reader.Read())
                        {
                            // LER TODOS OS CAMPOS COMO STRING PARA EVITAR CONVERSÃO AUTOMÁTICA
                            string id = reader["ReservaId"].ToString();
                            string cliente = reader["ClienteNome"].ToString();
                            string computador = reader["ComputadorNome"].ToString();
                            string dataStr = reader["DataStr"].ToString(); // Já vem como string
                            string horaInicio = reader["HoraInicio"].ToString();
                            string horaFim = reader["HoraFim"].ToString();
                            string status = reader["Status"].ToString();
                            string valorTotal = reader["ValorTotal"].ToString();

                            string horario = $"{horaInicio} - {horaFim}";

                            // FORMATAR DATA SE ESTIVER NO FORMATO yyyy-MM-dd
                            if (dataStr.Length == 10 && dataStr.Contains("-"))
                            {
                                try
                                {
                                    string[] partes = dataStr.Split('-');
                                    if (partes.Length == 3 && partes[0].Length == 4)
                                    {
                                        dataStr = $"{partes[2]}/{partes[1]}/{partes[0]}";
                                    }
                                }
                                catch
                                {
                                    // Manter o formato original se der erro
                                }
                            }

                            // FORMATAR VALOR
                            string valorFormatado = "R$ 0,00";
                            if (decimal.TryParse(valorTotal, out decimal valor))
                            {
                                valorFormatado = $"R$ {valor:F2}";
                            }

                            dataGridViewReservas.Rows.Add(
                                id,
                                cliente,
                                computador,
                                dataStr,
                                horario,
                                status,
                                valorFormatado
                            );
                        }
                    }
                }

                AplicarCoresStatus();
            }
            catch (Exception ex)
            {
                // VERSÃO DE EMERGÊNCIA - CARREGAR SEM DADOS
                dataGridViewReservas.Columns.Clear();
                dataGridViewReservas.Rows.Clear();

                dataGridViewReservas.Columns.Add("Id", "ID");
                dataGridViewReservas.Columns.Add("Cliente", "CLIENTE");
                dataGridViewReservas.Columns.Add("Computador", "COMPUTADOR");
                dataGridViewReservas.Columns.Add("Data", "DATA");
                dataGridViewReservas.Columns.Add("Horario", "HORÁRIO");
                dataGridViewReservas.Columns.Add("Status", "STATUS");
                dataGridViewReservas.Columns.Add("Valor", "VALOR");

                dataGridViewReservas.Rows.Add("ERRO", "Erro ao carregar", "dados", "-", "-", "Verifique console", "-");

                // Não mostrar MessageBox para não interromper o usuário
                Console.WriteLine($"Erro silencioso ao carregar reservas: {ex.Message}");
            }
        }
        private void AplicarCoresStatus()
        {
            foreach (DataGridViewRow row in dataGridViewReservas.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status.Contains("CONFIRMADA"))
                    {
                        row.Cells["Status"].Style.ForeColor = Color.Green;
                        row.Cells["Status"].Style.Font = new Font(dataGridViewReservas.Font, FontStyle.Bold);
                    }
                    else if (status.Contains("PENDENTE"))
                    {
                        row.Cells["Status"].Style.ForeColor = Color.Orange;
                        row.Cells["Status"].Style.Font = new Font(dataGridViewReservas.Font, FontStyle.Bold);
                    }
                    else if (status.Contains("CANCELADA"))
                    {
                        row.Cells["Status"].Style.ForeColor = Color.Red;
                        row.Cells["Status"].Style.Font = new Font(dataGridViewReservas.Font, FontStyle.Bold);
                    }
                    else if (status.Contains("CONCLUÍDA"))
                    {
                        row.Cells["Status"].Style.ForeColor = Color.Blue;
                        row.Cells["Status"].Style.Font = new Font(dataGridViewReservas.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void btnNovaReserva_Click(object sender, EventArgs e)
        {
            // ABRIR FORM NOVA RESERVA
            FormNovaReserva formNovaReserva = new FormNovaReserva();
            DialogResult result = formNovaReserva.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Recarregar a lista se uma nova reserva foi criada
                CarregarReservas();
                MessageBox.Show("Nova reserva criada com sucesso!", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditarReserva_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservas.CurrentRow != null)
            {
                string reservaId = dataGridViewReservas.CurrentRow.Cells["Id"].Value?.ToString() ?? "";
                MessageBox.Show($"✏️ Editando reserva: {reservaId}\n\n" +
                              "Funcionalidade de edição em desenvolvimento...",
                              "Editar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("⚠️ Selecione uma reserva para editar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservas.CurrentRow != null)
            {
                string reservaId = dataGridViewReservas.CurrentRow.Cells["Id"].Value?.ToString() ?? "";
                string cliente = dataGridViewReservas.CurrentRow.Cells["Cliente"].Value?.ToString() ?? "";
                string statusAtual = dataGridViewReservas.CurrentRow.Cells["Status"].Value?.ToString() ?? "";

                if (statusAtual.Contains("CANCELADA"))
                {
                    MessageBox.Show("Esta reserva já está cancelada.", "Reserva Cancelada",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Tem certeza que deseja cancelar a reserva?\n\n" +
                    $"Cliente: {cliente}\n" +
                    $"Reserva: {reservaId}",
                    "Confirmar Cancelamento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var connection = DatabaseHelper.GetConnection())
                        {
                            connection.Open();
                            string query = "UPDATE Reservas SET Status = '❌ CANCELADA' WHERE Id = @Id";

                            using (var command = new SQLiteCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Id", reservaId);
                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show($"✅ Reserva cancelada com sucesso!", "Cancelamento Concluído",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarReservas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao cancelar reserva: {ex.Message}", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione uma reserva para cancelar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       
       private void btnRelatorio_Click(object sender, EventArgs e)
{
    try
    {
        string relatorio = "📊 RELATÓRIO COMPLETO - COMPUTADORES\n\n";
        decimal receitaGeral = 0;
        decimal horasTotais = 0;
        int reservasTotais = 0;

        using (var reader = DatabaseHelper.ObterRelatorioUso())
        {
            while (reader.Read())
            {
                string computador = reader["ComputadorNome"].ToString();
                int totalReservas = Convert.ToInt32(reader["TotalReservas"]);
                decimal receita = reader["ReceitaTotal"] != DBNull.Value ?
                                Convert.ToDecimal(reader["ReceitaTotal"]) : 0;
                decimal horas = Convert.ToDecimal(reader["TotalHorasUtilizadas"]);
                decimal precoHora = Convert.ToDecimal(reader["PrecoHora"]);

                receitaGeral += receita;
                horasTotais += horas;
                reservasTotais += totalReservas;

                relatorio += $"🖥️ {computador}\n";
                relatorio += $"   📅 Reservas: {totalReservas}\n";
                relatorio += $"   ⏱️ Horas Utilizadas: {horas:F1}h\n";
                relatorio += $"   💰 Receita: R$ {receita:F2}\n";
                relatorio += $"   💵 Preço/Hora: R$ {precoHora:F2}\n";
                
                // Calcular valor médio por hora
                if (horas > 0)
                {
                    decimal valorMedioHora = receita / horas;
                    relatorio += $"   📊 Média/Hora: R$ {valorMedioHora:F2}\n";
                }
                relatorio += "\n";
            }
        }

        relatorio += $"📈 RESUMO GERAL:\n";
        relatorio += $"   📅 Total de Reservas: {reservasTotais}\n";
        relatorio += $"   ⏱️ Total de Horas: {horasTotais:F1}h\n";
        relatorio += $"   💰 Receita Total: R$ {receitaGeral:F2}\n";
        
        // Calcular média geral
        if (horasTotais > 0)
        {
            decimal mediaGeralHora = receitaGeral / horasTotais;
            relatorio += $"   📊 Média Geral/Hora: R$ {mediaGeralHora:F2}";
        }

        MessageBox.Show(relatorio, "Relatório Completo",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}