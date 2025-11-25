using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lanhause
{
    public partial class FormRelatorios : Form
    {
        public FormRelatorios()
        {
            InitializeComponent();
            ConfigurarInicial();
        }

        private void ConfigurarInicial()
        {
            // Define período padrão: últimos 30 dias
            dateTimePickerFim.Value = DateTime.Now;
            dateTimePickerInicio.Value = DateTime.Now.AddDays(-30);

            comboBoxRelatorios.SelectedIndex = 0;
        }

        private DataTable ObterRelatorioUso()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // QUERY SEGURA - cálculo baseado no valor total
                string query = @"
                    SELECT 
                        c.Nome as ComputadorNome,
                        c.PrecoHora,
                        COUNT(r.Id) as TotalReservas,
                        SUM(r.ValorTotal) as ReceitaTotal,
                        -- Cálculo seguro baseado no valor total e preço por hora
                        CASE 
                            WHEN c.PrecoHora > 0 THEN SUM(r.ValorTotal) / c.PrecoHora
                            ELSE 0 
                        END as TotalHorasUtilizadas
                    FROM Computadores c
                    LEFT JOIN Reservas r ON c.Id = r.ComputadorId 
                        AND r.Status NOT IN ('CANCELADA')
                        AND r.DataReserva BETWEEN @DataInicio AND @DataFim
                    GROUP BY c.Id, c.Nome, c.PrecoHora
                    ORDER BY ReceitaTotal DESC";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DataInicio", dateTimePickerInicio.Value.Date);
                    cmd.Parameters.AddWithValue("@DataFim", dateTimePickerFim.Value.Date);

                    DataTable dt = new DataTable();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                btnGerarRelatorio.Enabled = false;

                switch (comboBoxRelatorios.SelectedIndex)
                {
                    case 0: // Uso de Computadores
                        GerarRelatorioUsoComputadores();
                        break;
                    case 1: // Reservas
                        GerarRelatorioReservas();
                        break;
                    case 2: // Financeiro
                        GerarRelatorioFinanceiro();
                        break;
                }

                btnExportar.Enabled = dataGridViewRelatorio.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGerarRelatorio.Enabled = true;
            }
        }

        private void GerarRelatorioUsoComputadores()
        {
            try
            {
                DataTable dt = ObterRelatorioUso();
                dataGridViewRelatorio.DataSource = dt;

                // Formatar colunas
                if (dataGridViewRelatorio.Columns.Count > 0)
                {
                    dataGridViewRelatorio.Columns["ComputadorNome"].HeaderText = "COMPUTADOR";
                    dataGridViewRelatorio.Columns["PrecoHora"].HeaderText = "PREÇO/HORA";
                    dataGridViewRelatorio.Columns["TotalReservas"].HeaderText = "RESERVAS";
                    dataGridViewRelatorio.Columns["ReceitaTotal"].HeaderText = "RECEITA";
                    dataGridViewRelatorio.Columns["TotalHorasUtilizadas"].HeaderText = "HORAS";

                    // Formatar moeda
                    dataGridViewRelatorio.Columns["PrecoHora"].DefaultCellStyle.Format = "C2";
                    dataGridViewRelatorio.Columns["ReceitaTotal"].DefaultCellStyle.Format = "C2";
                    dataGridViewRelatorio.Columns["TotalHorasUtilizadas"].DefaultCellStyle.Format = "N1";
                }

                MessageBox.Show("✅ Relatório de Uso de Computadores gerado com sucesso!", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de uso:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GerarRelatorioReservas()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            r.Id as ReservaID,
                            r.ClienteNome as Cliente,
                            c.Nome as Computador,
                            CONVERT(VARCHAR, r.DataReserva, 103) as Data,
                            r.HoraInicio + ' - ' + r.HoraFim as Horario,
                            r.Status,
                            r.ValorTotal as Valor
                        FROM Reservas r
                        JOIN Computadores c ON r.ComputadorId = c.Id
                        WHERE r.DataReserva BETWEEN @DataInicio AND @DataFim
                        ORDER BY r.DataReserva DESC, r.HoraInicio DESC";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DataInicio", dateTimePickerInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@DataFim", dateTimePickerFim.Value.Date);

                        DataTable dt = new DataTable();
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        dataGridViewRelatorio.DataSource = dt;

                        if (dataGridViewRelatorio.Columns.Count > 0)
                        {
                            dataGridViewRelatorio.Columns["Valor"].DefaultCellStyle.Format = "C2";
                        }
                    }
                }

                MessageBox.Show($"✅ Relatório de Reservas gerado!\nPeríodo: {dateTimePickerInicio.Value:dd/MM/yyyy} a {dateTimePickerFim.Value:dd/MM/yyyy}",
                              "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de reservas:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GerarRelatorioFinanceiro()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // CORREÇÃO: Filtrar apenas reservas CONFIRMADAS (inclui emojis)
                    string query = @"
                        SELECT 
                            CONVERT(VARCHAR, r.DataReserva, 103) as Data,
                            COUNT(*) as TotalReservas,
                            SUM(CASE 
                                WHEN r.Status LIKE '%CONFIRMADA%' 
                                OR r.Status LIKE '%● CONFIRMADA%' 
                                THEN r.ValorTotal 
                                ELSE 0 
                            END) as ReceitaTotal,
                            SUM(CASE WHEN r.Status LIKE '%CANCELADA%' THEN 1 ELSE 0 END) as ReservasCanceladas
                        FROM Reservas r
                        WHERE r.DataReserva BETWEEN @DataInicio AND @DataFim
                        GROUP BY r.DataReserva
                        ORDER BY r.DataReserva DESC";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DataInicio", dateTimePickerInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@DataFim", dateTimePickerFim.Value.Date);

                        DataTable dt = new DataTable();
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        dataGridViewRelatorio.DataSource = dt;

                        if (dataGridViewRelatorio.Columns.Count > 0)
                        {
                            dataGridViewRelatorio.Columns["Data"].HeaderText = "DATA";
                            dataGridViewRelatorio.Columns["TotalReservas"].HeaderText = "RESERVAS";
                            dataGridViewRelatorio.Columns["ReceitaTotal"].HeaderText = "RECEITA (Confirmadas)";
                            dataGridViewRelatorio.Columns["ReservasCanceladas"].HeaderText = "CANCELADAS";

                            dataGridViewRelatorio.Columns["ReceitaTotal"].DefaultCellStyle.Format = "C2";
                        }
                    }
                }

                MessageBox.Show($"✅ Relatório Financeiro gerado!\nPeríodo: {dateTimePickerInicio.Value:dd/MM/yyyy} a {dateTimePickerFim.Value:dd/MM/yyyy}",
                              "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório financeiro:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dataGridViewRelatorio.Rows.Count == 0)
            {
                MessageBox.Show("⚠️ Não há dados para exportar!", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Funcionalidade de exportação simplificada
            MessageBox.Show($"📤 Exportação para Excel em desenvolvimento.\n\n" +
                          $"Registros disponíveis: {dataGridViewRelatorio.Rows.Count}\n" +
                          $"Tipo: {comboBoxRelatorios.Text}",
                          "Exportar Excel",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRelatorios_Load(object sender, EventArgs e)
        {
            // Configuração inicial já feita
        }
    }
}