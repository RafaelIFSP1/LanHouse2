using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using LanHouseSystem;
using System.ComponentModel;

namespace SeuProjeto
{
    public partial class FormLogin : Form
    {
        public static string UsuarioLogado { get; private set; }
        public static string EmailLogado { get; private set; }
        public static bool IsAdmin { get; private set; }
        public static int UsuarioId { get; private set; }

        // Controles do formulário
        private TextBox txtEmail;
        private TextBox txtSenha;
        private Button btnLogin;
        private Button btnCancelar;
        private LinkLabel linkCadastrar;
        private Label lblEmail;
        private Label lblSenha;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblSenha = new Label();
            this.txtSenha = new TextBox();
            this.btnLogin = new Button();
            this.btnCancelar = new Button();
            this.linkCadastrar = new LinkLabel();

            SuspendLayout();

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(30, 30);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(39, 15);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new Point(30, 48);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(250, 23);
            this.txtEmail.TabIndex = 1;

            // lblSenha
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new Point(30, 85);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new Size(42, 15);
            this.lblSenha.TabIndex = 2;
            this.lblSenha.Text = "Senha:";

            // txtSenha
            this.txtSenha.Location = new Point(30, 103);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new Size(250, 23);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.KeyPress += new KeyPressEventHandler(txtSenha_KeyPress);

            // btnLogin
            this.btnLogin.Location = new Point(30, 145);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(120, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new EventHandler(btnLogin_Click);

            // btnCancelar
            this.btnCancelar.Location = new Point(160, 145);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(120, 35);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);

            // linkCadastrar
            this.linkCadastrar.AutoSize = true;
            this.linkCadastrar.Location = new Point(30, 195);
            this.linkCadastrar.Name = "linkCadastrar";
            this.linkCadastrar.Size = new Size(184, 15);
            this.linkCadastrar.TabIndex = 5;
            this.linkCadastrar.TabStop = true;
            this.linkCadastrar.Text = "Não tem conta? Cadastre-se aqui";
            this.linkCadastrar.LinkClicked += new LinkLabelLinkClickedEventHandler(linkCadastrar_LinkClicked);

            // FormLogin
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(320, 230);
            this.Controls.Add(linkCadastrar);
            this.Controls.Add(btnCancelar);
            this.Controls.Add(btnLogin);
            this.Controls.Add(txtSenha);
            this.Controls.Add(lblSenha);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblEmail);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login - Sistema LanHouse";

            ResumeLayout(false);
            PerformLayout();
        }

        private bool ValidarLogin(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // AGORA SÓ USA O BANCO DE DADOS - SEM ADMIN FIXO
            try
            {
                if (ValidarUsuarioBanco(email, senha))
                {
                    string tipoUsuario = IsAdmin ? "Administrador" : "Usuário";
                    MessageBox.Show($"Bem-vindo, {UsuarioLogado}!", "Login Bem-sucedido",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                connection.Open();

                // Consulta para buscar o usuário
                string query = @"SELECT id, nome, email, senha, nivel_acesso 
                               FROM usuarios 
                               WHERE email = @Email AND ativo = 1";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lê os dados do banco
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string nome = reader["nome"].ToString();
                            string senhaBanco = reader["senha"].ToString();
                            string nivelAcesso = reader["nivel_acesso"].ToString();

                            // DEBUG: Mostra o que está vindo do banco
                            Console.WriteLine($"Email: {email}");
                            Console.WriteLine($"Senha digitada: {senha}");
                            Console.WriteLine($"Senha banco: {senhaBanco}");
                            Console.WriteLine($"São iguais? {senha == senhaBanco}");

                            // Verifica se a senha corresponde (comparação direta)
                            if (senha.Trim() == senhaBanco.Trim())
                            {
                                UsuarioLogado = nome;
                                EmailLogado = email;
                                IsAdmin = (nivelAcesso.ToLower() == "admin");
                                UsuarioId = id;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        // Método para DEBUG - Verificar o que tem no banco
        private void DebugUsuarios()
        {
            try
            {
                using (var connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT id, nome, email, senha, nivel_acesso FROM usuarios WHERE ativo = 1";

                    using (var cmd = new SqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        string debugInfo = "DEBUG - Usuários no banco:\n\n";
                        while (reader.Read())
                        {
                            debugInfo += $"ID: {reader["id"]}\n";
                            debugInfo += $"Nome: {reader["nome"]}\n";
                            debugInfo += $"Email: {reader["email"]}\n";
                            debugInfo += $"Senha: {reader["senha"]}\n";
                            debugInfo += $"Tipo: {reader["nivel_acesso"]}\n";
                            debugInfo += "------------------------\n";
                        }
                        MessageBox.Show(debugInfo, "DEBUG");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no DEBUG: {ex.Message}", "DEBUG");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            // DEBUG: Descomente a linha abaixo para ver o que tem no banco
            // DebugUsuarios();

            if (ValidarLogin(email, senha))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
            FormCadastroUsuario formCadastro = new FormCadastroUsuario();
            formCadastro.ShowDialog();
        }

            // Atualiza os campos após cadastro (opcional)
           
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private IContainer components = null;
    }
}