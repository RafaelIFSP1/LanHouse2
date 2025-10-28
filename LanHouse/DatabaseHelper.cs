using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace lanhause
{
    public static class DatabaseHelper
    {
        private static string databasePath = Path.Combine(Application.StartupPath, "lanhouse.db");
        private static string connectionString = $"Data Source={databasePath};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Tabela de computadores
                string createComputadoresTable = @"
                    CREATE TABLE IF NOT EXISTS Computadores (
                        Id TEXT PRIMARY KEY,
                        Nome TEXT NOT NULL,
                        Processador TEXT NOT NULL,
                        RAM TEXT NOT NULL,
                        Status TEXT NOT NULL,
                        PrecoHora DECIMAL(10,2) NOT NULL DEFAULT 5.00
                    )";

                // Tabela de reservas
                string createReservasTable = @"
                    CREATE TABLE IF NOT EXISTS Reservas (
                        Id TEXT PRIMARY KEY,
                        ComputadorId TEXT NOT NULL,
                        ClienteNome TEXT NOT NULL,
                        ClienteEmail TEXT NOT NULL,
                        DataReserva DATE NOT NULL,
                        HoraInicio TIME NOT NULL,
                        HoraFim TIME NOT NULL,
                        Status TEXT NOT NULL,
                        ValorTotal DECIMAL(10,2) NOT NULL,
                        DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (ComputadorId) REFERENCES Computadores(Id)
                    )";

                // Tabela de uso/horas (NOVA TABELA)
                string createUsoTable = @"
                    CREATE TABLE IF NOT EXISTS UsoComputadores (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ComputadorId TEXT NOT NULL,
                        DataUso DATE NOT NULL,
                        HorasUtilizadas DECIMAL(5,2) NOT NULL,
                        ValorGerado DECIMAL(10,2) NOT NULL,
                        FOREIGN KEY (ComputadorId) REFERENCES Computadores(Id)
                    )";

                using (var command = new SQLiteCommand(createComputadoresTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createReservasTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createUsoTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Inserir computadores exemplo
                InserirComputadoresExemplo(connection);
            }
        }

        private static void InserirComputadoresExemplo(SQLiteConnection connection)
        {
            string checkComputadores = "SELECT COUNT(*) FROM Computadores";
            using (var command = new SQLiteCommand(checkComputadores, connection))
            {
                long count = (long)command.ExecuteScalar();
                if (count == 0)
                {
                    string insertComputadores = @"
                        INSERT INTO Computadores (Id, Nome, Processador, RAM, Status, PrecoHora) VALUES
                        ('PC-001', 'Computador 1', 'Intel i5', '8GB DDR4', '🟢 DISPONÍVEL', 5.00),
                        ('PC-002', 'Computador 2', 'Intel i7', '16GB DDR4', '🟢 DISPONÍVEL', 7.00),
                        ('PC-003', 'Computador 3', 'AMD Ryzen 5', '8GB DDR4', '🟢 DISPONÍVEL', 5.00),
                        ('PC-004', 'Computador 4', 'Intel i3', '4GB DDR4', '🔴 EM MANUTENÇÃO', 3.00),
                        ('PC-005', 'Computador 5', 'Intel i5', '8GB DDR4', '🟢 DISPONÍVEL', 5.00),
                        ('PC-006', 'Computador 6', 'AMD Ryzen 7', '16GB DDR4', '🟢 DISPONÍVEL', 8.00)";

                    using (var commandInsert = new SQLiteCommand(insertComputadores, connection))
                    {
                        commandInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        // Método para registrar uso do computador
        public static void RegistrarUsoComputador(string computadorId, DateTime dataUso, decimal horas, decimal valor)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO UsoComputadores (ComputadorId, DataUso, HorasUtilizadas, ValorGerado)
                    VALUES (@ComputadorId, @DataUso, @HorasUtilizadas, @ValorGerado)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ComputadorId", computadorId);
                    command.Parameters.AddWithValue("@DataUso", dataUso.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@HorasUtilizadas", horas);
                    command.Parameters.AddWithValue("@ValorGerado", valor);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para obter relatório de uso CORRIGIDO
        public static SQLiteDataReader ObterRelatorioUso()
        {
            var connection = GetConnection();
            connection.Open();

            string query = @"
        SELECT 
            c.Nome as ComputadorNome,
            c.PrecoHora,
            COUNT(r.Id) as TotalReservas,
            SUM(CASE WHEN r.Status != '❌ CANCELADA' THEN r.ValorTotal ELSE 0 END) as ReceitaTotal,
            SUM(CASE WHEN r.Status != '❌ CANCELADA' THEN 
                (julianday(r.HoraFim) - julianday(r.HoraInicio)) * 24 
                ELSE 0 END) as TotalHorasUtilizadas
        FROM Computadores c
        LEFT JOIN Reservas r ON c.Id = r.ComputadorId
        GROUP BY c.Id, c.Nome, c.PrecoHora
        ORDER BY c.Nome";

            var command = new SQLiteCommand(query, connection);
            return command.ExecuteReader();
        }


        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}