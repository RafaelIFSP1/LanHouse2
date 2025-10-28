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

        // STRING DE CONEXÃO CORRIGIDA - mesma do cadastro
        string conexao = "Data Source=sqlexpress;Initial Catalog=CJ3027287PR2;User ID=aluno;Password=aluno;";

        public FormLogin()
        {
            InitializeComponent();
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

                                // CORREÇÃO AQUI: Verificar se é "Administrador" (com A maiúsculo)
                                IsAdmin = (tipoUsuario.ToLower() == "administrador");
                                UsuarioId = id;

                                // Mostrar mensagem de sucesso
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