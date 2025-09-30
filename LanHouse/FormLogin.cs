using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LanHouseSystem
{
    public partial class FormLogin : Form
    {
        private string connectionString = @"Data Source=sqlexpress;Initial Catalog=LanHouseDB;User ID=aluno;Password=aluno;";
        private int tentativasLogin = 0;
        private const int MAX_TENTATIVAS = 3;

        // DECLARE OS CONTROLES MANUALMENTE aqui também
        //private TextBox txtEmail;
        //private TextBox txtSenha;
        //private Button btnLogin;
        //private Button btnCadastrar;
        //private Button btnSair;
        //private LinkLabel linkEsqueciSenha;
        //private Label label1;
        //private Label label2;

        public FormLogin()
        {
            // Chame InitializeComponent() primeiro
            InitializeComponent();

            // AGORA configure os controles
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Configurações básicas do formulário
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Sistema Lan House - Login";

            // Verifique se os controles existem antes de configurar
            if (txtSenha != null)
            {
                txtSenha.PasswordChar = '*';
            }

            if (btnLogin != null)
            {
                btnLogin.BackColor = Color.Green;
                btnLogin.ForeColor = Color.White;
                btnLogin.Font = new Font("Arial", 9, FontStyle.Bold);
            }

            if (btnCadastrar != null)
            {
                btnCadastrar.BackColor = Color.Blue;
                btnCadastrar.ForeColor = Color.White;
                btnCadastrar.Font = new Font("Arial", 9, FontStyle.Bold);
            }

            if (btnSair != null)
            {
                btnSair.BackColor = Color.Red;
                btnSair.ForeColor = Color.White;
                btnSair.Font = new Font("Arial", 9, FontStyle.Bold);
            }
        }

        // MÉTODOS DE BANCO DE DADOS (mantenha iguais)
        private bool VerificarUsuarioExistente(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Usuarios WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar usuário: " + ex.Message, "Erro");
                return false;
            }
        }

        private string HashSenha(string senha)
        {
            using (System.Security.Cryptography.SHA256 sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerificarLogin(string email, string senha)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Senha", HashSenha(senha));

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar login: " + ex.Message, "Erro");
                return false;
            }
        }

        // EVENTOS
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail == null || txtSenha == null) return;

            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Atenção");
                return;
            }

            if (!VerificarUsuarioExistente(email))
            {
                DialogResult result = MessageBox.Show(
                    "Usuário não encontrado. Deseja cadastrar?",
                    "Novo usuário",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Funcionalidade de cadastro em desenvolvimento", "Em Breve");
                }
                return;
            }

            if (VerificarLogin(email, senha))
            {
                MessageBox.Show("LOGIN REALIZADO COM SUCESSO!", "Sucesso");

                FormPrincipal principal = new FormPrincipal();
                this.Hide();
                principal.ShowDialog();
                this.Close();
            }
            else
            {
                tentativasLogin++;
                MessageBox.Show("Senha incorreta! Tente novamente.", "Erro no Login");
                txtSenha.Text = "";
                txtSenha.Focus();

                if (tentativasLogin >= MAX_TENTATIVAS)
                {
                    MessageBox.Show("Número máximo de tentativas excedido!", "Acesso Bloqueado");
                    Application.Exit();
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade de cadastro em desenvolvimento", "Em Breve");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Tem certeza que deseja sair?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkEsqueciSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtEmail == null) return;

            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Digite seu email para recuperar a senha.", "Atenção");
                return;
            }

            if (VerificarUsuarioExistente(email))
            {
                MessageBox.Show("Entre em contato com o administrador para redefinir sua senha.", "Recuperar Senha");
            }
            else
            {
                MessageBox.Show("Email não cadastrado no sistema.", "Usuário não encontrado");
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Código de inicialização
        }
    }
}