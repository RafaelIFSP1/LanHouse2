using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanHouseSystem
{
    public partial class FormCadastroUsuario : Form
    {
        public FormCadastroUsuario()
        {
            InitializeComponent();
            // REMOVIDO o teste automático de conexão
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            // Testa conexão apenas quando for cadastrar
            if (!Database.TestarConexao())
            {
                MessageBox.Show("Não é possível cadastrar sem conexão com o banco.", "Sem Conexão");
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnCadastrar.Enabled = false;

            try
            {
                if (CadastrarUsuario())
                {
                    MessageBox.Show("✅ Usuário cadastrado com sucesso!", "Sucesso");
                    LimparCampos();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                btnCadastrar.Enabled = true;
            }
        }

        private bool CadastrarUsuario()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Database.ConnectionString))
                {
                    connection.Open();

                    // COMANDO SQL SIMPLES E DIRETO
                    string sql = @"INSERT INTO Usuarios (Nome, Email, Senha, TipoUsuario) 
                                 VALUES (@Nome, @Email, @Senha, 'Comum')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", txtNome.Text.Trim());
                        command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        command.Parameters.AddWithValue("@Senha", txtSenha.Text);

                        int linhasAfetadas = command.ExecuteNonQuery();

                        return linhasAfetadas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violação de chave única (email duplicado)
                {
                    MessageBox.Show("❌ Este email já está cadastrado!", "Erro");
                }
                else
                {
                    MessageBox.Show($"❌ Erro no banco de dados:\n{ex.Message}", "Erro");
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro inesperado:\n{ex.Message}", "Erro");
                return false;
            }
        }

        private bool ValidarCampos()
        {
            // Validar Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("📝 Por favor, digite o nome completo.", "Campo Obrigatório");
                txtNome.Focus();
                return false;
            }

            // Validar Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("📧 Por favor, digite o email.", "Campo Obrigatório");
                txtEmail.Focus();
                return false;
            }

            if (!IsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("📧 Por favor, digite um email válido.", "Email Inválido");
                txtEmail.Focus();
                return false;
            }

            // Validar Senha
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("🔑 Por favor, digite a senha.", "Campo Obrigatório");
                txtSenha.Focus();
                return false;
            }

            if (txtSenha.Text.Length < 6)
            {
                MessageBox.Show("🔑 A senha deve ter pelo menos 6 caracteres.", "Senha Fraca");
                txtSenha.Focus();
                return false;
            }

            // Validar Confirmação de Senha
            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("🔑 As senhas não coincidem!", "Erro de Confirmação");
                txtConfirmarSenha.Focus();
                return false;
            }

            return true;
        }

        private bool IsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
            txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // Navegação com Enter
        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtEmail.Focus();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtSenha.Focus();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtConfirmarSenha.Focus();
        }

        private void txtConfirmarSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnCadastrar.PerformClick();
        }
    }
}