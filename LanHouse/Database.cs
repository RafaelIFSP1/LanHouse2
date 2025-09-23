using System.Data.SqlClient;

namespace LanHouse
{
    public class Database
    {
        public static string connectionString =
            @"Data Source=sqlexpress;Initial Catalog=CJ3027287PR2;User ID=aluno;Password=aluno;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}