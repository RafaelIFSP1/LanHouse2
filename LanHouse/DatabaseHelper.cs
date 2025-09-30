using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanHouseSystem
{
    public class DatabaseHelper
    {
        private string connectionString = @"Data Source=sqlexpress;Initial Catalog=LanHouseDB;User ID=aluno;Password=aluno;";

        public DataTable GetComputadoresDisponiveis()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Computadores WHERE Disponivel = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar computadores: {ex.Message}");
            }
            return dt;
        }

        public DataTable GetClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Nome, CPF, Telefone FROM Clientes";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}");
            }
            return dt;
        }

        public bool IniciarSessao(int clienteId, int computadorId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Inicia sessão
                    string query = @"INSERT INTO Sessoes (ClienteId, ComputadorId, DataInicio, Ativo) 
                                   VALUES (@ClienteId, @ComputadorId, GETDATE(), 1);
                                   UPDATE Computadores SET Disponivel = 0 WHERE Id = @ComputadorId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                        cmd.Parameters.AddWithValue("@ComputadorId", computadorId);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar sessão: {ex.Message}");
                return false;
            }
        }

        public bool FinalizarSessao(int sessaoId, int computadorId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Calcula valor
                    string queryValor = @"SELECT DATEDIFF(MINUTE, DataInicio, GETDATE()) * (PrecoHora/60.0)
                                        FROM Sessoes s 
                                        INNER JOIN Computadores c ON s.ComputadorId = c.Id 
                                        WHERE s.Id = @SessaoId";

                    SqlCommand cmdValor = new SqlCommand(queryValor, conn);
                    cmdValor.Parameters.AddWithValue("@SessaoId", sessaoId);
                    decimal valorTotal = Convert.ToDecimal(cmdValor.ExecuteScalar());

                    // Finaliza sessão
                    string query = @"UPDATE Sessoes SET DataFim = GETDATE(), ValorTotal = @ValorTotal, Ativo = 0 
                                   WHERE Id = @SessaoId;
                                   UPDATE Computadores SET Disponivel = 1 WHERE Id = @ComputadorId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SessaoId", sessaoId);
                        cmd.Parameters.AddWithValue("@ComputadorId", computadorId);
                        cmd.Parameters.AddWithValue("@ValorTotal", valorTotal);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar sessão: {ex.Message}");
                return false;
            }
        }

        public DataTable GetSessoesAtivas()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT s.Id, c.Nome as Cliente, pc.Nome as Computador, s.DataInicio,
                                   DATEDIFF(MINUTE, s.DataInicio, GETDATE()) as MinutosDecorridos
                                   FROM Sessoes s
                                   INNER JOIN Clientes c ON s.ClienteId = c.Id
                                   INNER JOIN Computadores pc ON s.ComputadorId = pc.Id
                                   WHERE s.Ativo = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar sessões: {ex.Message}");
            }
            return dt;
        }

        public bool CadastrarCliente(string nome, string cpf, string telefone, string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Clientes (Nome, CPF, Telefone, Email) VALUES (@Nome, @CPF, @Telefone, @Email)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@CPF", cpf);
                        cmd.Parameters.AddWithValue("@Telefone", telefone);
                        cmd.Parameters.AddWithValue("@Email", email);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar cliente: {ex.Message}");
                return false;
            }
        }
    }
}