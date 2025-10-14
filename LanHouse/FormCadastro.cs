using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string conexao = "Data Source=sqlexpress;Initial Catalog=CJ3027287PR2;User ID=aluno;Password=aluno;";

            Cursor = Cursors.WaitCursor;
            btnCadastrar.Enabled = false;

            try
            {
                if (CadastrarUsuario(conexao))
                {
                    MessageBox.Show("✅ Usuário cadastrado com sucesso!", "Sucesso",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    // FECHA O FORMULÁRIO DIRETAMENTE APÓS CADASTRAR
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                btnCadastrar.Enabled = true;
            }
        }

        private bool CadastrarUsuario(string conexao)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    connection.Open();

                    // VERIFICA SE A TABELA EXISTE
                    string verificarTabela = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios')
                        BEGIN
                            CREATE TABLE Usuarios (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                Nome NVARCHAR(100) NOT NULL,
                                Email NVARCHAR(100) UNIQUE NOT NULL,
                                Senha NVARCHAR(100) NOT NULL,
                                TipoUsuario NVARCHAR(20) DEFAULT 'Comum',
                                DataCadastro DATETIME DEFAULT GETDATE(),
                                Ativo BIT DEFAULT 1
                            )
                        END";

                    using (SqlCommand cmdVerificar = new SqlCommand(verificarTabela, connection))
                    {
                        cmdVerificar.ExecuteNonQuery();
                    }

                    // INSERE O USUÁRIO
                    string sql = @"INSERT INTO Usuarios (Nome, Email, Senha, TipoUsuario) 
                                 VALUES (@Nome, @Email, @Senha, 'Comum')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", txtNome.Text.Trim());
                        command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim().ToLower());
                        command.Parameters.AddWithValue("@Senha", txtSenha.Text);

                        int linhasAfetadas = command.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // VIOLAÇÃO DE CHAVE ÚNICA (EMAIL DUPLICADO)
                {
                    MessageBox.Show("❌ Este email já está cadastrado no sistema!",
                                  "Email Duplicado",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                }
                else
                {
                    MessageBox.Show($"❌ Erro no banco de dados:\n{ex.Message}",
                                  "Erro SQL",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro inesperado:\n{ex.Message}",
                              "Erro",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidarCampos()
        {
            // Validação do Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("📝 Por favor, digite o nome completo.",
                              "Campo Obrigatório",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (txtNome.Text.Trim().Length < 3)
            {
                MessageBox.Show("📝 O nome deve ter pelo menos 3 caracteres.",
                              "Nome Inválido",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            // Validação do Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("📧 Por favor, digite o email.",
                              "Campo Obrigatório",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("📧 Por favor, digite um email válido.\nExemplo: usuario@exemplo.com",
                              "Email Inválido",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validação da Senha
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("🔑 Por favor, digite a senha.",
                              "Campo Obrigatório",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }

            if (txtSenha.Text.Length < 6)
            {
                MessageBox.Show("🔑 A senha deve ter pelo menos 6 caracteres.",
                              "Senha Fraca",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }

            // Validação da Confirmação de Senha
            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("🔑 As senhas não coincidem!",
                              "Erro de Confirmação",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                txtConfirmarSenha.Focus();
                txtConfirmarSenha.SelectAll();
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

        // Navegação com Enter entre campos
        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirmarSenha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtConfirmarSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCadastrar.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                Color.LightGray, 1, ButtonBorderStyle.Solid,
                Color.LightGray, 1, ButtonBorderStyle.Solid,
                Color.LightGray, 1, ButtonBorderStyle.Solid,
                Color.LightGray, 1, ButtonBorderStyle.Solid);
        }
    }
}