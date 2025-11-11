using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lanhause
{
    public partial class FormLogin : Form
    {
        public static string UsuarioLogado { get; private set; }
        public static string EmailLogado { get; private set; }
        public static bool IsAdmin { get; private set; }
        public static int UsuarioId { get; private set; }
        public static string TipoUsuarioLogado { get; private set; } // NOVA PROPRIEDADE

        // STRING DE CONEXÃO CORRIGIDA - mesma do cadastro
        string conexao = "Data Source=sqlexpress;Initial Catalog=CJ3027287PR2;User ID=aluno;Password=aluno;";

        // Componentes do Windows Forms
        private TextBox txtEmail;
        private TextBox txtSenha;
        private Button btnLogin;
        private Button btnCancelar;
        private LinkLabel linkCadastrar;
        private Label label1;
        private Label label2;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.linkCadastrar = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(120, 50);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 0;

            // txtSenha
            this.txtSenha.Location = new System.Drawing.Point(120, 90);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(200, 20);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(120, 130);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(95, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "✅ ENTRAR";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnCancelar
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(225, 130);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "❌ CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // linkCadastrar
            this.linkCadastrar.AutoSize = true;
            this.linkCadastrar.Location = new System.Drawing.Point(120, 180);
            this.linkCadastrar.Name = "linkCadastrar";
            this.linkCadastrar.Size = new System.Drawing.Size(200, 13);
            this.linkCadastrar.TabIndex = 4;
            this.linkCadastrar.TabStop = true;
            this.linkCadastrar.Text = "📝 Não tem conta? Cadastre-se aqui!";
            this.linkCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkCadastrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCadastrar_LinkClicked);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Email:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Senha:";

            // FormLogin
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkCadastrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🔐 Login - Sistema LanHouse";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            if (ValidarLogin(email, senha))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidarLogin(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                if (ValidarUsuarioBanco(email, senha))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Email ou senha inválidos!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar com o banco: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidarUsuarioBanco(string email, string senha)
        {
            using (var connection = new SqlConnection(conexao))
            {
                connection.Open();

                string query = @"SELECT Id, Nome, Email, Senha, TipoUsuario 
                               FROM Usuarios 
                               WHERE Email = @Email AND Ativo = 1";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string nome = reader["Nome"].ToString();
                            string senhaBanco = reader["Senha"].ToString();
                            string tipoUsuario = reader["TipoUsuario"].ToString();

                            if (senha == senhaBanco)
                            {
                                UsuarioLogado = nome;
                                EmailLogado = email;
                                TipoUsuarioLogado = tipoUsuario; // ARMAZENA O TIPO DE USUÁRIO
                                IsAdmin = (tipoUsuario.ToLower() == "administrador");
                                UsuarioId = id;

                                MessageBox.Show($"✅ Login realizado com sucesso!\n\n" +
                                              $"Bem-vindo, {UsuarioLogado}!\n" +
                                              $"Tipo: {(IsAdmin ? "Administrador" : "Usuário Comum")}",
                                              "Login Bem-sucedido",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Information);

                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter
            {
                btnLogin_Click(sender, e);
            }
        }

        private void linkCadastrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.ShowDialog();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Para teste rápido, preenche automaticamente com o email do admin
            txtEmail.Text = "admin@gmail.com";
            txtSenha.Text = "admin@123456";
            txtEmail.Focus();
        }
    }
}