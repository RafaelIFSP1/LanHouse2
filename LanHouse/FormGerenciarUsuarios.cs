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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.btnNovoUsuario = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnDesativarUsuario = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
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
            this.groupBox1.Text = "Lista de Usuários";
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
            // btnNovoUsuario
            // 
            this.btnNovoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNovoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNovoUsuario.ForeColor = System.Drawing.Color.White;
            this.btnNovoUsuario.Location = new System.Drawing.Point(450, 430);
            this.btnNovoUsuario.Name = "btnNovoUsuario";
            this.btnNovoUsuario.Size = new System.Drawing.Size(140, 40);
            this.btnNovoUsuario.TabIndex = 2;
            this.btnNovoUsuario.Text = "➕ NOVO USUÁRIO";
            this.btnNovoUsuario.UseVisualStyleBackColor = false;
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEditarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnEditarUsuario.Location = new System.Drawing.Point(600, 430);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(140, 40);
            this.btnEditarUsuario.TabIndex = 3;
            this.btnEditarUsuario.Text = "✏️ EDITAR";
            this.btnEditarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnDesativarUsuario
            // 
            this.btnDesativarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDesativarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesativarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDesativarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnDesativarUsuario.Location = new System.Drawing.Point(750, 430);
            this.btnDesativarUsuario.Name = "btnDesativarUsuario";
            this.btnDesativarUsuario.Size = new System.Drawing.Size(140, 40);
            this.btnDesativarUsuario.TabIndex = 4;
            this.btnDesativarUsuario.Text = "🚫 DESATIVAR";
            this.btnDesativarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(300, 430);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 40);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "🔙 VOLTAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            // 
            // FormGerenciarUsuarios
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNovoUsuario);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.btnDesativarUsuario);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormGerenciarUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "👥 Gerenciar Usuários - Lan House System";
            this.Load += new System.EventHandler(this.FormGerenciarUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);

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

        private void FormGerenciarUsuarios_Load(object sender, EventArgs e)
        {

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