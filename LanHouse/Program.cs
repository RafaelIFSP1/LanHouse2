using System;
using System.Windows.Forms;
using SeuProjeto;

namespace LanHouseSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Testa conexão com banco
                if (!Database.TestarConexao())
                {
                    MessageBox.Show("Erro ao conectar com o banco de dados. A aplicação será fechada.",
                                  "Erro de Conexão",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // Loop de login
                while (true)
                {
                    using (FormLogin loginForm = new FormLogin())
                    {
                        if (loginForm.ShowDialog() == DialogResult.OK)
                        {
                            // Login bem-sucedido - cria usuário e abre FormPrincipal
                            Usuario usuarioLogado = new Usuario
                            {
                                Id = FormLogin.UsuarioId,
                                Nome = FormLogin.UsuarioLogado,
                                Email = FormLogin.EmailLogado,
                                TipoUsuario = FormLogin.IsAdmin ? "Admin" : "Usuario"
                            };

                            // Abre o FormPrincipal
                            FormPrincipal formPrincipal = new FormPrincipal(usuarioLogado);
                            Application.Run(formPrincipal);
                            break;
                        }
                        else
                        {
                            // Usuário cancelou
                            if (MessageBox.Show("Deseja sair do sistema?", "Confirmação",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar a aplicação: {ex.Message}",
                              "Erro",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
    }
}