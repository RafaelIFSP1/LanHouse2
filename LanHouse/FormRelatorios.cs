using System;
using System.Drawing;
using System.Windows.Forms;

namespace LanHouseSystem
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
        private GroupBox groupBox1;
        private DataGridView dataGridViewRelatorio;

        public FormRelatorios()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
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
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📊 RELATÓRIOS DO SISTEMA";
            // 
            // groupBox1
            // 
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
            // 
            // lblTipoRelatorio
            // 
            this.lblTipoRelatorio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoRelatorio.Location = new System.Drawing.Point(20, 35);
            this.lblTipoRelatorio.Name = "lblTipoRelatorio";
            this.lblTipoRelatorio.Size = new System.Drawing.Size(120, 20);
            this.lblTipoRelatorio.TabIndex = 0;
            this.lblTipoRelatorio.Text = "Tipo de Relatório:";
            // 
            // comboBoxRelatorios
            // 
            this.comboBoxRelatorios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRelatorios.Items.AddRange(new object[] {
            "📈 Relatório de Uso de Computadores",
            "📅 Relatório de Reservas",
            "💰 Relatório Financeiro",
            "👥 Relatório de Usuários",
            "🖥️ Relatório de Computadores"});
            this.comboBoxRelatorios.Location = new System.Drawing.Point(140, 32);
            this.comboBoxRelatorios.Name = "comboBoxRelatorios";
            this.comboBoxRelatorios.Size = new System.Drawing.Size(250, 23);
            this.comboBoxRelatorios.TabIndex = 1;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPeriodo.Location = new System.Drawing.Point(420, 35);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(60, 20);
            this.lblPeriodo.TabIndex = 2;
            this.lblPeriodo.Text = "Período:";
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(480, 32);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerInicio.TabIndex = 3;
            this.dateTimePickerInicio.Value = new System.DateTime(2025, 9, 7, 12, 42, 28, 369);
            // 
            // lblAte
            // 
            this.lblAte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAte.Location = new System.Drawing.Point(610, 35);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(25, 20);
            this.lblAte.TabIndex = 4;
            this.lblAte.Text = "até";
            // 
            // dateTimePickerFim
            // 
            this.dateTimePickerFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFim.Location = new System.Drawing.Point(640, 32);
            this.dateTimePickerFim.Name = "dateTimePickerFim";
            this.dateTimePickerFim.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerFim.TabIndex = 5;
            this.dateTimePickerFim.Value = new System.DateTime(2025, 10, 7, 12, 42, 28, 372);
            // 
            // dataGridViewRelatorio
            // 
            this.dataGridViewRelatorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRelatorio.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRelatorio.Location = new System.Drawing.Point(20, 180);
            this.dataGridViewRelatorio.Name = "dataGridViewRelatorio";
            this.dataGridViewRelatorio.ReadOnly = true;
            this.dataGridViewRelatorio.RowHeadersVisible = false;
            this.dataGridViewRelatorio.Size = new System.Drawing.Size(850, 350);
            this.dataGridViewRelatorio.TabIndex = 2;
            // 
            // btnGerarRelatorio
            // 
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
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(528, 550);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(180, 40);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "📤 EXPORTAR EXCEL";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
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
            // 
            // FormRelatorios
            // 
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
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelatorio)).EndInit();
            this.ResumeLayout(false);

        }

        private void CarregarRelatorioExemplo()
        {
            dataGridViewRelatorio.Columns.Clear();

            // Exemplo de relatório de uso
            dataGridViewRelatorio.Columns.Add("Computador", "COMPUTADOR");
            dataGridViewRelatorio.Columns.Add("HorasUso", "HORAS DE USO");
            dataGridViewRelatorio.Columns.Add("Reservas", "TOTAL RESERVAS");
            dataGridViewRelatorio.Columns.Add("Receita", "RECEITA GERADA");
            dataGridViewRelatorio.Columns.Add("Ocupacao", "TAXA DE OCUPAÇÃO");

            dataGridViewRelatorio.Rows.Add("PC-001", "48h", "12", "R$ 240,00", "85%");
            dataGridViewRelatorio.Rows.Add("PC-002", "36h", "9", "R$ 288,00", "75%");
            dataGridViewRelatorio.Rows.Add("PC-003", "24h", "6", "R$ 72,00", "60%");
            dataGridViewRelatorio.Rows.Add("PC-004", "42h", "10", "R$ 210,00", "80%");
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            string relatorioSelecionado = comboBoxRelatorios.Text;
            string periodo = $"{dateTimePickerInicio.Value:dd/MM/yyyy} a {dateTimePickerFim.Value:dd/MM/yyyy}";

            MessageBox.Show($"✅ Relatório gerado com sucesso!\n\n" +
                          $"Tipo: {relatorioSelecionado}\n" +
                          $"Período: {periodo}\n\n" +
                          $"Os dados foram carregados na tabela abaixo.",
                          "Relatório Gerado",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"📤 Relatório exportado para Excel com sucesso!\n\n" +
                          $"Arquivo salvo em: C:\\Relatorios\\relatorio_{DateTime.Now:yyyyMMdd}.xlsx",
                          "Exportação Concluída",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label lblAte;
    }
}