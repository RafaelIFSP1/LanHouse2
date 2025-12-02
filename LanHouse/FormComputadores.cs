using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public partial class FormComputadores : Form
    {
        private Button btnExcluir;
        private Button btnVoltar;

        public FormComputadores()
        {
            InitializeComponent();
            ConfigurarBotoes();
            CarregarComputadores();
            MostrarPrimeiroComputador();
            AplicarTemaUsuario();
        }

        private void ConfigurarBotoes()
        {
            // Configurar botão Voltar (sempre visível)
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(20, 509);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(140, 40);
            this.btnVoltar.TabIndex = 11;
            this.btnVoltar.Text = "🔙 VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.Controls.Add(this.btnVoltar);

            if (!FormLogin.IsAdmin)
            {
                // USUÁRIO COMUM: Esconder todos os botões de admin
                btnAdicionar.Visible = false;
                btnEditar.Visible = false;
                btnManutencao.Visible = false;
                btnAjustarStatus.Visible = false;
                btnFechar.Visible = false;
            }
            else
            {
                // ADMIN: Mostrar botão Excluir e outros botões admin
                this.btnExcluir = new System.Windows.Forms.Button();
                this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
                this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnExcluir.FlatAppearance.BorderSize = 0;
                this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                this.btnExcluir.ForeColor = System.Drawing.Color.White;
                this.btnExcluir.Location = new System.Drawing.Point(170, 509);
                this.btnExcluir.Name = "btnExcluir";
                this.btnExcluir.Size = new System.Drawing.Size(140, 40);
                this.btnExcluir.TabIndex = 10;
                this.btnExcluir.Text = "🗑️ EXCLUIR";
                this.btnExcluir.UseVisualStyleBackColor = false;
                this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
                this.Controls.Add(this.btnExcluir);

                // Garantir que os botões de admin estão visíveis
                btnAdicionar.Visible = true;
                btnEditar.Visible = true;
                btnManutencao.Visible = true;
                btnAjustarStatus.Visible = true;
                btnFechar.Visible = true;
            }
        }

        private void AplicarTemaUsuario()
        {
            if (FormLogin.IsAdmin)
            {
                // Tema para Administrador
                lblTitulo.ForeColor = Color.FromArgb(0, 91, 158); // Azul mais escuro
            }
            else
            {
                // Tema para Usuário Comum
                lblTitulo.ForeColor = Color.FromArgb(0, 122, 204); // Azul padrão
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // MÉTODO ADICIONADO: Atualizar detalhes quando selecionar um computador
        private void AtualizarDetalhesComputador(dynamic dados)
        {
            if (dados == null) return;

            try
            {
                // Atualizar título e informações básicas
                lblDetalhesTitulo.Text = dados.NomeFormatado;
                lblInfoProcessador.Text = dados.Processador;
                lblInfoRAM.Text = dados.RAM;
                lblInfoStatus.Text = ObterStatusComEmoji(dados.Status);
                lblInfoPreco.Text = $"R$ {dados.PrecoHora:F2}/h";

                // Atualizar status visual
                string statusUpper = dados.Status.ToUpper();
                if (statusUpper.Contains("DISPON"))
                {
                    lblStatusVisual.Text = "● STATUS: DISPONÍVEL";
                    lblStatusVisual.ForeColor = Color.Green;
                }
                else if (statusUpper.Contains("USO") || statusUpper.Contains("OCUPADO"))
                {
                    lblStatusVisual.Text = "● STATUS: EM USO";
                    lblStatusVisual.ForeColor = Color.Red;
                }
                else if (statusUpper.Contains("MANUTEN"))
                {
                    lblStatusVisual.Text = "● STATUS: EM MANUTENÇÃO";
                    lblStatusVisual.ForeColor = Color.Orange;
                }
                else
                {
                    lblStatusVisual.Text = $"● STATUS: {dados.Status}";
                    lblStatusVisual.ForeColor = Color.Yellow;
                }

                // Carregar estatísticas (reservas e horas de uso)
                CarregarEstatisticasComputador(dados.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar detalhes: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODO CORRIGIDO: Carregar estatísticas do computador
        private void CarregarEstatisticasComputador(string computadorId)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // 1. Contar reservas para hoje
                    string queryCount = @"
                        SELECT COUNT(*) 
                        FROM Reservas 
                        WHERE ComputadorId = @ComputadorId 
                        AND DataReserva = @DataAtual
                        AND Status NOT LIKE '%CANCELADA%'";

                    int totalReservas = 0;
                    using (var cmd = new SqlCommand(queryCount, connection))
                    {
                        cmd.Parameters.AddWithValue("@ComputadorId", computadorId);
                        cmd.Parameters.AddWithValue("@DataAtual", DateTime.Today);
                        var result = cmd.ExecuteScalar();
                        totalReservas = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }

                    // 2. Tentar calcular horas totais
                    decimal horasTotais = 0;

                    // Primeiro verificar se existe alguma reserva
                    if (totalReservas > 0)
                    {
                        string queryHoras = @"
                            SELECT HoraInicio, HoraFim 
                            FROM Reservas 
                            WHERE ComputadorId = @ComputadorId 
                            AND DataReserva = @DataAtual
                            AND Status NOT LIKE '%CANCELADA%'";

                        using (var cmd = new SqlCommand(queryHoras, connection))
                        {
                            cmd.Parameters.AddWithValue("@ComputadorId", computadorId);
                            cmd.Parameters.AddWithValue("@DataAtual", DateTime.Today);

                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string horaInicioStr = reader["HoraInicio"].ToString();
                                    string horaFimStr = reader["HoraFim"].ToString();

                                    try
                                    {
                                        // Converter formato "08.00" para TimeSpan
                                        string horaInicioFormatada = horaInicioStr.Replace('.', ':');
                                        string horaFimFormatada = horaFimStr.Replace('.', ':');

                                        TimeSpan horaInicio = TimeSpan.Parse(horaInicioFormatada);
                                        TimeSpan horaFim = TimeSpan.Parse(horaFimFormatada);

                                        // Calcular duração
                                        TimeSpan duracao;
                                        if (horaFim > horaInicio)
                                        {
                                            duracao = horaFim - horaInicio;
                                        }
                                        else
                                        {
                                            // Reserva que passa da meia-noite
                                            duracao = (TimeSpan.FromHours(24) - horaInicio) + horaFim;
                                        }

                                        horasTotais += (decimal)duracao.TotalHours;
                                    }
                                    catch
                                    {
                                        // Se não conseguir converter, adiciona 1 hora como padrão
                                        horasTotais += 1.0m;
                                    }
                                }
                            }
                        }
                    }

                    // 3. Atualizar as labels
                    if (totalReservas > 0)
                    {
                        lblInfoReservas.Text = $"{totalReservas} reserva{(totalReservas != 1 ? "s" : "")}";
                        lblInfoUso.Text = $"{horasTotais:F1} horas";
                    }
                    else
                    {
                        lblInfoReservas.Text = "Nenhuma reserva hoje";
                        lblInfoUso.Text = "0 horas";
                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, mostrar valores padrão
                lblInfoReservas.Text = "0 reservas";
                lblInfoUso.Text = "0 horas";

                // Para debug apenas (descomente se necessário)
                // Console.WriteLine($"Erro ao carregar estatísticas: {ex.Message}");
            }
        }

        // MÉTODO ADICIONADO: listViewComputadores_SelectedIndexChanged
        private void listViewComputadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewComputadores.SelectedItems.Count > 0)
            {
                var item = listViewComputadores.SelectedItems[0];
                var dados = item.Tag as dynamic;
                AtualizarDetalhesComputador(dados);
            }
            else
            {
                LimparDetalhes();
            }
        }

        // MÉTODO ADICIONADO: Limpar detalhes quando não há seleção
        private void LimparDetalhes()
        {
            lblDetalhesTitulo.Text = "Detalhes do Computador";
            lblInfoProcessador.Text = "Selecione um computador";
            lblInfoRAM.Text = "";
            lblInfoStatus.Text = "";
            lblInfoPreco.Text = "";
            lblInfoReservas.Text = "";
            lblInfoUso.Text = "";
            lblStatusVisual.Text = "● STATUS: NÃO SELECIONADO";
            lblStatusVisual.ForeColor = Color.Gray;
        }

        // MÉTODO ADICIONADO: Mostrar primeiro computador ao carregar
        private void MostrarPrimeiroComputador()
        {
            if (listViewComputadores.Items.Count > 0)
            {
                listViewComputadores.Items[0].Selected = true;
                listViewComputadores.Select();

                // Garantir que os detalhes são atualizados
                var item = listViewComputadores.Items[0];
                var dados = item.Tag as dynamic;
                AtualizarDetalhesComputador(dados);
            }
            else
            {
                LimparDetalhes();
            }
        }

        // MÉTODOS DE ADMINISTRAÇÃO - SÓ EXECUTAM SE FOR ADMIN
        private void btnAjustarStatus_Click(object sender, EventArgs e)
        {
            if (!FormLogin.IsAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem ajustar status!",
                              "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listViewComputadores.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewComputadores.SelectedItems[0];
                var dados = item.Tag as dynamic;
                string computador = dados.NomeFormatado;
                string statusAtual = dados.Status;

                string novoStatus = MostrarDialogoStatus(computador, statusAtual);
                if (!string.IsNullOrEmpty(novoStatus))
                {
                    AlterarStatusComputador(item, novoStatus);
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um computador para ajustar o status.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Método simplificado para mostrar diálogo de status
        private string MostrarDialogoStatus(string computador, string statusAtual)
        {
            using (var form = new Form())
            {
                form.Size = new Size(400, 280);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.StartPosition = FormStartPosition.CenterParent;
                form.Text = "Alterar Status do Computador";
                form.BackColor = Color.White;

                var lblTitulo = new Label
                {
                    Text = $"Alterar Status:\n{computador}",
                    Location = new Point(20, 20),
                    Size = new Size(350, 50),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 122, 204),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var btnDisponivel = new Button
                {
                    Text = "🟢 DISPONÍVEL",
                    Location = new Point(75, 90),
                    Size = new Size(250, 45),
                    BackColor = Color.FromArgb(40, 167, 69),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Tag = "DISPONÍVEL"
                };
                btnDisponivel.FlatAppearance.BorderSize = 0;

                var btnEmUso = new Button
                {
                    Text = "🟡 EM USO",
                    Location = new Point(75, 145),
                    Size = new Size(250, 45),
                    BackColor = Color.FromArgb(255, 193, 7),
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Tag = "EM USO"
                };
                btnEmUso.FlatAppearance.BorderSize = 0;

                var btnManutencao = new Button
                {
                    Text = "🔴 EM MANUTENÇÃO",
                    Location = new Point(75, 200),
                    Size = new Size(250, 45),
                    BackColor = Color.FromArgb(220, 53, 69),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Tag = "EM MANUTENÇÃO"
                };
                btnManutencao.FlatAppearance.BorderSize = 0;

                string resultado = null;

                btnDisponivel.Click += (s, e) =>
                {
                    resultado = btnDisponivel.Tag as string;
                    form.DialogResult = DialogResult.OK;
                };
                btnEmUso.Click += (s, e) =>
                {
                    resultado = btnEmUso.Tag as string;
                    form.DialogResult = DialogResult.OK;
                };
                btnManutencao.Click += (s, e) =>
                {
                    resultado = btnManutencao.Tag as string;
                    form.DialogResult = DialogResult.OK;
                };

                // Desabilitar botão do status atual
                string statusUpper = statusAtual.ToUpper();
                if (statusUpper.Contains("DISPON")) btnDisponivel.Enabled = false;
                if (statusUpper.Contains("USO")) btnEmUso.Enabled = false;
                if (statusUpper.Contains("MANUTEN")) btnManutencao.Enabled = false;

                form.Controls.AddRange(new Control[] { lblTitulo, btnDisponivel, btnEmUso, btnManutencao });

                if (form.ShowDialog() == DialogResult.OK)
                {
                    return resultado;
                }
                return null;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!FormLogin.IsAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem adicionar computadores!",
                              "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (!FormLogin.IsAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem editar computadores!",
                              "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (!FormLogin.IsAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem alterar status de manutenção!",
                              "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listViewComputadores.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewComputadores.SelectedItems[0];
                var dados = item.Tag as dynamic;
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!FormLogin.IsAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem excluir computadores!",
                              "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listViewComputadores.SelectedItems.Count == 0)
            {
                MessageBox.Show("⚠️ Selecione um computador para excluir.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ListViewItem item = listViewComputadores.SelectedItems[0];
            var dados = item.Tag as dynamic;
            string computadorId = dados.Id;
            string nomeFormatado = dados.NomeFormatado;
            string status = dados.Status;

            if (status.ToUpper().Contains("USO") || status.ToUpper().Contains("OCUPADO"))
            {
                MessageBox.Show("❌ Não é possível excluir um computador que está em uso!\n" +
                              "Altere o status para 'DISPONÍVEL' ou 'EM MANUTENÇÃO' antes de excluir.",
                              "Computador em Uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ExistemReservasFuturas(computadorId))
            {
                MessageBox.Show("❌ Não é possível excluir este computador!\n\n" +
                              "Existem reservas futuras agendadas.\n" +
                              "Cancele todas as reservas primeiro.",
                              "Reservas Ativas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"🚨 ATENÇÃO: EXCLUSÃO PERMANENTE 🚨\n\n" +
                $"Você está prestes a EXCLUIR PERMANENTEMENTE:\n\n" +
                $"🔹 {nomeFormatado}\n" +
                $"🔹 {dados.Processador}\n" +
                $"🔹 {dados.RAM}\n" +
                $"🔹 Status: {status}\n\n" +
                $"⚠️  Esta ação NÃO PODE ser desfeita!\n" +
                $"⚠️  Todos os dados serão perdidos!\n\n" +
                $"Tem certeza ABSOLUTA que deseja continuar?",
                "CONFIRMAR EXCLUSÃO PERMANENTE",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                ExcluirComputador(computadorId, item);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (!FormLogin.IsAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem usar este botão!",
                              "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Close();
        }

        private void CarregarComputadores()
        {
            if (listViewComputadores == null) return;

            listViewComputadores.Items.Clear();
            listViewComputadores.Columns.Clear();

            // Configurar colunas
            listViewComputadores.Columns.Add("Computador", 150);
            listViewComputadores.Columns.Add("Status", 130);
            listViewComputadores.Columns.Add("Especificações", 280);
            listViewComputadores.View = View.Details;
            listViewComputadores.FullRowSelect = true;
            listViewComputadores.BorderStyle = BorderStyle.None;
            listViewComputadores.BackColor = Color.FromArgb(51, 51, 55);
            listViewComputadores.ForeColor = Color.White;
            listViewComputadores.Font = new Font("Segoe UI", 10);
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

                            string nomeFormatado = nome;
                            if (!nome.StartsWith("PC-"))
                            {
                                if (int.TryParse(id, out int idNumero))
                                {
                                    nomeFormatado = $"PC-{idNumero.ToString().PadLeft(3, '0')}";
                                }
                                else
                                {
                                    nomeFormatado = $"PC-{id}";
                                }
                            }

                            string statusComEmoji = ObterStatusComEmoji(status);
                            string especificacoes = $"{processador} • {ram} • R$ {precoHora:F2}/h";

                            ListViewItem item = new ListViewItem(nomeFormatado);
                            item.SubItems.Add(statusComEmoji);
                            item.SubItems.Add(especificacoes);

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

                            item.BackColor = Color.FromArgb(51, 51, 55);
                            item.ForeColor = Color.White;

                            if (status.ToUpper().Contains("DISPON"))
                                item.BackColor = Color.FromArgb(60, 80, 60);
                            else if (status.ToUpper().Contains("USO") || status.ToUpper().Contains("OCUPADO"))
                                item.BackColor = Color.FromArgb(80, 70, 50);
                            else if (status.ToUpper().Contains("MANUTEN"))
                                item.BackColor = Color.FromArgb(80, 50, 50);

                            listViewComputadores.Items.Add(item);
                        }
                    }
                }

                if (listViewComputadores.Items.Count > 0)
                    listViewComputadores.Items[0].Selected = true;

                AtualizarTitulo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar computadores:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTitulo()
        {
            int total = listViewComputadores.Items.Count;
            int disponiveis = 0;
            int emUso = 0;
            int manutencao = 0;

            foreach (ListViewItem item in listViewComputadores.Items)
            {
                var dados = item.Tag as dynamic;
                string status = dados.Status.ToUpper();

                if (status.Contains("DISPON")) disponiveis++;
                else if (status.Contains("USO")) emUso++;
                else if (status.Contains("MANUTEN")) manutencao++;
            }

            // Ajustar título baseado no tipo de usuário
            if (!FormLogin.IsAdmin)
            {
                lblTitulo.Text = $"🖥️ COMPUTADORES DISPONÍVEIS ({disponiveis} de {total})";
            }
            else
            {
                lblTitulo.Text = $"🖥️ COMPUTADORES ({total} total | {disponiveis} disponíveis | {emUso} em uso | {manutencao} manutenção)";
            }
        }

        // MÉTODOS CORRIGIDOS PARA C# 7.3

        private string ObterStatusComEmoji(string status)
        {
            if (string.IsNullOrEmpty(status))
                return "❓ Desconhecido";

            string statusUpper = status.ToUpper();

            if (statusUpper.Contains("DISPONÍVEL") || statusUpper.Contains("DISPONIVEL"))
                return "✅ Disponível";
            else if (statusUpper.Contains("EM USO") || statusUpper.Contains("OCUPADO"))
                return "🔴 Em Uso";
            else if (statusUpper.Contains("MANUTENÇÃO") || statusUpper.Contains("MANUTENCAO") ||
                     statusUpper.Contains("EM MANUTENÇÃO") || statusUpper.Contains("EM MANUTENCAO"))
                return "🛠️ Manutenção";
            else if (statusUpper.Contains("RESERVADO"))
                return "📅 Reservado";
            else
                return "❓ " + status;
        }

        private bool ExistemReservasFuturas(string computadorId)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT COUNT(*) FROM Reservas 
                                   WHERE ComputadorId = @ComputadorId 
                                   AND DataReserva >= @DataAtual 
                                   AND Status NOT LIKE '%CANCELADA%'";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ComputadorId", computadorId);
                        cmd.Parameters.AddWithValue("@DataAtual", DateTime.Today);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar reservas: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Por segurança, assume que existem reservas em caso de erro
            }
        }

        private void ExcluirComputador(string computadorId, ListViewItem item)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Iniciar transação para garantir consistência
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Primeiro excluir reservas relacionadas
                            string deleteReservas = "DELETE FROM Reservas WHERE ComputadorId = @ComputadorId";
                            using (var cmdReservas = new SqlCommand(deleteReservas, connection, transaction))
                            {
                                cmdReservas.Parameters.AddWithValue("@ComputadorId", computadorId);
                                cmdReservas.ExecuteNonQuery();
                            }

                            // 2. Depois excluir o computador
                            string deleteComputador = "DELETE FROM Computadores WHERE Id = @Id";
                            using (var cmdComputador = new SqlCommand(deleteComputador, connection, transaction))
                            {
                                cmdComputador.Parameters.AddWithValue("@Id", computadorId);
                                int rowsAffected = cmdComputador.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();

                                    // Remover da lista visual
                                    listViewComputadores.Items.Remove(item);

                                    // Limpar detalhes se era o item selecionado
                                    LimparDetalhes();

                                    MessageBox.Show("✅ Computador excluído com sucesso!",
                                                  "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    AtualizarTitulo();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("❌ Computador não encontrado!",
                                                  "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao excluir computador:\n{ex.Message}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlterarStatusComputador(ListViewItem item, string novoStatus)
        {
            try
            {
                var dados = item.Tag as dynamic;
                string computadorId = dados.Id;

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Computadores SET Status = @Status WHERE Id = @Id";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Status", novoStatus);
                        cmd.Parameters.AddWithValue("@Id", computadorId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Atualizar o item na lista
                            dados.Status = novoStatus;
                            item.Tag = dados;

                            string statusComEmoji = ObterStatusComEmoji(novoStatus);
                            item.SubItems[1].Text = statusComEmoji;

                            // Atualizar cor de fundo baseada no status
                            item.BackColor = Color.FromArgb(51, 51, 55);
                            if (novoStatus.ToUpper().Contains("DISPON"))
                                item.BackColor = Color.FromArgb(60, 80, 60);
                            else if (novoStatus.ToUpper().Contains("USO") || novoStatus.ToUpper().Contains("OCUPADO"))
                                item.BackColor = Color.FromArgb(80, 70, 50);
                            else if (novoStatus.ToUpper().Contains("MANUTEN"))
                                item.BackColor = Color.FromArgb(80, 50, 50);

                            // Atualizar detalhes se este é o item selecionado
                            if (item.Selected)
                            {
                                AtualizarDetalhesComputador(dados);
                            }

                            AtualizarTitulo();

                            MessageBox.Show($"✅ Status alterado para: {novoStatus}",
                                          "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao alterar status:\n{ex.Message}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODOS RESTANTES DO FORMULÁRIO

        private void FormComputadores_Load(object sender, EventArgs e)
        {
            // Código de carregamento adicional se necessário
        }

        private void panelCabecalho_Paint(object sender, PaintEventArgs e)
        {
            // Código de pintura personalizada se necessário
        }
    }
}