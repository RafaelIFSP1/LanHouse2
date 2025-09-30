using System;
using System.Data;
using System.Windows.Forms;

namespace LanHouseSystem
{
    public partial class FormPrincipal : Form
    {
        private DatabaseHelper db;
        private Timer timerSessoes;

        public FormPrincipal()
        {
            InitializeComponent();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            try
            {
                db = new DatabaseHelper();
                ConfigureDataGridViews();
                ConfigureTimer();
                CarregarDados();
                UpdateStatusStrip("Sistema inicializado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar o sistema: {ex.Message}", "Erro de Inicialização",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ConfigureDataGridViews()
        {
            // Configurar DataGridView dos Computadores
            dataGridViewComputadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewComputadores.ReadOnly = true;
            dataGridViewComputadores.MultiSelect = false;
            dataGridViewComputadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewComputadores.AllowUserToAddRows = false;
            dataGridViewComputadores.AllowUserToDeleteRows = false;

            // Configurar DataGridView das Sessões
            dataGridViewSessoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSessoes.ReadOnly = true;
            dataGridViewSessoes.MultiSelect = false;
            dataGridViewSessoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSessoes.AllowUserToAddRows = false;
            dataGridViewSessoes.AllowUserToDeleteRows = false;
        }

        private void ConfigureTimer()
        {
            timerSessoes = new Timer();
            timerSessoes.Interval = 30000; // 30 segundos
            timerSessoes.Tick += TimerSessoes_Tick;
            timerSessoes.Start();
        }

        private void TimerSessoes_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) // Se estiver na aba de Sessões
            {
                AtualizarSessoesAutomaticamente();
            }
        }

        private void CarregarDados()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Carregar computadores disponíveis
                DataTable computadores = db.GetComputadoresDisponiveis();
                dataGridViewComputadores.DataSource = computadores;

                // Carregar clientes
                DataTable clientes = db.GetClientes();
                comboBoxClientes.DataSource = clientes;
                comboBoxClientes.DisplayMember = "Nome";
                comboBoxClientes.ValueMember = "Id";

                // Carregar sessões ativas
                DataTable sessoes = db.GetSessoesAtivas();
                dataGridViewSessoes.DataSource = sessoes;

                UpdateStatusStrip($"Sistema carregado - {computadores.Rows.Count} computadores disponíveis, {sessoes.Rows.Count} sessões ativas");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatusStrip("Erro ao carregar dados do sistema");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AtualizarSessoesAutomaticamente()
        {
            try
            {
                DataTable sessoes = db.GetSessoesAtivas();
                dataGridViewSessoes.DataSource = sessoes;

                if (sessoes.Rows.Count > 0)
                {
                    toolStripStatusLabel.Text = $"{sessoes.Rows.Count} sessões ativas - Última atualização: {DateTime.Now:HH:mm:ss}";
                }
            }
            catch (Exception ex)
            {
                // Não mostrar mensagem para evitar spam, apenas logar no status
                UpdateStatusStrip($"Erro na atualização automática: {ex.Message}");
            }
        }

        private void UpdateStatusStrip(string message)
        {
            if (toolStripStatusLabel != null)
            {
                toolStripStatusLabel.Text = message;
            }
        }

        private void btnIniciarSessao_Click(object sender, EventArgs e)
        {
            if (dataGridViewComputadores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um computador para iniciar a sessão!", "Atenção",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para iniciar a sessão!", "Atenção",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int computadorId = Convert.ToInt32(dataGridViewComputadores.SelectedRows[0].Cells["Id"].Value);
                int clienteId = Convert.ToInt32(comboBoxClientes.SelectedValue);
                string computadorNome = dataGridViewComputadores.SelectedRows[0].Cells["Nome"].Value.ToString();
                string clienteNome = comboBoxClientes.Text;

                DialogResult confirmacao = MessageBox.Show(
                    $"Deseja iniciar sessão para:\n\n" +
                    $"Cliente: {clienteNome}\n" +
                    $"Computador: {computadorNome}",
                    "Confirmar Início de Sessão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacao == DialogResult.Yes)
                {
                    if (db.IniciarSessao(clienteId, computadorId))
                    {
                        MessageBox.Show("Sessão iniciada com sucesso! 🎮", "Sucesso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDados();
                        UpdateStatusStrip($"Sessão iniciada - {clienteNome} no {computadorNome}");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao iniciar a sessão. Tente novamente.", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar sessão: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinalizarSessao_Click(object sender, EventArgs e)
        {
            if (dataGridViewSessoes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma sessão ativa para finalizar!", "Atenção",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow selectedRow = dataGridViewSessoes.SelectedRows[0];
                int sessaoId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                string clienteNome = selectedRow.Cells["Cliente"].Value.ToString();
                string computadorNome = selectedRow.Cells["Computador"].Value.ToString();
                int minutosDecorridos = Convert.ToInt32(selectedRow.Cells["MinutosDecorridos"].Value);

                // Extrair ID do computador do nome (ex: "PC-01" -> ID 1)
                int computadorId = ExtractComputerIdFromName(computadorNome);

                TimeSpan tempoDecorrido = TimeSpan.FromMinutes(minutosDecorridos);
                string tempoFormatado = $"{tempoDecorrido.Hours}h {tempoDecorrido.Minutes}m";

                DialogResult confirmacao = MessageBox.Show(
                    $"Deseja finalizar a sessão?\n\n" +
                    $"Cliente: {clienteNome}\n" +
                    $"Computador: {computadorNome}\n" +
                    $"Tempo decorrido: {tempoFormatado}",
                    "Confirmar Finalização de Sessão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacao == DialogResult.Yes)
                {
                    if (db.FinalizarSessao(sessaoId, computadorId))
                    {
                        MessageBox.Show("Sessão finalizada com sucesso! 💰", "Sucesso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDados();
                        UpdateStatusStrip($"Sessão finalizada - {clienteNome}");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao finalizar a sessão. Tente novamente.", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar sessão: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ExtractComputerIdFromName(string computerName)
        {
            try
            {
                // Remove "PC-" e converte para número
                string idString = computerName.Replace("PC-", "");
                return Convert.ToInt32(idString);
            }
            catch
            {
                throw new Exception($"Não foi possível extrair o ID do computador do nome: {computerName}");
            }
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
               // using (FormCadastroCliente formCliente = new FormCadastroCliente())
                using (FormCadastro formCliente = new FormCadastro())

                {
                    DialogResult result = formCliente.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        CarregarDados(); // Recarrega a lista de clientes
                        UpdateStatusStrip("Novo cliente cadastrado com sucesso");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de cadastro: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizarComputadores_Click(object sender, EventArgs e)
        {
            CarregarDados();
            MessageBox.Show("Dados atualizados com sucesso! 🔄", "Atualização",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAtualizarSessoes_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable sessoes = db.GetSessoesAtivas();
                dataGridViewSessoes.DataSource = sessoes;
                UpdateStatusStrip($"Sessões atualizadas - {sessoes.Rows.Count} sessões ativas");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar sessões: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparCliente_Click(object sender, EventArgs e)
        {
            LimparCamposCliente();
        }

        private void LimparCamposCliente()
        {
            txtNomeCliente.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtEmailCliente.Text = "";
            txtNomeCliente.Focus();
        }

        // MENU ITEMS
        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SairAplicacao();
        }

        private void relatorioSessoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório de sessões será gerado aqui!\n\n" +
                          "Funcionalidade em desenvolvimento...", "Relatórios",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void relatorioClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório de clientes será gerado aqui!\n\n" +
                          "Funcionalidade em desenvolvimento...", "Relatórios",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "🏠 Sistema Lan House v2.0\n\n" +
                "Desenvolvido para gerenciamento completo de cyber café\n" +
                "© 2024 - Todos os direitos reservados\n\n" +
                "Funcionalidades:\n" +
                "• Controle de computadores\n" +
                "• Gestão de clientes\n" +
                "• Sistema de sessões\n" +
                "• Cálculo automático de valores",
                "Sobre o Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void timerAtualizar_Tick(object sender, EventArgs e)
        {
            // Atualiza a data/hora no status strip
            toolStripStatusLabelData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmação de Saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                // Limpar recursos
                timerSessoes?.Stop();
                timerSessoes?.Dispose();
            }
        }

        private void SairAplicacao()
        {
            DialogResult result = MessageBox.Show(
                "Deseja sair do sistema?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Eventos adicionais para melhor UX
        private void dataGridViewComputadores_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewComputadores.SelectedRows.Count > 0)
            {
                UpdateStatusStrip("Computador selecionado - Pronto para iniciar sessão");
            }
        }

        private void dataGridViewSessoes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSessoes.SelectedRows.Count > 0)
            {
                UpdateStatusStrip("Sessão selecionada - Pronto para finalizar");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    UpdateStatusStrip("Aba: Gerenciar Computadores");
                    break;
                case 1:
                    UpdateStatusStrip("Aba: Sessões Ativas");
                    AtualizarSessoesAutomaticamente();
                    break;
                case 2:
                    UpdateStatusStrip("Aba: Cadastrar Clientes");
                    break;
            }
        }
    }
}