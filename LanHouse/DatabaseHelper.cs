using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace lanhause
{
    public static class DatabaseHelper
    {
        // STRING DE CONEXÃO COM SQL SERVER
        private static string connectionString =
            "Data Source=sqlexpress;Initial Catalog=CJ3027287PR2;User ID=aluno;Password=aluno;";

        /// <summary>
        /// Inicializa o banco de dados criando todas as tabelas necessárias
        /// </summary>
        public static void InitializeDatabase()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // TABELA USUARIOS (se não existir)
                    string createUsuarios = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Usuarios')
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

                    // TABELA COMPUTADORES
                    string createComputadores = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Computadores')
                        BEGIN
                            CREATE TABLE Computadores (
                                Id NVARCHAR(50) PRIMARY KEY,
                                Nome NVARCHAR(100) NOT NULL,
                                Processador NVARCHAR(100) NOT NULL,
                                RAM NVARCHAR(50) NOT NULL,
                                Status NVARCHAR(50) NOT NULL,
                                PrecoHora DECIMAL(10,2) NOT NULL DEFAULT 5.00,
                                DataCadastro DATETIME DEFAULT GETDATE()
                            )
                        END";

                    // TABELA RESERVAS
                    string createReservas = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Reservas')
                        BEGIN
                            CREATE TABLE Reservas (
                                Id NVARCHAR(50) PRIMARY KEY,
                                ComputadorId NVARCHAR(50) NOT NULL,
                                ClienteNome NVARCHAR(100) NOT NULL,
                                ClienteEmail NVARCHAR(100) NOT NULL,
                                DataReserva DATE NOT NULL,
                                HoraInicio NVARCHAR(10) NOT NULL,
                                HoraFim NVARCHAR(10) NOT NULL,
                                Status NVARCHAR(50) NOT NULL,
                                ValorTotal DECIMAL(10,2) NOT NULL,
                                DataCriacao DATETIME DEFAULT GETDATE(),
                                UsuarioId INT NULL,
                                FOREIGN KEY (ComputadorId) REFERENCES Computadores(Id),
                                FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
                            )
                        END";

                    // TABELA USO COMPUTADORES (para relatórios)
                    string createUsoComputadores = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UsoComputadores')
                        BEGIN
                            CREATE TABLE UsoComputadores (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                ComputadorId NVARCHAR(50) NOT NULL,
                                ReservaId NVARCHAR(50) NULL,
                                DataUso DATE NOT NULL,
                                HorasUtilizadas DECIMAL(5,2) NOT NULL,
                                ValorGerado DECIMAL(10,2) NOT NULL,
                                DataRegistro DATETIME DEFAULT GETDATE(),
                                FOREIGN KEY (ComputadorId) REFERENCES Computadores(Id),
                                FOREIGN KEY (ReservaId) REFERENCES Reservas(Id)
                            )
                        END";

                    using (var cmd = new SqlCommand(createUsuarios, connection))
                        cmd.ExecuteNonQuery();

                    using (var cmd = new SqlCommand(createComputadores, connection))
                        cmd.ExecuteNonQuery();

                    using (var cmd = new SqlCommand(createReservas, connection))
                        cmd.ExecuteNonQuery();

                    using (var cmd = new SqlCommand(createUsoComputadores, connection))
                        cmd.ExecuteNonQuery();

                    // INSERIR DADOS INICIAIS
                    InserirDadosIniciais(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar banco de dados:\n{ex.Message}",
                              "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Insere dados iniciais no banco (admin e computadores)
        /// </summary>
        private static void InserirDadosIniciais(SqlConnection connection)
        {
            // VERIFICAR SE JÁ EXISTE ADMIN
            string checkAdmin = "SELECT COUNT(*) FROM Usuarios WHERE Email = 'admin@gmail.com'";
            using (var cmd = new SqlCommand(checkAdmin, connection))
            {
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    string insertAdmin = @"
                        INSERT INTO Usuarios (Nome, Email, Senha, TipoUsuario) 
                        VALUES ('Administrador', 'admin@gmail.com', 'admin@123456', 'Administrador')";
                    using (var cmdInsert = new SqlCommand(insertAdmin, connection))
                        cmdInsert.ExecuteNonQuery();
                }
            }

            // VERIFICAR SE JÁ EXISTEM COMPUTADORES
            string checkPcs = "SELECT COUNT(*) FROM Computadores";
            using (var cmd = new SqlCommand(checkPcs, connection))
            {
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    string insertPcs = @"
                        INSERT INTO Computadores (Id, Nome, Processador, RAM, Status, PrecoHora) VALUES
                        ('PC-001', 'Computador 1', 'Intel i5-10400F', '8GB DDR4', '🟢 DISPONÍVEL', 5.00),
                        ('PC-002', 'Computador 2', 'Intel i7-10700K', '16GB DDR4', '🟢 DISPONÍVEL', 7.00),
                        ('PC-003', 'Computador 3', 'AMD Ryzen 5 3600', '8GB DDR4', '🟢 DISPONÍVEL', 5.00),
                        ('PC-004', 'Computador 4', 'Intel i3-10100', '4GB DDR4', '🔴 EM MANUTENÇÃO', 3.00),
                        ('PC-005', 'Computador 5', 'Intel i5-11400', '8GB DDR4', '🟢 DISPONÍVEL', 5.00),
                        ('PC-006', 'Computador 6', 'AMD Ryzen 7 3700X', '16GB DDR4', '🟢 DISPONÍVEL', 8.00)";

                    using (var cmdInsert = new SqlCommand(insertPcs, connection))
                        cmdInsert.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Obtém conexão com o banco de dados
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Verifica se um computador está disponível no horário especificado
        /// </summary>
        public static bool ComputadorDisponivelNoHorario(string computadorId, DateTime data,
                                                         string horaInicio, string horaFim,
                                                         string reservaIdExcluir = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT COUNT(*) FROM Reservas 
                        WHERE ComputadorId = @ComputadorId 
                        AND DataReserva = @Data
                        AND Status NOT IN ('❌ CANCELADA', '✅ CONCLUÍDA')
                        AND (
                            (@HoraInicio >= HoraInicio AND @HoraInicio < HoraFim) OR
                            (@HoraFim > HoraInicio AND @HoraFim <= HoraFim) OR
                            (@HoraInicio <= HoraInicio AND @HoraFim >= HoraFim)
                        )";

                    if (!string.IsNullOrEmpty(reservaIdExcluir))
                        query += " AND Id <> @ReservaId";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ComputadorId", computadorId);
                        cmd.Parameters.AddWithValue("@Data", data.Date);
                        cmd.Parameters.AddWithValue("@HoraInicio", horaInicio);
                        cmd.Parameters.AddWithValue("@HoraFim", horaFim);

                        if (!string.IsNullOrEmpty(reservaIdExcluir))
                            cmd.Parameters.AddWithValue("@ReservaId", reservaIdExcluir);

                        int conflitos = (int)cmd.ExecuteScalar();
                        return conflitos == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar disponibilidade:\n{ex.Message}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Obtém detalhes da reserva que está causando conflito
        /// </summary>
        public static string ObterDetalhesConflito(string computadorId, DateTime data, string horaInicio, string horaFim)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT ClienteNome, HoraInicio, HoraFim 
                        FROM Reservas 
                        WHERE ComputadorId = @ComputadorId 
                        AND DataReserva = @DataReserva 
                        AND Status NOT IN ('❌ CANCELADA', '✅ CONCLUÍDA')
                        AND (
                            (@HoraInicio >= HoraInicio AND @HoraInicio < HoraFim) OR
                            (@HoraFim > HoraInicio AND @HoraFim <= HoraFim) OR
                            (@HoraInicio <= HoraInicio AND @HoraFim >= HoraFim)
                        )";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ComputadorId", computadorId);
                        cmd.Parameters.AddWithValue("@DataReserva", data.Date);
                        cmd.Parameters.AddWithValue("@HoraInicio", horaInicio);
                        cmd.Parameters.AddWithValue("@HoraFim", horaFim);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string cliente = reader["ClienteNome"].ToString();
                                string horaIniConflito = reader["HoraInicio"].ToString();
                                string horaFimConflito = reader["HoraFim"].ToString();

                                return $"Cliente: {cliente}\nHorário: {horaIniConflito} - {horaFimConflito}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter detalhes do conflito: {ex.Message}");
            }

            return "Horário indisponível (reserva existente)";
        }

        /// <summary>
        /// Registra o uso de um computador para fins de relatório
        /// </summary>
        public static void RegistrarUsoComputador(string computadorId, string reservaId,
                                                  DateTime dataUso, decimal horas, decimal valor)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO UsoComputadores (ComputadorId, ReservaId, DataUso, HorasUtilizadas, ValorGerado)
                        VALUES (@ComputadorId, @ReservaId, @DataUso, @HorasUtilizadas, @ValorGerado)";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ComputadorId", computadorId);
                        cmd.Parameters.AddWithValue("@ReservaId", reservaId ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DataUso", dataUso.Date);
                        cmd.Parameters.AddWithValue("@HorasUtilizadas", horas);
                        cmd.Parameters.AddWithValue("@ValorGerado", valor);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar uso:\n{ex.Message}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Obtém relatório completo de uso dos computadores
        /// </summary>
        public static DataTable ObterRelatorioUso()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
            SELECT 
                c.Nome as ComputadorNome,
                c.PrecoHora,
                COUNT(CASE WHEN r.Status IN ('✅ CONCLUÍDA', '● CONFIRMADA') THEN r.Id END) as TotalReservas,
                ISNULL(SUM(CASE WHEN r.Status IN ('✅ CONCLUÍDA', '● CONFIRMADA') THEN r.ValorTotal ELSE 0 END), 0) as ReceitaTotal,
                ISNULL(SUM(CASE 
                    WHEN r.Status IN ('✅ CONCLUÍDA', '● CONFIRMADA') THEN 
                        -- Calcula horas manualmente sem conversão para datetime
                        CASE 
                            WHEN REPLACE(r.HoraFim, '.', ':') > REPLACE(r.HoraInicio, '.', ':') THEN
                                (CAST(REPLACE(LEFT(r.HoraFim, 2), '.', '') AS int) * 60 + CAST(RIGHT(r.HoraFim, 2) AS int) -
                                 CAST(REPLACE(LEFT(r.HoraInicio, 2), '.', '') AS int) * 60 - CAST(RIGHT(r.HoraInicio, 2) AS int)) / 60.0
                            ELSE
                                ((24 * 60 - (CAST(REPLACE(LEFT(r.HoraInicio, 2), '.', '') AS int) * 60 + CAST(RIGHT(r.HoraInicio, 2) AS int)) +
                                 CAST(REPLACE(LEFT(r.HoraFim, 2), '.', '') AS int) * 60 + CAST(RIGHT(r.HoraFim, 2) AS int)) / 60.0)
                        END
                    ELSE 0 
                END), 0) as TotalHorasUtilizadas
            FROM Computadores c
            LEFT JOIN Reservas r ON c.Id = r.ComputadorId
            GROUP BY c.Id, c.Nome, c.PrecoHora
            ORDER BY c.Nome";

                using (var cmd = new SqlCommand(query, connection))
                {
                    DataTable dt = new DataTable();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        /// <summary>
        /// Atualiza o status de um computador
        /// </summary>
        public static bool AtualizarStatusComputador(string computadorId, string novoStatus)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Computadores SET Status = @Status WHERE Id = @Id";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Status", novoStatus);
                        cmd.Parameters.AddWithValue("@Id", computadorId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar status:\n{ex.Message}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Testa a conexão com o banco de dados
        /// </summary>
        public static bool TestarConexao()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na conexão com o banco:\n{ex.Message}",
                              "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}