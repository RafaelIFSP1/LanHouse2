using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace lanhause
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Debug.WriteLine("RAFAEL FRANCISCO DE LIMA DA SILVA");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Remove a mensagem de desenvolvimento agora que o banco está funcionando
            // MessageBox.Show("Modo de desenvolvimento - Verificação de banco desativada",
            //               "Info",
            //               MessageBoxButtons.OK,
            //               MessageBoxIcon.Information);

            // Loop principal da aplicação
            while (true)
            {
                using (FormLogin loginForm = new FormLogin())
                {
                    // Se usuário cancelou o login
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        if (MessageBox.Show("Deseja sair do sistema?", "Confirmação",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            break; // Sai do aplicativo
                        }
                        // Se escolheu "Não", continua no loop (volta para o login)
                    }
                    else // Login bem sucedido
                    {
                        // Abre o formulário principal
                        using (FormPrincipal formPrincipal = new FormPrincipal())
                        {
                            Application.Run(formPrincipal);

                            // Quando o FormPrincipal é fechado, volta para a tela de login
                            // Se quiser que o aplicativo feche completamente quando o
                            // FormPrincipal for fechado, adicione "break;" aqui
                        }
                    }
                }
            }
        }
    }
}