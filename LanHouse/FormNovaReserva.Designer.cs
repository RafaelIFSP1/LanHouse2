using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    partial class FormNovaReserva
    {
        private System.ComponentModel.IContainer components = null;
        protected Label lblTitulo;
        protected TextBox txtClienteNome;
        protected TextBox txtClienteEmail;
        protected DateTimePicker dtpData;
        protected ComboBox cmbComputadores;
        protected ComboBox cmbHoraInicio;
        protected ComboBox cmbHoraFim;
        protected Label lblHoras;
        protected Label lblValor;
        protected Button btnSalvar;
        protected Button btnCancelar;
        protected Label lblClienteNome;
        protected Label lblClienteEmail;
        protected Label lblData;
        protected Label lblComputador;
        protected Label lblHoraInicio;
        protected Label lblHoraFim;
        protected Label lblDuracao;
        protected Label lblValorTotal;

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
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.txtClienteEmail = new System.Windows.Forms.TextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.cmbComputadores = new System.Windows.Forms.ComboBox();
            this.cmbHoraInicio = new System.Windows.Forms.ComboBox();
            this.cmbHoraFim = new System.Windows.Forms.ComboBox();
            this.lblHoras = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblClienteNome = new System.Windows.Forms.Label();
            this.lblClienteEmail = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblComputador = new System.Windows.Forms.Label();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.lblHoraFim = new System.Windows.Forms.Label();
            this.lblDuracao = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "➕ NOVA RESERVA";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClienteNome
            // 
            this.txtClienteNome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClienteNome.Location = new System.Drawing.Point(200, 80);
            this.txtClienteNome.Name = "txtClienteNome";
            this.txtClienteNome.Size = new System.Drawing.Size(300, 25);
            this.txtClienteNome.TabIndex = 1;
            // 
            // txtClienteEmail
            // 
            this.txtClienteEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClienteEmail.Location = new System.Drawing.Point(200, 120);
            this.txtClienteEmail.Name = "txtClienteEmail";
            this.txtClienteEmail.Size = new System.Drawing.Size(300, 25);
            this.txtClienteEmail.TabIndex = 2;
            // 
            // dtpData
            // 
            this.dtpData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(200, 160);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(150, 25);
            this.dtpData.TabIndex = 3;
            this.dtpData.ValueChanged += new System.EventHandler(this.dtpData_ValueChanged);
            // 
            // cmbComputadores
            // 
            this.cmbComputadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComputadores.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbComputadores.FormattingEnabled = true;
            this.cmbComputadores.Location = new System.Drawing.Point(200, 200);
            this.cmbComputadores.Name = "cmbComputadores";
            this.cmbComputadores.Size = new System.Drawing.Size(300, 25);
            this.cmbComputadores.TabIndex = 4;
            this.cmbComputadores.SelectedIndexChanged += new System.EventHandler(this.cmbComputadores_SelectedIndexChanged);
            // 
            // cmbHoraInicio
            // 
            this.cmbHoraInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbHoraInicio.FormattingEnabled = true;
            this.cmbHoraInicio.Location = new System.Drawing.Point(200, 240);
            this.cmbHoraInicio.Name = "cmbHoraInicio";
            this.cmbHoraInicio.Size = new System.Drawing.Size(120, 25);
            this.cmbHoraInicio.TabIndex = 5;
            this.cmbHoraInicio.SelectedIndexChanged += new System.EventHandler(this.cmbHoraInicio_SelectedIndexChanged);
            // 
            // cmbHoraFim
            // 
            this.cmbHoraFim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraFim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbHoraFim.FormattingEnabled = true;
            this.cmbHoraFim.Location = new System.Drawing.Point(380, 240);
            this.cmbHoraFim.Name = "cmbHoraFim";
            this.cmbHoraFim.Size = new System.Drawing.Size(120, 25);
            this.cmbHoraFim.TabIndex = 6;
            this.cmbHoraFim.SelectedIndexChanged += new System.EventHandler(this.cmbHoraFim_SelectedIndexChanged);
            // 
            // lblHoras
            // 
            this.lblHoras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblHoras.Location = new System.Drawing.Point(200, 280);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(300, 25);
            this.lblHoras.TabIndex = 7;
            this.lblHoras.Text = "0 horas (0.0h)";
            // 
            // lblValor
            // 
            this.lblValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblValor.Location = new System.Drawing.Point(200, 320);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(300, 25);
            this.lblValor.TabIndex = 8;
            this.lblValor.Text = "R$ 0,00";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(320, 380);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 40);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "💾 SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(460, 380);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "❌ CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblClienteNome
            // 
            this.lblClienteNome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClienteNome.Location = new System.Drawing.Point(40, 80);
            this.lblClienteNome.Name = "lblClienteNome";
            this.lblClienteNome.Size = new System.Drawing.Size(150, 25);
            this.lblClienteNome.TabIndex = 11;
            this.lblClienteNome.Text = "Nome do Cliente:";
            this.lblClienteNome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClienteEmail
            // 
            this.lblClienteEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClienteEmail.Location = new System.Drawing.Point(40, 120);
            this.lblClienteEmail.Name = "lblClienteEmail";
            this.lblClienteEmail.Size = new System.Drawing.Size(150, 25);
            this.lblClienteEmail.TabIndex = 12;
            this.lblClienteEmail.Text = "E-mail:";
            this.lblClienteEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblData
            // 
            this.lblData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblData.Location = new System.Drawing.Point(40, 160);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(150, 25);
            this.lblData.TabIndex = 13;
            this.lblData.Text = "Data:";
            this.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblComputador
            // 
            this.lblComputador.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblComputador.Location = new System.Drawing.Point(40, 200);
            this.lblComputador.Name = "lblComputador";
            this.lblComputador.Size = new System.Drawing.Size(150, 25);
            this.lblComputador.TabIndex = 14;
            this.lblComputador.Text = "Computador:";
            this.lblComputador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoraInicio.Location = new System.Drawing.Point(40, 240);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(150, 25);
            this.lblHoraInicio.TabIndex = 15;
            this.lblHoraInicio.Text = "Horário:";
            this.lblHoraInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHoraFim
            // 
            this.lblHoraFim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHoraFim.Location = new System.Drawing.Point(330, 240);
            this.lblHoraFim.Name = "lblHoraFim";
            this.lblHoraFim.Size = new System.Drawing.Size(40, 25);
            this.lblHoraFim.TabIndex = 16;
            this.lblHoraFim.Text = "até";
            this.lblHoraFim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDuracao
            // 
            this.lblDuracao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDuracao.Location = new System.Drawing.Point(40, 280);
            this.lblDuracao.Name = "lblDuracao";
            this.lblDuracao.Size = new System.Drawing.Size(150, 25);
            this.lblDuracao.TabIndex = 17;
            this.lblDuracao.Text = "Duração:";
            this.lblDuracao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.Location = new System.Drawing.Point(40, 320);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(150, 25);
            this.lblValorTotal.TabIndex = 18;
            this.lblValorTotal.Text = "Valor Total:";
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormNovaReserva
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblDuracao);
            this.Controls.Add(this.lblHoraFim);
            this.Controls.Add(this.lblHoraInicio);
            this.Controls.Add(this.lblComputador);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblClienteEmail);
            this.Controls.Add(this.lblClienteNome);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.cmbHoraFim);
            this.Controls.Add(this.cmbHoraInicio);
            this.Controls.Add(this.cmbComputadores);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.txtClienteEmail);
            this.Controls.Add(this.txtClienteNome);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormNovaReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "➕ Nova Reserva - Lan House System";
            this.Load += new System.EventHandler(this.FormNovaReserva_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}