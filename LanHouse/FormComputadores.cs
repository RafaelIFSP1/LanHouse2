using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public partial class FormComputadores : Form
    {
        public FormComputadores()
        {
            InitializeComponent();
            CarregarComputadores();
            MostrarPrimeiroComputador();
        }

        private void CarregarComputadores()
        {
            if (listViewComputadores == null) return;

            listViewComputadores.Items.Clear();
            listViewComputadores.Columns.Clear();

            // Configurar colunas do ListView com design dark mode
            listViewComputadores.Columns.Add("Computador", 120);
            listViewComputadores.Columns.Add("Status", 100);
            listViewComputadores.Columns.Add("Especificações", 200);
            listViewComputadores.View = View.Details;
            listViewComputadores.FullRowSelect = true;
            listViewComputadores.BorderStyle = BorderStyle.None;
            listViewComputadores.BackColor = Color.FromArgb(51, 51, 55);
            listViewComputadores.ForeColor = Color.White;
            listViewComputadores.Font = new Font("Segoe UI", 9);
            listViewComputadores.GridLines = false;

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Id, Nome, Processador, RAM, Status, PrecoHora FROM Computadores ORDER BY Id";

                    using (var cmd = new SqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["Id"].ToString();
                            string nome = reader["Nome"].ToString();
                            string processador = reader["Processador"].ToString();
                            string ram = reader["RAM"].ToString();
                            string status = reader["Status"].ToString();
                            decimal precoHora = Convert.ToDecimal(reader["PrecoHora"]);

                            // Formatar o nome como "PC-001", "PC-002", etc.
                            string nomeFormatado = $"PC-{id.PadLeft(3, '0')}";

                            // Status com emojis
                            string statusComEmoji = ObterStatusComEmoji(status);
                            string especificacoes = $"{processador} • {ram}";

                            ListViewItem item = new ListViewItem(nomeFormatado);
                            item.SubItems.Add(statusComEmoji);
                            item.SubItems.Add(especificacoes);

                            // Armazenar dados completos para mostrar nos detalhes
                            item.Tag = new
                            {
                                Id = id,
                                NomeOriginal = nome,
                                Processador = processador,
                                RAM = ram,
                                Status = status,
                                PrecoHora = precoHora,
                                NomeFormatado = nomeFormatado
                            };

                            // Cores baseadas no status (dark mode)
                            item.BackColor = Color.FromArgb(51, 51, 55);
                            item.ForeColor = Color.White;

                            // Destacar linha baseada no status
                            if (status.ToUpper().Contains("DISPON"))
                                item.BackColor = Color.FromArgb(60, 80, 60); // Verde escuro
                            else if (status.ToUpper().Contains("USO") || status.ToUpper().Contains("OCUPADO"))
                                item.BackColor = Color.FromArgb(80, 70, 50); // Amarelo escuro
                            else if (status.ToUpper().Contains("MANUTEN"))
                                item.BackColor = Color.FromArgb(80, 50, 50); // Vermelho escuro

                            listViewComputadores.Items.Add(item);
                        }
                    }
                }

                if (listViewComputadores.Items.Count > 0)
                    listViewComputadores.Items[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar computadores:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObterStatusComEmoji(string status)
        {
            switch (status.ToUpper())
            {
                case "DISPONÍVEL":
                case "DISPONIVEL":
                    return "🟢 DISPONÍVEL";
                case "EM USO":
                case "OCUPADO":
                    return "🟡 EM USO";
                case "MANUTENÇÃO":
                case "MANUTENCAO":
                case "EM MANUTENÇÃO":
                    return "🔴 EM MANUTENÇÃO";
                default:
                    return "⚪ " + status;
            }
        }

        private Color ObterCorStatus(string status)
        {
            switch (status.ToUpper())
            {
                case "DISPONÍVEL":
                case "DISPONIVEL":
                    return Color.FromArgb(40, 167, 69); // Verde
                case "EM USO":
                case "OCUPADO":
                    return Color.FromArgb(255, 193, 7);  // Amarelo/Laranja
                case "MANUTENÇÃO":
                case "MANUTENCAO":
                case "EM MANUTENÇÃO":
                    return Color.FromArgb(220, 53, 69);  // Vermelho
                default:
                    return Color.FromArgb(108, 117, 125); // Cinza
            }
        }

        private Color ObterCorStatusDark(string status)
        {
            switch (status.ToUpper())
            {
                case "DISPONÍVEL":
                case "DISPONIVEL":
                    return Color.FromArgb(100, 200, 100); // Verde claro
                case "EM USO":
                case "OCUPADO":
                    return Color.FromArgb(255, 200, 100); // Amarelo claro
                case "MANUTENÇÃO":
                case "MANUTENCAO":
                case "EM MANUTENÇÃO":
                    return Color.FromArgb(255, 100, 100); // Vermelho claro
                default:
                    return Color.FromArgb(200, 200, 200); // Cinza claro
            }
        }

        private void MostrarPrimeiroComputador()
        {
            if (listViewComputadores != null && listViewComputadores.Items.Count > 0)
            {
                listViewComputadores.Items[0].Selected = true;
            }
        }

        private void listViewComputadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewComputadores.SelectedItems.Count > 0)
            {
                MostrarDetalhesComputador(listViewComputadores.SelectedItems[0]);
            }
        }

        private void CarregarEstatisticasComputador(string computadorId)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Reservas de hoje
                    string queryReservas = @"
                        SELECT COUNT(*) as TotalReservas
                        FROM Reservas 
                        WHERE ComputadorId = @ComputadorId 
                        AND DataReserva = CAST(GETDATE() AS DATE)
                        AND Status IN ('CONFIRMADA', 'CONCLUÍDA')";

                    using (var cmd = new SqlCommand(queryReservas, connection))
                    {
                        cmd.Parameters.AddWithValue("@ComputadorId", computadorId);
                        int totalReservas = Convert.ToInt32(cmd.ExecuteScalar());
                        lblInfoReservas.Text = $"{totalReservas} reserva{(totalReservas != 1 ? "s" : "")}";
                    }

                    // Horas de uso (apenas reservas concluídas)
                    string queryHorasUso = @"
                        SELECT ISNULL(SUM(
                            CASE 
                                WHEN HoraFim > HoraInicio THEN
                                    DATEDIFF(MINUTE, 
                                        CAST(HoraInicio AS datetime), 
                                        CAST(HoraFim AS datetime)
                                    ) / 60.0
                                ELSE
                                    (24 - CAST(LEFT(HoraInicio, 2) AS int) + CAST(LEFT(HoraFim, 2) AS int)) +
                                    (CAST(RIGHT(HoraFim, 2) AS int) - CAST(RIGHT(HoraInicio, 2) AS int)) / 60.0
                            END
                        ), 0) as TotalHoras
                        FROM Reservas 
                        WHERE ComputadorId = @ComputadorId 
                        AND Status = 'CONCLUÍDA'
                        AND DataReserva >= DATEADD(DAY, -30, GETDATE())";

                    using (var cmd = new SqlCommand(queryHorasUso, connection))
                    {
                        cmd.Parameters.AddWithValue("@ComputadorId", computadorId);
                        decimal totalHoras = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblInfoUso.Text = $"{totalHoras:F1} horas";
                    }
                }
            }
            catch (Exception ex)
            {
                // Se der erro, mostra valores padrão
                lblInfoReservas.Text = "0 reservas";
                lblInfoUso.Text = "0 horas";
                Console.WriteLine($"Erro ao carregar estatísticas: {ex.Message}");
            }
        }

        private void MostrarDetalhesComputador(ListViewItem item)
        {
            if (lblDetalhesTitulo == null || item.Tag == null) return;

            try
            {
                // Recuperar dados do Tag
                var dados = item.Tag as dynamic;
                string id = dados.Id;
                string nomeOriginal = dados.NomeOriginal;
                string processador = dados.Processador;
                string ram = dados.RAM;
                string status = dados.Status;
                decimal precoHora = dados.PrecoHora;
                string nomeFormatado = dados.NomeFormatado;

                // Atualizar interface com dados reais - Design dark mode
                lblDetalhesTitulo.Text = nomeFormatado;
                lblDetalhesTitulo.ForeColor = Color.White;
                lblDetalhesTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);

                lblInfoProcessador.Text = processador;
                lblInfoProcessador.ForeColor = Color.White;
                lblInfoProcessador.Font = new Font("Segoe UI", 10);

                lblInfoRAM.Text = ram;
                lblInfoRAM.ForeColor = Color.White;
                lblInfoRAM.Font = new Font("Segoe UI", 10);

                lblInfoPreco.Text = $"R$ {precoHora:F2}";
                lblInfoPreco.ForeColor = Color.FromArgb(100, 200, 100); // Verde
                lblInfoPreco.Font = new Font("Segoe UI", 10);

                // Status com design dark mode
                string statusComEmoji = ObterStatusComEmoji(status);
                lblInfoStatus.Text = statusComEmoji;
                lblInfoStatus.ForeColor = ObterCorStatusDark(status);
                lblInfoStatus.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                lblInfoReservas.ForeColor = Color.White;
                lblInfoReservas.Font = new Font("Segoe UI", 10);

                lblInfoUso.ForeColor = Color.White;
                lblInfoUso.Font = new Font("Segoe UI", 10);

                // Atualizar status visual
                if (lblStatusVisual != null)
                {
                    lblStatusVisual.Text = $"● STATUS: {status.ToUpper()}";
                    lblStatusVisual.ForeColor = ObterCorStatusDark(status);
                    lblStatusVisual.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                }

                // Carregar estatísticas em tempo real
                CarregarEstatisticasComputador(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar detalhes:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjustarStatus_Click(object sender, EventArgs e)
        {
            if (listViewComputadores.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewComputadores.SelectedItems[0];
                var dados = item.Tag as dynamic;
                string computador = dados.NomeFormatado;
                string statusAtual = dados.Status;

                using (var formStatus = new FormSelecionarStatus(computador, statusAtual))
                {
                    if (formStatus.ShowDialog() == DialogResult.OK)
                    {
                        string novoStatus = formStatus.NovoStatus;
                        AlterarStatusComputador(item, novoStatus);
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um computador para ajustar o status.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AlterarStatusComputador(ListViewItem item, string novoStatus)
        {
            if (item.Tag == null) return;

            var dados = item.Tag as dynamic;
            string computadorId = dados.Id;
            string nomeFormatado = dados.NomeFormatado;

            DialogResult result = MessageBox.Show(
                $"Confirmar alteração de status:\n\n" +
                $"Computador: {nomeFormatado}\n" +
                $"Novo Status: {novoStatus}",
                "Confirmar Alteração de Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE Computadores SET Status = @Status WHERE Id = @Id";

                        using (var cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Status", novoStatus);
                            cmd.Parameters.AddWithValue("@Id", computadorId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Atualizar interface
                    string statusComEmoji = ObterStatusComEmoji(novoStatus);
                    item.SubItems[1].Text = statusComEmoji;

                    // Atualizar cor de fundo baseada no status (dark mode)
                    if (novoStatus.ToUpper().Contains("DISPON"))
                        item.BackColor = Color.FromArgb(60, 80, 60);
                    else if (novoStatus.ToUpper().Contains("USO") || novoStatus.ToUpper().Contains("OCUPADO"))
                        item.BackColor = Color.FromArgb(80, 70, 50);
                    else if (novoStatus.ToUpper().Contains("MANUTEN"))
                        item.BackColor = Color.FromArgb(80, 50, 50);

                    // Atualizar dados no Tag
                    item.Tag = new
                    {
                        Id = dados.Id,
                        NomeOriginal = dados.NomeOriginal,
                        Processador = dados.Processador,
                        RAM = dados.RAM,
                        Status = novoStatus,
                        PrecoHora = dados.PrecoHora,
                        NomeFormatado = dados.NomeFormatado
                    };

                    MostrarDetalhesComputador(item);

                    MessageBox.Show($"✅ Status do computador {nomeFormatado} atualizado!",
                                  "Status Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar status:\n{ex.Message}", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var formNovoPC = new FormNovoComputador())
            {
                if (formNovoPC.ShowDialog() == DialogResult.OK)
                {
                    CarregarComputadores();
                    MessageBox.Show("✅ Novo computador adicionado com sucesso!",
                                  "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listViewComputadores.SelectedItems.Count > 0)
            {
                var item = listViewComputadores.SelectedItems[0];
                var dados = item.Tag as dynamic;

                using (var formEditar = new FormEditarComputador(dados))
                {
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        CarregarComputadores();
                        MessageBox.Show("✅ Computador atualizado com sucesso!",
                                      "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um computador para editar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnManutencao_Click(object sender, EventArgs e)
        {
            if (listViewComputadores.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewComputadores.SelectedItems[0];
                var dados = item.Tag as dynamic;
                string nome = dados.NomeFormatado;
                string statusAtual = dados.Status;

                string novoStatus = statusAtual.ToUpper().Contains("MANUTEN") ? "DISPONÍVEL" : "EM MANUTENÇÃO";
                AlterarStatusComputador(item, novoStatus);
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um computador para manutenção.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormComputadores_Load(object sender, EventArgs e)
        {
            // Configurações iniciais de design - Dark mode
            this.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void panelCabecalho_Paint(object sender, PaintEventArgs e)
        {
            // Gradiente no cabeçalho (azul escuro)
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                panelCabecalho.ClientRectangle,
                Color.FromArgb(0, 122, 204),
                Color.FromArgb(0, 90, 170),
                90f))
            {
                e.Graphics.FillRectangle(brush, panelCabecalho.ClientRectangle);
            }
        }
    }

    // Form para seleção de status
    public class FormSelecionarStatus : Form
    {
        public string NovoStatus { get; private set; }

        public FormSelecionarStatus(string computador, string statusAtual)
        {
            InitializeComponent(computador, statusAtual);
        }

        private void InitializeComponent(string computador, string statusAtual)
        {
            this.Size = new Size(350, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Alterar Status do Computador";
            this.BackColor = Color.White;

            var lblTitulo = new Label
            {
                Text = $"Alterar Status:\n{computador}",
                Location = new Point(20, 20),
                Size = new Size(300, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 162, 184),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var btnDisponivel = new Button
            {
                Text = "🟢 DISPONÍVEL",
                Location = new Point(50, 80),
                Size = new Size(250, 40),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            var btnEmUso = new Button
            {
                Text = "🟡 EM USO",
                Location = new Point(50, 130),
                Size = new Size(250, 40),
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            var btnManutencao = new Button
            {
                Text = "🔴 EM MANUTENÇÃO",
                Location = new Point(50, 180),
                Size = new Size(250, 40),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            btnDisponivel.Click += (s, e) => { NovoStatus = "DISPONÍVEL"; this.DialogResult = DialogResult.OK; };
            btnEmUso.Click += (s, e) => { NovoStatus = "EM USO"; this.DialogResult = DialogResult.OK; };
            btnManutencao.Click += (s, e) => { NovoStatus = "EM MANUTENÇÃO"; this.DialogResult = DialogResult.OK; };

            // Desabilitar botão do status atual
            if (statusAtual.ToUpper().Contains("DISPON")) btnDisponivel.Enabled = false;
            if (statusAtual.ToUpper().Contains("USO")) btnEmUso.Enabled = false;
            if (statusAtual.ToUpper().Contains("MANUTEN")) btnManutencao.Enabled = false;

            this.Controls.AddRange(new Control[] { lblTitulo, btnDisponivel, btnEmUso, btnManutencao });
        }
    }
}