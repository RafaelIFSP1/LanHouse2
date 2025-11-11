using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lanhause
{
    public partial class FormRelatorios : Form
    {
        private ComboBox comboBoxRelatorios;
        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFim;
        private Button btnGerarRelatorio;
        private Button btnExportar;
        private Button btnFechar;
        private Label lblTitulo;
        private Label lblTipoRelatorio;
        private Label lblPeriodo;
        private Label lblAte;
        private GroupBox groupBox1;
        private DataGridView dataGridViewRelatorio;

        public FormRelatorios()
        {
            InitializeComponent();
            ConfigurarInicial();
        }

        private void InitializeComponent()
        {
            // ... (código do InitializeComponent permanece igual) ...
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTipoRelatorio = new System.Windows.Forms.Label();
            this.comboBoxRelatorios = new System.Windows.Forms.ComboBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.lblAte = new System.Windows.Forms.Label();
            this.dateTimePickerFim = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewRelatorio = new System.Windows.Forms.DataGridView();
            this.btnGerarRelatorio = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelatorio)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📊 RELATÓRIOS DO SISTEMA";

            // groupBox1
            this.groupBox1.Controls.Add(this.lblTipoRelatorio);
            this.groupBox1.Controls.Add(this.comboBoxRelatorios);
            this.groupBox1.Controls.Add(this.lblPeriodo);
            this.groupBox1.Controls.Add(this.dateTimePickerInicio);
            this.groupBox1.Controls.Add(this.lblAte);
            this.groupBox1.Controls.Add(this.dateTimePickerFim);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações do Relatório";

            // lblTipoRelatorio
            this.lblTipoRelatorio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoRelatorio.Location = new System.Drawing.Point(20, 35);
            this.lblTipoRelatorio.Name = "lblTipoRelatorio";
            this.lblTipoRelatorio.Size = new System.Drawing.Size(120, 20);
            this.lblTipoRelatorio.TabIndex = 0;
            this.lblTipoRelatorio.Text = "Tipo de Relatório:";

            // comboBoxRelatorios
            this.comboBoxRelatorios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRelatorios.Items.AddRange(new object[] {
                "📈 Relatório de Uso de Computadores",
                "📅 Relatório de Reservas",
                "💰 Relatório Financeiro"});
            this.comboBoxRelatorios.Location = new System.Drawing.Point(140, 32);
            this.comboBoxRelatorios.Name = "comboBoxRelatorios";
            this.comboBoxRelatorios.Size = new System.Drawing.Size(250, 23);
            this.comboBoxRelatorios.TabIndex = 1;
            this.comboBoxRelatorios.SelectedIndex = 0;

            // lblPeriodo
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPeriodo.Location = new System.Drawing.Point(420, 35);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(60, 20);
            this.lblPeriodo.TabIndex = 2;
            this.lblPeriodo.Text = "Período:";

            // dateTimePickerInicio
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(480, 32);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerInicio.TabIndex = 3;

            // lblAte
            this.lblAte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAte.Location = new System.Drawing.Point(610, 35);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(25, 20);
            this.lblAte.TabIndex = 4;
            this.lblAte.Text = "até";

            // dateTimePickerFim
            this.dateTimePickerFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFim.Location = new System.Drawing.Point(640, 32);
            this.dateTimePickerFim.Name = "dateTimePickerFim";
            this.dateTimePickerFim.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerFim.TabIndex = 5;

            // dataGridViewRelatorio
            this.dataGridViewRelatorio.AllowUserToAddRows = false;
            this.dataGridViewRelatorio.AllowUserToDeleteRows = false;
            this.dataGridViewRelatorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRelatorio.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRelatorio.Location = new System.Drawing.Point(20, 180);
            this.dataGridViewRelatorio.Name = "dataGridViewRelatorio";
            this.dataGridViewRelatorio.ReadOnly = true;
            this.dataGridViewRelatorio.RowHeadersVisible = false;
            this.dataGridViewRelatorio.Size = new System.Drawing.Size(850, 350);
            this.dataGridViewRelatorio.TabIndex = 2;

            // btnGerarRelatorio
            this.btnGerarRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnGerarRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarRelatorio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGerarRelatorio.ForeColor = System.Drawing.Color.White;
            this.btnGerarRelatorio.Location = new System.Drawing.Point(342, 550);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(180, 40);
            this.btnGerarRelatorio.TabIndex = 3;
            this.btnGerarRelatorio.Text = "📊 GERAR RELATÓRIO";
            this.btnGerarRelatorio.UseVisualStyleBackColor = false;
            this.btnGerarRelatorio.Click += new System.EventHandler(this.btnGerarRelatorio_Click);

            // btnExportar
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(528, 550);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(180, 40);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "📤 EXPORTAR EXCEL";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);

            // btnFechar
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(714, 550);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 40);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "🔙 VOLTAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // FormRelatorios
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 598);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewRelatorio);
            this.Controls.Add(this.btnGerarRelatorio);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📊 Relatórios - Lan House System";
            this.Load += new System.EventHandler(this.FormRelatorios_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelatorio)).EndInit();
            this.ResumeLayout(false);
        }

        private void ConfigurarInicial()
        {
            // Define período padrão: últimos 30 dias
            dateTimePickerFim.Value = DateTime.Now;
            dateTimePickerInicio.Value = DateTime.Now.AddDays(-30);

            comboBoxRelatorios.SelectedIndex = 0;
        }

        // MÉTODO MOVIDO PARA CIMA - declarado antes de ser usado
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
                DataTable dt = ObterRelatorioUso(); // Agora o método já está declarado
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
                    string query = @"
                        SELECT 
                            CONVERT(VARCHAR, r.DataReserva, 103) as Data,
                            COUNT(*) as TotalReservas,
                            SUM(CASE WHEN r.Status IN ('CONCLUÍDA', 'CONFIRMADA') THEN r.ValorTotal ELSE 0 END) as ReceitaTotal,
                            SUM(CASE WHEN r.Status = 'CANCELADA' THEN 1 ELSE 0 END) as ReservasCanceladas
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
                            dataGridViewRelatorio.Columns["ReceitaTotal"].HeaderText = "RECEITA";
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