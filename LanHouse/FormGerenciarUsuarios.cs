using System;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public class FormGerenciarUsuarios : Form
    {
        private DataGridView dataGridViewUsuarios;
        private Button btnNovoUsuario, btnEditarUsuario, btnDesativarUsuario, btnFechar;
        private Label lblTitulo;
        private GroupBox groupBox1;

        public FormGerenciarUsuarios()
        {
            InitializeComponent();
            CarregarUsuarios();
        }

        private void InitializeComponent()
        {
            // Configuração básica do form
            this.Text = "👥 Gerenciar Usuários - Lan House System";
            this.Size = new Size(900, 500);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label título
            lblTitulo = new Label();
            lblTitulo.Text = "👥 GERENCIAR USUÁRIOS";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(23, 162, 184);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(350, 30);
            this.Controls.Add(lblTitulo);

            // GroupBox
            groupBox1 = new GroupBox();
            groupBox1.Text = "Lista de Usuários";
            groupBox1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            groupBox1.Location = new Point(20, 60);
            groupBox1.Size = new Size(850, 350);
            this.Controls.Add(groupBox1);

            // DataGridView
            dataGridViewUsuarios = new DataGridView();
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsuarios.BackgroundColor = Color.White;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(20, 25);
            dataGridViewUsuarios.Size = new Size(810, 300);
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.RowHeadersVisible = false;
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBox1.Controls.Add(dataGridViewUsuarios);

            // Botões
            btnNovoUsuario = new Button();
            btnNovoUsuario.Text = "➕ NOVO USUÁRIO";
            btnNovoUsuario.BackColor = Color.FromArgb(40, 167, 69);
            btnNovoUsuario.FlatStyle = FlatStyle.Flat;
            btnNovoUsuario.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnNovoUsuario.ForeColor = Color.White;
            btnNovoUsuario.Location = new Point(450, 430);
            btnNovoUsuario.Size = new Size(140, 40);
            btnNovoUsuario.Click += btnNovoUsuario_Click;
            this.Controls.Add(btnNovoUsuario);

            btnEditarUsuario = new Button();
            btnEditarUsuario.Text = "✏️ EDITAR";
            btnEditarUsuario.BackColor = Color.FromArgb(255, 193, 7);
            btnEditarUsuario.FlatStyle = FlatStyle.Flat;
            btnEditarUsuario.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnEditarUsuario.ForeColor = Color.Black;
            btnEditarUsuario.Location = new Point(600, 430);
            btnEditarUsuario.Size = new Size(140, 40);
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            this.Controls.Add(btnEditarUsuario);

            btnDesativarUsuario = new Button();
            btnDesativarUsuario.Text = "🚫 DESATIVAR";
            btnDesativarUsuario.BackColor = Color.FromArgb(220, 53, 69);
            btnDesativarUsuario.FlatStyle = FlatStyle.Flat;
            btnDesativarUsuario.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDesativarUsuario.ForeColor = Color.White;
            btnDesativarUsuario.Location = new Point(750, 430);
            btnDesativarUsuario.Size = new Size(140, 40);
            btnDesativarUsuario.Click += btnDesativarUsuario_Click;
            this.Controls.Add(btnDesativarUsuario);

            btnFechar = new Button();
            btnFechar.Text = "🔙 VOLTAR";
            btnFechar.BackColor = Color.FromArgb(108, 117, 125);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(300, 430);
            btnFechar.Size = new Size(120, 40);
            btnFechar.Click += btnFechar_Click;
            this.Controls.Add(btnFechar);
        }

        private void CarregarUsuarios()
        {
            dataGridViewUsuarios.Columns.Clear();
            dataGridViewUsuarios.Columns.Add("ID", "ID");
            dataGridViewUsuarios.Columns.Add("Nome", "NOME");
            dataGridViewUsuarios.Columns.Add("Email", "E-MAIL");
            dataGridViewUsuarios.Columns.Add("Tipo", "TIPO USUÁRIO");
            dataGridViewUsuarios.Columns.Add("Status", "STATUS");

            dataGridViewUsuarios.Rows.Clear();
            dataGridViewUsuarios.Rows.Add("USR-001", "Administrador", "admin@lanhouse.com", "Administrador", "🟢 ATIVO");
            dataGridViewUsuarios.Rows.Add("USR-002", "João Silva", "joao@email.com", "Cliente", "🟢 ATIVO");
            dataGridViewUsuarios.Rows.Add("USR-003", "Maria Santos", "maria@email.com", "Cliente", "🟢 ATIVO");
            dataGridViewUsuarios.Rows.Add("USR-004", "Pedro Costa", "pedro@email.com", "Cliente", "🔴 INATIVO");
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("➕ Funcionalidade: Novo Usuário\n\nAbrir formulário de cadastro de usuário...",
                          "Novo Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
                MessageBox.Show($"✏️ Editando usuário: {nome}",
                              "Editar Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um usuário para editar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDesativarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
                string statusAtual = dataGridViewUsuarios.CurrentRow.Cells["Status"].Value.ToString();
                string acao = statusAtual.Contains("ATIVO") ? "desativar" : "reativar";

                DialogResult result = MessageBox.Show(
                    $"Tem certeza que deseja {acao} o usuário {nome}?",
                    $"Confirmar {acao.ToUpper()}",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"✅ Usuário {nome} {acao} com sucesso!",
                                  "Operação Concluída",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um usuário para desativar/reativar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}