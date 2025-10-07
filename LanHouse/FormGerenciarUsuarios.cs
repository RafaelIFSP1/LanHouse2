using System;
using System.Drawing;
using System.Windows.Forms;

namespace LanHouseSystem
{
    public partial class FormGerenciarUsuarios : Form
    {
        private DataGridView dataGridViewUsuarios;
        private Button btnAdicionar;
        private Button btnEditar;
        private Button btnDesativar;
        private Button btnFechar;
        private Label lblTitulo;
        private GroupBox groupBox1;

        public FormGerenciarUsuarios()
        {
            InitializeComponent();
            CarregarUsuarios();
        }

        private void InitializeComponent()
        {
            this.Text = "👥 Gerenciar Usuários - Lan House System";
            this.Size = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // lblTitulo
            lblTitulo = new Label();
            lblTitulo.Text = "👥 GERENCIAR USUÁRIOS";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(220, 53, 69);
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.Location = new Point(20, 20);
            this.Controls.Add(lblTitulo);

            // groupBox1
            groupBox1 = new GroupBox();
            groupBox1.Text = "Lista de Usuários do Sistema";
            groupBox1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            groupBox1.Size = new Size(850, 350);
            groupBox1.Location = new Point(20, 60);
            this.Controls.Add(groupBox1);

            // dataGridViewUsuarios
            dataGridViewUsuarios = new DataGridView();
            dataGridViewUsuarios.Size = new Size(810, 300);
            dataGridViewUsuarios.Location = new Point(20, 25);
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.RowHeadersVisible = false;
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsuarios.BackgroundColor = Color.White;

            // Configurar colunas
            dataGridViewUsuarios.Columns.Add("ID", "ID");
            dataGridViewUsuarios.Columns.Add("Nome", "NOME COMPLETO");
            dataGridViewUsuarios.Columns.Add("Email", "EMAIL");
            dataGridViewUsuarios.Columns.Add("Tipo", "TIPO DE USUÁRIO");
            dataGridViewUsuarios.Columns.Add("Status", "STATUS");

            groupBox1.Controls.Add(dataGridViewUsuarios);

            // btnAdicionar
            btnAdicionar = new Button();
            btnAdicionar.Text = "➕ ADICIONAR";
            btnAdicionar.Size = new Size(140, 40);
            btnAdicionar.Location = new Point(450, 430);
            btnAdicionar.BackColor = Color.FromArgb(40, 167, 69);
            btnAdicionar.ForeColor = Color.White;
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdicionar.Click += btnAdicionar_Click;
            this.Controls.Add(btnAdicionar);

            // btnEditar
            btnEditar = new Button();
            btnEditar.Text = "✏️ EDITAR";
            btnEditar.Size = new Size(140, 40);
            btnEditar.Location = new Point(600, 430);
            btnEditar.BackColor = Color.FromArgb(255, 193, 7);
            btnEditar.ForeColor = Color.Black;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnEditar.Click += btnEditar_Click;
            this.Controls.Add(btnEditar);

            // btnDesativar
            btnDesativar = new Button();
            btnDesativar.Text = "🚫 DESATIVAR";
            btnDesativar.Size = new Size(140, 40);
            btnDesativar.Location = new Point(750, 430);
            btnDesativar.BackColor = Color.FromArgb(220, 53, 69);
            btnDesativar.ForeColor = Color.White;
            btnDesativar.FlatStyle = FlatStyle.Flat;
            btnDesativar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDesativar.Click += btnDesativar_Click;
            this.Controls.Add(btnDesativar);

            // btnFechar
            btnFechar = new Button();
            btnFechar.Text = "🔙 VOLTAR";
            btnFechar.Size = new Size(120, 40);
            btnFechar.Location = new Point(750, 430);
            btnFechar.BackColor = Color.FromArgb(108, 117, 125);
            btnFechar.ForeColor = Color.White;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnFechar.Click += btnFechar_Click;
            this.Controls.Add(btnFechar);
        }

        private void CarregarUsuarios()
        {
            dataGridViewUsuarios.Rows.Clear();

            // Usuários de exemplo
            dataGridViewUsuarios.Rows.Add(1, "Administrador Principal", "admin@lanhouse.com", "👑 ADMINISTRADOR", "🟢 ATIVO");
            dataGridViewUsuarios.Rows.Add(2, "João Silva", "joao.silva@email.com", "👤 USUÁRIO", "🟢 ATIVO");
            dataGridViewUsuarios.Rows.Add(3, "Maria Santos", "maria.santos@email.com", "👤 USUÁRIO", "🟢 ATIVO");
            dataGridViewUsuarios.Rows.Add(4, "Carlos Oliveira", "carlos@email.com", "👑 ADMINISTRADOR", "🔴 INATIVO");

            // Colorir status e tipo
            foreach (DataGridViewRow row in dataGridViewUsuarios.Rows)
            {
                if (row.Cells["Status"].Value.ToString().Contains("ATIVO"))
                    row.Cells["Status"].Style.ForeColor = Color.Green;
                else
                    row.Cells["Status"].Style.ForeColor = Color.Red;

                if (row.Cells["Tipo"].Value.ToString().Contains("ADMIN"))
                    row.Cells["Tipo"].Style.ForeColor = Color.FromArgb(220, 53, 69);
                else
                    row.Cells["Tipo"].Style.ForeColor = Color.FromArgb(0, 123, 255);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("➕ Funcionalidade: Adicionar Novo Usuário\n\n" +
                          "Abrir formulário de cadastro de usuários...",
                          "Adicionar Usuário",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
                MessageBox.Show($"✏️ Editando usuário: {nome}",
                              "Editar Usuário",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um usuário para editar.",
                              "Seleção Necessária",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            }
        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
                string statusAtual = dataGridViewUsuarios.CurrentRow.Cells["Status"].Value.ToString();

                string novaAcao = statusAtual.Contains("ATIVO") ? "desativar" : "reativar";

                DialogResult result = MessageBox.Show(
                    $"Tem certeza que deseja {novaAcao} o usuário {nome}?",
                    $"Confirmar {novaAcao.ToUpper()}",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"✅ Usuário {nome} {novaAcao}do com sucesso!",
                                  "Operação Concluída",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    CarregarUsuarios();
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um usuário para desativar/reativar.",
                              "Seleção Necessária",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}