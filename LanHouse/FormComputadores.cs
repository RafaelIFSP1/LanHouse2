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

            // Configurar colunas do ListView com estilo discreto
            listViewComputadores.Columns.Add("Computador", 250);
            listViewComputadores.View = View.Details;
            listViewComputadores.FullRowSelect = true;
            listViewComputadores.BorderStyle = BorderStyle.None;
            listViewComputadores.BackColor = Color.FromArgb(45, 45, 48);
            listViewComputadores.ForeColor = Color.FromArgb(200, 200, 200);
            listViewComputadores.Font = new Font("Segoe UI", 10);

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

                            // Formatar o nome como "PC - 01", "PC - 02", etc.
                            string nomeFormatado = $"PC - {id.PadLeft(2, '0')}";

                            // Status discreto sem emojis
                            string statusDiscreto = ObterStatusDiscreto(status);

                            ListViewItem item = new ListViewItem(nomeFormatado);
                            item.SubItems.Add(statusDiscreto);

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

                            // Cores discretas
                            item.BackColor = ObterCorFundoDiscreta(status);
                            item.ForeColor = ObterCorTextoDiscreta(status);
                            item.Font = new Font("Segoe UI", 10, FontStyle.Regular);

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

        private string ObterStatusDiscreto(string status)
        {
            switch (status.ToUpper())
            {
                case "DISPONÍVEL":
                case "DISPONIVEL":
                    return "Disponível";
                case "EM USO":
                case "OCUPADO":
                    return "Em Uso";
                case "MANUTENÇÃO":
                case "MANUTENCAO":
                case "EM MANUTENÇÃO":
                    return "Manutenção";
                default:
                    return status;
            }
        }

        private Color ObterCorFundoDiscreta(string status)
        {
            switch (status.ToUpper())
            {
                case "DISPONÍVEL":
                case "DISPONIVEL":
                    return Color.FromArgb(60, 60, 65); // Cinza escuro
                case "EM USO":
                case "OCUPADO":
                    return Color.FromArgb(70, 70, 75); // Cinza médio
                case "MANUTENÇÃO":
                case "MANUTENCAO":
                case "EM MANUTENÇÃO":
                    return Color.FromArgb(80, 60, 60); // Vermelho escuro
                default:
                    return Color.FromArgb(60, 60, 65); // Cinza escuro padrão
            }
        }

        private Color ObterCorTextoDiscreta(string status)
        {
            switch (status.ToUpper())
            {
                case "DISPONÍVEL":
                case "DISPONIVEL":
                    return Color.FromArgb(100, 200, 100); // Verde suave
                case "EM USO":
                case "OCUPADO":
                    return Color.FromArgb(255, 200, 100); // Laranja suave
                case "MANUTENÇÃO":
                case "MANUTENCAO":
                case "EM MANUTENÇÃO":
                    return Color.FromArgb(255, 100, 100); // Vermelho suave
                default:
                    return Color.FromArgb(200, 200, 200); // Cinza claro padrão
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
                        lblInfoUso.Text = $"{totalHoras:F1} horas (30 dias)";
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

                // Atualizar interface com dados reais
                lblDetalhesTitulo.Text = nomeFormatado;
                lblDetalhesTitulo.ForeColor = Color.FromArgb(220, 220, 220);

                lblInfoProcessador.Text = processador;
                lblInfoProcessador.ForeColor = Color.FromArgb(180, 180, 180);

                lblInfoRAM.Text = ram;
                lblInfoRAM.ForeColor = Color.FromArgb(180, 180, 180);

                lblInfoPreco.Text = $"R$ {precoHora:F2}";
                lblInfoPreco.ForeColor = Color.FromArgb(180, 180, 180);

                // Status discreto
                string statusDiscreto = ObterStatusDiscreto(status);
                lblInfoStatus.Text = statusDiscreto;
                lblInfoStatus.ForeColor = ObterCorTextoDiscreta(status);

                // Atualizar status visual discreto
                if (lblStatusVisual != null)
                {
                    lblStatusVisual.Text = $"● {statusDiscreto.ToUpper()}";
                    lblStatusVisual.ForeColor = ObterCorTextoDiscreta(status);
                    lblStatusVisual.Font = new Font("Segoe UI", 11, FontStyle.Bold);
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
                string computador = item.Text;
                string statusAtual = item.SubItems[1].Text;

                var menuStatus = new ContextMenuStrip();

                var itemDisponivel = new ToolStripMenuItem("🟢 DISPONÍVEL");
                itemDisponivel.Click += (s, args) => AlterarStatusComputador(item, "🟢 DISPONÍVEL");
                if (statusAtual.Contains("DISPONÍVEL")) itemDisponivel.Enabled = false;

                var itemEmUso = new ToolStripMenuItem("🟡 EM USO");
                itemEmUso.Click += (s, args) => AlterarStatusComputador(item, "🟡 EM USO");
                if (statusAtual.Contains("EM USO")) itemEmUso.Enabled = false;

                var itemManutencao = new ToolStripMenuItem("🔴 EM MANUTENÇÃO");
                itemManutencao.Click += (s, args) => AlterarStatusComputador(item, "🔴 EM MANUTENÇÃO");
                if (statusAtual.Contains("MANUTENÇÃO")) itemManutencao.Enabled = false;

                menuStatus.Items.Add(itemDisponivel);
                menuStatus.Items.Add(itemEmUso);
                menuStatus.Items.Add(itemManutencao);

                menuStatus.Show(btnAjustarStatus, new Point(0, btnAjustarStatus.Height));
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

            // Extrair apenas o texto do status (sem emoji)
            string novoSatusBanco = novoStatus
                .Replace("🟢", "").Replace("🟡", "").Replace("🔴", "")
                .Trim();

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
                            cmd.Parameters.AddWithValue("@Status", novoSatusBanco);
                            cmd.Parameters.AddWithValue("@Id", computadorId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Atualizar interface
                    item.SubItems[1].Text = novoStatus;
                    item.BackColor = ObterCorStatus(novoSatusBanco);

                    // Atualizar dados no Tag
                    item.Tag = new
                    {
                        Id = dados.Id,
                        NomeOriginal = dados.NomeOriginal,
                        Processador = dados.Processador,
                        RAM = dados.RAM,
                        Status = novoSatusBanco,
                        PrecoHora = dados.PrecoHora,
                        NomeFormatado = dados.NomeFormatado
                    };

                    MostrarDetalhesComputador(item);

                    MessageBox.Show($"✅ Status do computador {nomeFormatado} atualizado para: {novoStatus}",
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
            string novoNome = $"Computador {listViewComputadores.Items.Count + 1}";

            ListViewItem novoItem = new ListViewItem(new string[] { novoNome, "🟢 DISPONÍVEL" });
            novoItem.BackColor = Color.FromArgb(40, 167, 69);
            novoItem.ForeColor = Color.White;

            listViewComputadores.Items.Add(novoItem);
            novoItem.Selected = true;

            MessageBox.Show($"✅ Novo computador adicionado:\n\nNome: {novoNome}\nStatus: DISPONÍVEL",
                          "Computador Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listViewComputadores.SelectedItems.Count > 0)
            {
                string nome = listViewComputadores.SelectedItems[0].Text;
                MessageBox.Show($"✏️ Editando computador: {nome}\n\n" +
                              "Abrir formulário de edição...",
                              "Editar Computador", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string nome = item.Text;
                string statusAtual = item.SubItems[1].Text;

                if (statusAtual.Contains("MANUTENÇÃO"))
                {
                    DialogResult result = MessageBox.Show(
                        $"Deseja retirar o computador {nome} da manutenção?",
                        "Retirar da Manutenção",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        item.SubItems[1].Text = "🟢 DISPONÍVEL";
                        item.BackColor = Color.FromArgb(40, 167, 69);
                        MostrarDetalhesComputador(item);
                        MessageBox.Show($"✅ Computador {nome} retirado da manutenção!",
                                      "Manutenção Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        $"Deseja colocar o computador {nome} em manutenção?",
                        "Colocar em Manutenção",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        item.SubItems[1].Text = "🔴 EM MANUTENÇÃO";
                        item.BackColor = Color.FromArgb(220, 53, 69);
                        MostrarDetalhesComputador(item);
                        MessageBox.Show($"✅ Computador {nome} colocado em manutenção!",
                                      "Em Manutenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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
            // Código de carga adicional se necessário
        }

        private void panelCabecalho_Paint(object sender, PaintEventArgs e)
        {
            // Código de pintura do cabeçalho se necessário
        }
    }
}