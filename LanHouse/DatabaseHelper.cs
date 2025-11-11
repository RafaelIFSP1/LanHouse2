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

                    // TABELA USUARIOS - COM BIT (2 estados)
                    string createUsuarios = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Usuarios')
                        BEGIN
                            CREATE TABLE Usuarios (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                Nome NVARCHAR(100) NOT NULL,
                                Email NVARCHAR(100) UNIQUE NOT NULL,
                                Senha NVARCHAR(100) NOT NULL,
                                TipoUsuario NVARCHAR(20) DEFAULT 'Cliente',
                                Ativo BIT DEFAULT 1,  -- 1=ATIVO, 0=INATIVO
                                DataCadastro DATETIME DEFAULT GETDATE()
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

                    ExecuteNonQuery(createUsuarios, connection);
                    ExecuteNonQuery(createComputadores, connection);
                    ExecuteNonQuery(createReservas, connection);

                    InserirDadosIniciais(connection);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao inicializar banco de dados:\n{ex.Message}", "Erro Crítico");
            }
        }

        /// <summary>
        /// Insere dados iniciais no banco
        /// </summary>
        private static void InserirDadosIniciais(SqlConnection connection)
        {
            // VERIFICAR SE JÁ EXISTE ADMIN
            if (!RecordExists("SELECT COUNT(*) FROM Usuarios WHERE Email = 'admin@gmail.com'", connection))
            {
                string insertAdmin = @"
                    INSERT INTO Usuarios (Nome, Email, Senha, TipoUsuario, Ativo) 
                    VALUES ('Administrador', 'admin@gmail.com', 'admin@123456', 'Administrador', 1)";
                ExecuteNonQuery(insertAdmin, connection);
            }

            // INSERIR USUÁRIOS DE EXEMPLO ADICIONAIS
            if (!RecordExists("SELECT COUNT(*) FROM Usuarios WHERE Email <> 'admin@gmail.com'", connection))
            {
                string insertUsuarios = @"
                    INSERT INTO Usuarios (Nome, Email, Senha, TipoUsuario, Ativo) VALUES
                    ('João Silva', 'joao@email.com', 'senha123', 'Cliente', 1),
                    ('Maria Santos', 'maria@email.com', 'senha123', 'Cliente', 1),
                    ('Pedro Costa', 'pedro@email.com', 'senha123', 'Cliente', 0)";
                ExecuteNonQuery(insertUsuarios, connection);
            }

            // VERIFICAR SE JÁ EXISTEM COMPUTADORES
            if (!RecordExists("SELECT COUNT(*) FROM Computadores", connection))
            {
                string insertPcs = @"
                    INSERT INTO Computadores (Id, Nome, Processador, RAM, Status, PrecoHora) VALUES
                    ('1', 'Computador 1', 'Intel i5-10400F', '8GB DDR4', 'DISPONÍVEL', 5.00),
                    ('2', 'Computador 2', 'Intel i7-10700K', '16GB DDR4', 'DISPONÍVEL', 7.00),
                    ('3', 'Computador 3', 'AMD Ryzen 5 3600', '8GB DDR4', 'DISPONÍVEL', 5.00),
                    ('4', 'Computador 4', 'Intel i3-10100', '4GB DDR4', 'EM MANUTENÇÃO', 3.00),
                    ('5', 'Computador 5', 'Intel i5-11400', '8GB DDR4', 'DISPONÍVEL', 5.00),
                    ('6', 'Computador 6', 'AMD Ryzen 7 3700X', '16GB DDR4', 'DISPONÍVEL', 8.00)";
                ExecuteNonQuery(insertPcs, connection);
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
        /// Obtém detalhes da reserva que está causando conflito
        /// </summary>
        public static string ObterDetalhesConflito(string computadorId, DateTime data, string horaInicio, string horaFim)
        {
            try
            {
                string query = @"
                    SELECT ClienteNome, HoraInicio, HoraFim 
                    FROM Reservas 
                    WHERE ComputadorId = @ComputadorId 
                    AND DataReserva = @DataReserva 
                    AND Status NOT IN ('CANCELADA', 'CONCLUÍDA')
                    AND (
                        (@HoraInicio >= HoraInicio AND @HoraInicio < HoraFim) OR
                        (@HoraFim > HoraInicio AND @HoraFim <= HoraFim) OR
                        (@HoraInicio <= HoraInicio AND @HoraFim >= HoraFim)
                    )";

                using (var reader = ExecuteReader(query,
                    new SqlParameter("@ComputadorId", computadorId),
                    new SqlParameter("@DataReserva", data.Date),
                    new SqlParameter("@HoraInicio", horaInicio),
                    new SqlParameter("@HoraFim", horaFim)))
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
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter detalhes do conflito: {ex.Message}");
            }

            return "Horário indisponível (reserva existente)";
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
                string query = @"
                    SELECT COUNT(*) FROM Reservas 
                    WHERE ComputadorId = @ComputadorId 
                    AND DataReserva = @Data
                    AND Status NOT IN ('CANCELADA', 'CONCLUÍDA')
                    AND (
                        (@HoraInicio >= HoraInicio AND @HoraInicio < HoraFim) OR
                        (@HoraFim > HoraInicio AND @HoraFim <= HoraFim) OR
                        (@HoraInicio <= HoraInicio AND @HoraFim >= HoraFim)
                    )";

                if (!string.IsNullOrEmpty(reservaIdExcluir))
                    query += " AND Id <> @ReservaId";

                var parameters = new[]
                {
                    new SqlParameter("@ComputadorId", computadorId),
                    new SqlParameter("@Data", data.Date),
                    new SqlParameter("@HoraInicio", horaInicio),
                    new SqlParameter("@HoraFim", horaFim)
                };

                if (!string.IsNullOrEmpty(reservaIdExcluir))
                {
                    var paramList = new SqlParameter[parameters.Length + 1];
                    parameters.CopyTo(paramList, 0);
                    paramList[parameters.Length] = new SqlParameter("@ReservaId", reservaIdExcluir);
                    parameters = paramList;
                }

                int conflitos = ExecuteScalar<int>(query, parameters);
                return conflitos == 0;
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao verificar disponibilidade:\n{ex.Message}", "Erro");
                return false;
            }
        }

        /// <summary>
        /// Obtém todos os usuários cadastrados - 2 ESTADOS (ATIVO/INATIVO)
        /// </summary>
        public static DataTable ObterTodosUsuarios()
        {
            try
            {
                string query = @"
                    SELECT 
                        Id, 
                        Nome, 
                        Email, 
                        TipoUsuario, 
                        CASE 
                            WHEN Ativo = 1 THEN 'ATIVO' 
                            ELSE 'INATIVO' 
                        END as Status,
                        CONVERT(VARCHAR, DataCadastro, 103) as DataCadastro
                    FROM Usuarios
                    ORDER BY Nome";

                return ExecuteDataTable(query);
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao carregar usuários: {ex.Message}", "Erro");
                return null;
            }
        }

        /// <summary>
        /// Altera o status de um usuário - 2 ESTADOS (ATIVO/INATIVO)
        /// </summary>
        public static bool AlterarStatusUsuario(int usuarioId, bool ativo)
        {
            try
            {
                string query = "UPDATE Usuarios SET Ativo = @Ativo WHERE Id = @Id";
                int rowsAffected = ExecuteNonQuery(query,
                    new SqlParameter("@Ativo", ativo ? 1 : 0),
                    new SqlParameter("@Id", usuarioId));

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao alterar status do usuário:\n{ex.Message}", "Erro");
                return false;
            }
        }

        /// <summary>
        /// Valida login do usuário
        /// </summary>
        public static bool ValidarLogin(string email, string senha)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) FROM Usuarios 
                    WHERE Email = @Email AND Senha = @Senha AND Ativo = 1";

                int count = ExecuteScalar<int>(query,
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Senha", senha));

                return count > 0;
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao validar login:\n{ex.Message}", "Erro");
                return false;
            }
        }

        /// <summary>
        /// Obtém informações do usuário logado
        /// </summary>
        public static DataTable ObterUsuarioPorEmail(string email)
        {
            try
            {
                string query = @"
                    SELECT 
                        Id, 
                        Nome, 
                        Email, 
                        TipoUsuario, 
                        CASE 
                            WHEN Ativo = 1 THEN 'ATIVO' 
                            ELSE 'INATIVO' 
                        END as Ativo
                    FROM Usuarios 
                    WHERE Email = @Email";

                return ExecuteDataTable(query, new SqlParameter("@Email", email));
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao obter usuário:\n{ex.Message}", "Erro");
                return null;
            }
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        public static bool CadastrarUsuario(string nome, string email, string senha, string tipoUsuario)
        {
            try
            {
                string query = @"
                    INSERT INTO Usuarios (Nome, Email, Senha, TipoUsuario, Ativo)
                    VALUES (@Nome, @Email, @Senha, @TipoUsuario, 1)";

                int rowsAffected = ExecuteNonQuery(query,
                    new SqlParameter("@Nome", nome),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Senha", senha),
                    new SqlParameter("@TipoUsuario", tipoUsuario));

                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violação de chave única (email duplicado)
                {
                    MessageBox.Show("Este email já está cadastrado no sistema.", "Erro de Cadastro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ShowError($"Erro ao cadastrar usuário:\n{ex.Message}", "Erro");
                }
                return false;
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao cadastrar usuário:\n{ex.Message}", "Erro");
                return false;
            }
        }

        /// <summary>
        /// Apaga um usuário permanentemente do banco de dados - SOMENTE ADMIN
        /// </summary>
        public static bool ApagarUsuario(int usuarioId)
        {
            try
            {
                // Verificar se o usuário tem reservas ativas
                string checkReservas = @"
                    SELECT COUNT(*) FROM Reservas 
                    WHERE UsuarioId = @UsuarioId 
                    AND Status NOT IN ('CANCELADA', 'CONCLUÍDA')";

                int reservasAtivas = ExecuteScalar<int>(checkReservas,
                    new SqlParameter("@UsuarioId", usuarioId));

                if (reservasAtivas > 0)
                {
                    MessageBox.Show("❌ Não é possível apagar este usuário pois ele possui reservas ativas!\n" +
                                  "Cancele as reservas primeiro ou altere seu status para inativo.",
                                  "Erro de Operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Apagar o usuário
                string query = "DELETE FROM Usuarios WHERE Id = @Id";
                int rowsAffected = ExecuteNonQuery(query, new SqlParameter("@Id", usuarioId));
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao apagar usuário:\n{ex.Message}", "Erro");
                return false;
            }
        }

        /// <summary>
        /// Obtém o tipo de usuário por email
        /// </summary>
        public static string ObterTipoUsuario(string email)
        {
            try
            {
                string query = "SELECT TipoUsuario FROM Usuarios WHERE Email = @Email";
                var result = ExecuteScalar<object>(query, new SqlParameter("@Email", email));
                return result?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao obter tipo de usuário:\n{ex.Message}", "Erro");
                return "";
            }
        }

        /// <summary>
        /// Verifica se email já existe
        /// </summary>
        public static bool EmailExiste(string email)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";
                int count = ExecuteScalar<int>(query, new SqlParameter("@Email", email));
                return count > 0;
            }
            catch (Exception ex)
            {
                ShowError($"Erro ao verificar email:\n{ex.Message}", "Erro");
                return false;
            }
        }

        // ========== MÉTODOS AUXILIARES REUTILIZÁVEIS ==========

        private static void ExecuteNonQuery(string query, SqlConnection connection, params SqlParameter[] parameters)
        {
            using (var cmd = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }

        private static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        private static T ExecuteScalar<T>(string query, params SqlParameter[] parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    var result = cmd.ExecuteScalar();
                    return (T)Convert.ChangeType(result, typeof(T));
                }
            }
        }

        private static SqlDataReader ExecuteReader(string query, params SqlParameter[] parameters)
        {
            var connection = GetConnection();
            connection.Open();
            using (var cmd = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        private static DataTable ExecuteDataTable(string query, params SqlParameter[] parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    DataTable dt = new DataTable();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        private static bool RecordExists(string query, SqlConnection connection, params SqlParameter[] parameters)
        {
            using (var cmd = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private static void ShowError(string message, string title = "Erro")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}