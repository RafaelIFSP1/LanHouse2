using System;
using System.Windows.Forms;

namespace LanHouseSystem
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Para usar com Login (quando tiver o FormLogin):
            // Application.Run(new FormLogin());

            // Para usar DIRETO no FormPrincipal (sem login):
            Application.Run(new FormPrincipal());
        }
    }
}