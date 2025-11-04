using System;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    partial class FormReservas
    {
        private System.ComponentModel.IContainer components = null;
        protected System.Windows.Forms.DataGridView dgvReservas;
        protected System.Windows.Forms.Button btnNovaReserva;
        protected System.Windows.Forms.Button btnEditarReserva;
        protected System.Windows.Forms.Button btnConcluirReserva;
        protected System.Windows.Forms.Button btnCancelarReserva;
        protected System.Windows.Forms.Button btnApagarReserva;
        protected System.Windows.Forms.Button btnFechar;
        protected System.Windows.Forms.Button btnRelatorio;
        protected System.Windows.Forms.Button btnAtualizar;
        protected System.Windows.Forms.Label lblTitulo;
        protected System.Windows.Forms.Label lblFiltro;
        protected System.Windows.Forms.ComboBox cmbFiltroStatus;
        protected System.Windows.Forms.DateTimePicker dtpFiltroData;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnLimparFiltro;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cmbFiltroStatus = new System.Windows.Forms.ComboBox();
            this.dtpFiltroData = new System.Windows.Forms.DateTimePicker();
            this.btnLimparFiltro = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.btnNovaReserva = new System.Windows.Forms.Button();
            this.btnEditarReserva = new System.Windows.Forms.Button();
            this.btnConcluirReserva = new System.Windows.Forms.Button();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnApagarReserva = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📅 GERENCIAR RESERVAS";
            // 
            // lblFiltro
            // 
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltro.Location = new System.Drawing.Point(520, 25);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(70, 20);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "Filtrar por:";
            // 
            // cmbFiltroStatus
            // 
            this.cmbFiltroStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroStatus.FormattingEnabled = true;
            this.cmbFiltroStatus.Items.AddRange(new object[] {
            "Todas",
            "🟢 CONFIRMADA",
            "🟡 PENDENTE",
            "✅ CONCLUÍDA",
            "❌ CANCELADA"});
            this.cmbFiltroStatus.Location = new System.Drawing.Point(595, 22);
            this.cmbFiltroStatus.Name = "cmbFiltroStatus";
            this.cmbFiltroStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbFiltroStatus.TabIndex = 2;
            this.cmbFiltroStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroStatus_SelectedIndexChanged);
            // 
            // dtpFiltroData
            // 
            this.dtpFiltroData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroData.Location = new System.Drawing.Point(755, 22);
            this.dtpFiltroData.Name = "dtpFiltroData";
            this.dtpFiltroData.Size = new System.Drawing.Size(120, 20);
            this.dtpFiltroData.TabIndex = 3;
            this.dtpFiltroData.ValueChanged += new System.EventHandler(this.dtpFiltroData_ValueChanged);
            // 
            // btnLimparFiltro
            // 
            this.btnLimparFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparFiltro.Location = new System.Drawing.Point(885, 22);
            this.btnLimparFiltro.Name = "btnLimparFiltro";
            this.btnLimparFiltro.Size = new System.Drawing.Size(35, 25);
            this.btnLimparFiltro.TabIndex = 4;
            this.btnLimparFiltro.Text = "🔄";
            this.btnLimparFiltro.UseVisualStyleBackColor = true;
            this.btnLimparFiltro.Click += new System.EventHandler(this.btnLimparFiltro_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvReservas);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1050, 450);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Reservas";
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservas.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(15, 25);
            this.dgvReservas.MultiSelect = false;
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersVisible = false;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(1020, 410);
            this.dgvReservas.TabIndex = 0;
            this.dgvReservas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservas_CellDoubleClick);
            this.dgvReservas.SelectionChanged += new System.EventHandler(this.dgvReservas_SelectionChanged);
            // 
            // btnNovaReserva
            // 
            this.btnNovaReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNovaReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaReserva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNovaReserva.ForeColor = System.Drawing.Color.White;
            this.btnNovaReserva.Location = new System.Drawing.Point(20, 525);
            this.btnNovaReserva.Name = "btnNovaReserva";
            this.btnNovaReserva.Size = new System.Drawing.Size(160, 40);
            this.btnNovaReserva.TabIndex = 6;
            this.btnNovaReserva.Text = "➕ NOVA RESERVA";
            this.btnNovaReserva.UseVisualStyleBackColor = false;
            this.btnNovaReserva.Click += new System.EventHandler(this.btnNovaReserva_Click);
            // 
            // btnEditarReserva
            // 
            this.btnEditarReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEditarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarReserva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarReserva.ForeColor = System.Drawing.Color.Black;
            this.btnEditarReserva.Location = new System.Drawing.Point(190, 525);
            this.btnEditarReserva.Name = "btnEditarReserva";
            this.btnEditarReserva.Size = new System.Drawing.Size(120, 40);
            this.btnEditarReserva.TabIndex = 7;
            this.btnEditarReserva.Text = "✏️ EDITAR";
            this.btnEditarReserva.UseVisualStyleBackColor = false;
            this.btnEditarReserva.Click += new System.EventHandler(this.btnEditarReserva_Click);
            // 
            // btnConcluirReserva
            // 
            this.btnConcluirReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnConcluirReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluirReserva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConcluirReserva.ForeColor = System.Drawing.Color.White;
            this.btnConcluirReserva.Location = new System.Drawing.Point(320, 525);
            this.btnConcluirReserva.Name = "btnConcluirReserva";
            this.btnConcluirReserva.Size = new System.Drawing.Size(120, 40);
            this.btnConcluirReserva.TabIndex = 8;
            this.btnConcluirReserva.Text = "✅ CONCLUIR";
            this.btnConcluirReserva.UseVisualStyleBackColor = false;
            this.btnConcluirReserva.Click += new System.EventHandler(this.btnConcluirReserva_Click);
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancelarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarReserva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelarReserva.ForeColor = System.Drawing.Color.White;
            this.btnCancelarReserva.Location = new System.Drawing.Point(450, 525);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(120, 40);
            this.btnCancelarReserva.TabIndex = 9;
            this.btnCancelarReserva.Text = "❌ CANCELAR";
            this.btnCancelarReserva.UseVisualStyleBackColor = false;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
            // 
            // btnApagarReserva
            // 
            this.btnApagarReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnApagarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApagarReserva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApagarReserva.ForeColor = System.Drawing.Color.White;
            this.btnApagarReserva.Location = new System.Drawing.Point(580, 525);
            this.btnApagarReserva.Name = "btnApagarReserva";
            this.btnApagarReserva.Size = new System.Drawing.Size(120, 40);
            this.btnApagarReserva.TabIndex = 10;
            this.btnApagarReserva.Text = "🗑️ APAGAR";
            this.btnApagarReserva.UseVisualStyleBackColor = false;
            this.btnApagarReserva.Click += new System.EventHandler(this.btnApagarReserva_Click_1);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.btnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRelatorio.ForeColor = System.Drawing.Color.White;
            this.btnRelatorio.Location = new System.Drawing.Point(710, 525);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(140, 40);
            this.btnRelatorio.TabIndex = 11;
            this.btnRelatorio.Text = "📊 RELATÓRIO";
            this.btnRelatorio.UseVisualStyleBackColor = false;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(860, 525);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(140, 40);
            this.btnAtualizar.TabIndex = 12;
            this.btnAtualizar.Text = "🔄 ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1010, 525);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 40);
            this.btnFechar.TabIndex = 13;
            this.btnFechar.Text = "🔙 VOLTAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormReservas
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1150, 650);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.btnApagarReserva);
            this.Controls.Add(this.btnCancelarReserva);
            this.Controls.Add(this.btnConcluirReserva);
            this.Controls.Add(this.btnEditarReserva);
            this.Controls.Add(this.btnNovaReserva);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLimparFiltro);
            this.Controls.Add(this.dtpFiltroData);
            this.Controls.Add(this.cmbFiltroStatus);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📅 Reservas - Lan House System";
            this.Load += new System.EventHandler(this.FormReservas_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.ResumeLayout(false);

        }
    }
}