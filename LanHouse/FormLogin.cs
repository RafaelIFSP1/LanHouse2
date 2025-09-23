using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanHouse
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Teste simples de conexão primeiro
                using (SqlConnection conexao = Database.GetConnection())
                {
                    conexao.Open();
                    MessageBox.Show("✅ Conexão com banco OK!", "Sucesso");
                    conexao.Close();
                }

                // Agora testa o login
                string email = txtEmail.Text;
                string senha = txtSenha.Text;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                {
                    MessageBox.Show("Preencha email e senha!");
                    return;
                }

                using (SqlConnection conexao = Database.GetConnection())
                {
                    conexao.Open();
                    string sql = "SELECT Nome FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Senha", senha);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string nome = result.ToString();
                            MessageBox.Show($"Bem-vindo, {nome}!", "Login OK");

                            // Abre o form principal
                            FormPrincipal formPrincipal = new FormPrincipal();
                            formPrincipal.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Email ou senha incorretos!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Abre form de cadastro
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.ShowDialog();
        }
    }
}