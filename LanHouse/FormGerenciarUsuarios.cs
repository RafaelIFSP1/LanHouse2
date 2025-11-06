using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public class FormGerenciarUsuarios : Form
    {
        private DataGridView dataGridViewUsuarios;
        private Button btnNovoUsuario, btnEditarUsuario, btnDesativarUsuario, btnFechar, btnAtualizar;
        private Label lblTitulo;
        private GroupBox groupBox1;
        private TextBox txtPesquisar;
        private Label lblPesquisar;

        public FormGerenciarUsuarios()
        {
            InitializeComponent();
            CarregarUsuarios();
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.btnNovoUsuario = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnDesativarUsuario = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "👥 GERENCIAR USUÁRIOS";

            // lblPesquisar
            this.lblPesquisar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.Location = new System.Drawing.Point(550, 25);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(70, 20);
            this.lblPesquisar.TabIndex = 1;
            this.lblPesquisar.Text = "Pesquisar:";

            // txtPesquisar
            this.txtPesquisar.Location = new System.Drawing.Point(625, 23);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(245, 20);
            this.txtPesquisar.TabIndex = 2;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);

            // groupBox1
            this.groupBox1.Controls.Add(this.dataGridViewUsuarios);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 350);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Usuários";

            // dataGridViewUsuarios
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(20, 25);
            this.dataGridViewUsuarios.MultiSelect = false;
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.RowHeadersVisible = false;
            this.dataGridViewUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(810, 300);
            this.dataGridViewUsuarios.TabIndex = 0;
            this.dataGridViewUsuarios.SelectionChanged += new System.EventHandler(this.dataGridViewUsuarios_SelectionChanged);

            // btnNovoUsuario
            this.btnNovoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNovoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNovoUsuario.ForeColor = System.Drawing.Color.White;
            this.btnNovoUsuario.Location = new System.Drawing.Point(290, 430);
            this.btnNovoUsuario.Name = "btnNovoUsuario";
            this.btnNovoUsuario.Size = new System.Drawing.Size(160, 40);
            this.btnNovoUsuario.TabIndex = 4;
            this.btnNovoUsuario.Text = "➕ NOVO USUÁRIO";
            this.btnNovoUsuario.UseVisualStyleBackColor = false;
            this.btnNovoUsuario.Click += new System.EventHandler(this.btnNovoUsuario_Click);

            // btnEditarUsuario
            this.btnEditarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEditarUsuario.Enabled = false;
            this.btnEditarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnEditarUsuario.Location = new System.Drawing.Point(460, 430);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(140, 40);
            this.btnEditarUsuario.TabIndex = 5;
            this.btnEditarUsuario.Text = "✏️ EDITAR";
            this.btnEditarUsuario.UseVisualStyleBackColor = false;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);

            // btnDesativarUsuario
            this.btnDesativarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDesativarUsuario.Enabled = false;
            this.btnDesativarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesativarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDesativarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnDesativarUsuario.Location = new System.Drawing.Point(610, 430);
            this.btnDesativarUsuario.Name = "btnDesativarUsuario";
            this.btnDesativarUsuario.Size = new System.Drawing.Size(140, 40);
            this.btnDesativarUsuario.TabIndex = 6;
            this.btnDesativarUsuario.Text = "🚫 DESATIVAR";
            this.btnDesativarUsuario.UseVisualStyleBackColor = false;
            this.btnDesativarUsuario.Click += new System.EventHandler(this.btnDesativarUsuario_Click);

            // btnAtualizar
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(760, 430);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(110, 40);
            this.btnAtualizar.TabIndex = 7;
            this.btnAtualizar.Text = "🔄 ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);

            // btnFechar
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(20, 430);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 40);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "🔙 VOLTAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // FormGerenciarUsuarios
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 491);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNovoUsuario);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.btnDesativarUsuario);
            this.Controls.Add(this.btnAtualizar);
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
            this.PerformLayout();
        }

        private void CarregarUsuarios()
        {
            try
            {
                DataTable dt = DatabaseHelper.ObterTodosUsuarios();
                dataGridViewUsuarios.DataSource = dt;

                // Configurar colunas
                if (dataGridViewUsuarios.Columns.Count > 0)
                {
                    dataGridViewUsuarios.Columns["Id"].Width = 50;
                    dataGridViewUsuarios.Columns["Nome"].Width = 200;
                    dataGridViewUsuarios.Columns["Email"].Width = 200;
                    dataGridViewUsuarios.Columns["TipoUsuario"].Width = 120;
                    dataGridViewUsuarios.Columns["Status"].Width = 100;
                    dataGridViewUsuarios.Columns["DataCadastro"].Width = 100;

                    dataGridViewUsuarios.Columns["TipoUsuario"].HeaderText = "TIPO";
                    dataGridViewUsuarios.Columns["DataCadastro"].HeaderText = "CADASTRO";
                }

                AtualizarTitulo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTitulo()
        {
            int total = dataGridViewUsuarios.Rows.Count;
            lblTitulo.Text = $"👥 GERENCIAR USUÁRIOS ({total} cadastrado{(total != 1 ? "s" : "")})";
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            using (var form = new FormCadastro())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CarregarUsuarios();
                    MessageBox.Show("✅ Usuário cadastrado com sucesso!", "Sucesso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Selecione um usuário para editar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
            MessageBox.Show($"✏️ Funcionalidade de edição em desenvolvimento.\n\nUsuário: {nome}",
                          "Em Desenvolvimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDesativarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Selecione um usuário para desativar/reativar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewUsuarios.CurrentRow.Cells["Id"].Value);
            string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
            string email = dataGridViewUsuarios.CurrentRow.Cells["Email"].Value.ToString();
            string statusAtual = dataGridViewUsuarios.CurrentRow.Cells["Status"].Value.ToString();

            // Não permite desativar o admin principal
            if (email.ToLower() == "admin@gmail.com")
            {
                MessageBox.Show("❌ O usuário administrador principal não pode ser desativado!",
                              "Operação Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool estaAtivo = statusAtual.Contains("ATIVO");
            string acao = estaAtivo ? "desativar" : "reativar";

            var result = MessageBox.Show(
                $"Confirmar {acao} usuário?\n\nNome: {nome}\nEmail: {email}",
                $"Confirmar {acao.ToUpper()}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (DatabaseHelper.AlterarStatusUsuario(id, !estaAtivo))
                {
                    CarregarUsuarios();
                    MessageBox.Show($"✅ Usuário {(estaAtivo ? "desativado" : "reativado")} com sucesso!",
                                  "Operação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.DataSource is DataTable dt)
            {
                string filtro = txtPesquisar.Text.Trim();

                if (string.IsNullOrEmpty(filtro))
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    dt.DefaultView.RowFilter = $"Nome LIKE '%{filtro}%' OR Email LIKE '%{filtro}%'";
                }
            }
        }

        private void dataGridViewUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            bool temSelecao = dataGridViewUsuarios.CurrentRow != null;
            btnEditarUsuario.Enabled = temSelecao;
            btnDesativarUsuario.Enabled = temSelecao;

            if (temSelecao)
            {
                string statusAtual = dataGridViewUsuarios.CurrentRow.Cells["Status"].Value.ToString();
                bool estaAtivo = statusAtual.Contains("ATIVO");
                btnDesativarUsuario.Text = estaAtivo ? "🚫 DESATIVAR" : "✅ REATIVAR";
            }
        }

        private void FormGerenciarUsuarios_Load(object sender, EventArgs e)
        {
            // Configuração inicial já feita no construtor
        }
    }
}