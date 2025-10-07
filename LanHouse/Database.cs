using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanHouseSystem
{
    public static class Database
    {
        public static string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=LanHouseDB;Integrated Security=true;TrustServerCertificate=true;";

        public static bool TestarConexao()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na conexão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}