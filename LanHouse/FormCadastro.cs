using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanHouse
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            try
            {
                using (SqlConnection conexao = Database.GetConnection())
                {
                    conexao.Open();
                    string sql = "INSERT INTO Usuarios (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";

                    using (SqlCommand cmd = new SqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Senha", senha);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cadastro realizado com sucesso!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}