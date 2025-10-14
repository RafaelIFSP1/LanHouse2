using System;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnDesativar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "👥 GERENCIAR USUÁRIOS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewUsuarios);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Usuários do Sistema";
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(20, 25);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.RowHeadersVisible = false;
            this.dataGridViewUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(810, 300);
            this.dataGridViewUsuarios.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(450, 430);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(140, 40);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "➕ ADICIONAR";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Location = new System.Drawing.Point(600, 430);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 40);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "✏️ EDITAR";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnDesativar
            // 
            this.btnDesativar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDesativar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesativar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDesativar.ForeColor = System.Drawing.Color.White;
            this.btnDesativar.Location = new System.Drawing.Point(750, 430);
            this.btnDesativar.Name = "btnDesativar";
            this.btnDesativar.Size = new System.Drawing.Size(140, 40);
            this.btnDesativar.TabIndex = 4;
            this.btnDesativar.Text = "🚫 DESATIVAR";
            this.btnDesativar.UseVisualStyleBackColor = false;
            this.btnDesativar.Click += new System.EventHandler(this.btnDesativar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(750, 430);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 40);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "🔙 VOLTAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormGerenciarUsuarios
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnDesativar);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormGerenciarUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "👥 Gerenciar Usuários - Lan House System";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        private void CarregarUsuarios()
        {
            dataGridViewUsuarios.Columns.Clear();

            dataGridViewUsuarios.Columns.Add("ID", "ID");
            dataGridViewUsuarios.Columns.Add("Nome", "NOME COMPLETO");
            dataGridViewUsuarios.Columns.Add("Email", "EMAIL");
            dataGridViewUsuarios.Columns.Add("Tipo", "TIPO DE USUÁRIO");
            dataGridViewUsuarios.Columns.Add("Status", "STATUS");

            dataGridViewUsuarios.Rows.Clear();

            dataGridViewUsuarios.Rows.Add(1, "Administrador Principal", "admin@lanhouse.com", "👑 ADMINISTRADOR", "🟢 ATIVO");
            dataGridViewUsuarios.Rows.Add(2, "João Silva", "joao.silva@email.com", "👤 USUÁRIO", "🟢 ATIVO");
            dataGridViewUsuarios.Rows.Add(3, "Maria Santos", "maria.santos@email.com", "👤 USUÁRIO", "🟢 ATIVO");
            dataGridViewUsuarios.Rows.Add(4, "Carlos Oliveira", "carlos@email.com", "👑 ADMINISTRADOR", "🔴 INATIVO");

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