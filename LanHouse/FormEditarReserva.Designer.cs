namespace lanhause
{
    partial class FormEditarReserva
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblComputador;
        private System.Windows.Forms.Label lblClienteNome;
        private System.Windows.Forms.Label lblClienteEmail;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.Label lblHoraFim;
        private System.Windows.Forms.Label lblHorasTitulo;
        private System.Windows.Forms.Label lblValorTitulo;
        protected System.Windows.Forms.ComboBox cmbComputadores;
        protected System.Windows.Forms.TextBox txtClienteNome;
        protected System.Windows.Forms.TextBox txtClienteEmail;
        protected System.Windows.Forms.DateTimePicker dtpData;
        protected System.Windows.Forms.ComboBox cmbHoraInicio;
        protected System.Windows.Forms.ComboBox cmbHoraFim;
        protected System.Windows.Forms.Label lblHoras;
        protected System.Windows.Forms.Label lblValor;
        protected System.Windows.Forms.Button btnSalvar;
        protected System.Windows.Forms.Button btnCancelar;

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
            this.lblComputador = new System.Windows.Forms.Label();
            this.cmbComputadores = new System.Windows.Forms.ComboBox();
            this.lblClienteNome = new System.Windows.Forms.Label();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.lblClienteEmail = new System.Windows.Forms.Label();
            this.txtClienteEmail = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.cmbHoraInicio = new System.Windows.Forms.ComboBox();
            this.lblHoraFim = new System.Windows.Forms.Label();
            this.cmbHoraFim = new System.Windows.Forms.ComboBox();
            this.lblHorasTitulo = new System.Windows.Forms.Label();
            this.lblHoras = new System.Windows.Forms.Label();
            this.lblValorTitulo = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "✏️ EDITAR RESERVA";
            // 
            // lblComputador
            // 
            this.lblComputador.Location = new System.Drawing.Point(20, 70);
            this.lblComputador.Name = "lblComputador";
            this.lblComputador.Size = new System.Drawing.Size(100, 20);
            this.lblComputador.TabIndex = 1;
            this.lblComputador.Text = "Computador:";
            // 
            // cmbComputadores
            // 
            this.cmbComputadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComputadores.Location = new System.Drawing.Point(120, 67);
            this.cmbComputadores.Name = "cmbComputadores";
            this.cmbComputadores.Size = new System.Drawing.Size(250, 21);
            this.cmbComputadores.TabIndex = 2;
            this.cmbComputadores.SelectedIndexChanged += new System.EventHandler(this.cmbComputadores_SelectedIndexChanged);
            // 
            // lblClienteNome
            // 
            this.lblClienteNome.Location = new System.Drawing.Point(20, 110);
            this.lblClienteNome.Name = "lblClienteNome";
            this.lblClienteNome.Size = new System.Drawing.Size(100, 20);
            this.lblClienteNome.TabIndex = 3;
            this.lblClienteNome.Text = "Nome Cliente:";
            // 
            // txtClienteNome
            // 
            this.txtClienteNome.Location = new System.Drawing.Point(120, 107);
            this.txtClienteNome.Name = "txtClienteNome";
            this.txtClienteNome.Size = new System.Drawing.Size(250, 20);
            this.txtClienteNome.TabIndex = 4;
            // 
            // lblClienteEmail
            // 
            this.lblClienteEmail.Location = new System.Drawing.Point(20, 150);
            this.lblClienteEmail.Name = "lblClienteEmail";
            this.lblClienteEmail.Size = new System.Drawing.Size(100, 20);
            this.lblClienteEmail.TabIndex = 5;
            this.lblClienteEmail.Text = "E-mail:";
            // 
            // txtClienteEmail
            // 
            this.txtClienteEmail.Location = new System.Drawing.Point(120, 147);
            this.txtClienteEmail.Name = "txtClienteEmail";
            this.txtClienteEmail.Size = new System.Drawing.Size(250, 20);
            this.txtClienteEmail.TabIndex = 6;
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(20, 190);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(100, 20);
            this.lblData.TabIndex = 7;
            this.lblData.Text = "Data:";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(120, 187);
            this.dtpData.MinDate = new System.DateTime(2025, 11, 4, 0, 0, 0, 0);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(120, 20);
            this.dtpData.TabIndex = 8;
            this.dtpData.ValueChanged += new System.EventHandler(this.dtpData_ValueChanged);
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.Location = new System.Drawing.Point(20, 230);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(100, 20);
            this.lblHoraInicio.TabIndex = 9;
            this.lblHoraInicio.Text = "Hora Início:";
            // 
            // cmbHoraInicio
            // 
            this.cmbHoraInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraInicio.Location = new System.Drawing.Point(120, 227);
            this.cmbHoraInicio.Name = "cmbHoraInicio";
            this.cmbHoraInicio.Size = new System.Drawing.Size(100, 21);
            this.cmbHoraInicio.TabIndex = 10;
            this.cmbHoraInicio.SelectedIndexChanged += new System.EventHandler(this.cmbHoraInicio_SelectedIndexChanged);
            // 
            // lblHoraFim
            // 
            this.lblHoraFim.Location = new System.Drawing.Point(20, 270);
            this.lblHoraFim.Name = "lblHoraFim";
            this.lblHoraFim.Size = new System.Drawing.Size(100, 20);
            this.lblHoraFim.TabIndex = 11;
            this.lblHoraFim.Text = "Hora Fim:";
            // 
            // cmbHoraFim
            // 
            this.cmbHoraFim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraFim.Location = new System.Drawing.Point(120, 267);
            this.cmbHoraFim.Name = "cmbHoraFim";
            this.cmbHoraFim.Size = new System.Drawing.Size(100, 21);
            this.cmbHoraFim.TabIndex = 12;
            this.cmbHoraFim.SelectedIndexChanged += new System.EventHandler(this.cmbHoraFim_SelectedIndexChanged);
            // 
            // lblHorasTitulo
            // 
            this.lblHorasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHorasTitulo.Location = new System.Drawing.Point(20, 310);
            this.lblHorasTitulo.Name = "lblHorasTitulo";
            this.lblHorasTitulo.Size = new System.Drawing.Size(100, 20);
            this.lblHorasTitulo.TabIndex = 13;
            this.lblHorasTitulo.Text = "Horas Totais:";
            // 
            // lblHoras
            // 
            this.lblHoras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoras.ForeColor = System.Drawing.Color.Blue;
            this.lblHoras.Location = new System.Drawing.Point(120, 307);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(150, 25);
            this.lblHoras.TabIndex = 14;
            this.lblHoras.Text = "0 horas";
            // 
            // lblValorTitulo
            // 
            this.lblValorTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValorTitulo.Location = new System.Drawing.Point(20, 340);
            this.lblValorTitulo.Name = "lblValorTitulo";
            this.lblValorTitulo.Size = new System.Drawing.Size(100, 20);
            this.lblValorTitulo.TabIndex = 15;
            this.lblValorTitulo.Text = "Valor Total:";
            // 
            // lblValor
            // 
            this.lblValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.Green;
            this.lblValor.Location = new System.Drawing.Point(120, 337);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(150, 25);
            this.lblValor.TabIndex = 16;
            this.lblValor.Text = "R$ 0,00";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(120, 390);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 40);
            this.btnSalvar.TabIndex = 17;
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
            this.btnCancelar.Location = new System.Drawing.Point(250, 390);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "❌ CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;

            // 
            // FormEditarReserva
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 530);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblComputador);
            this.Controls.Add(this.cmbComputadores);
            this.Controls.Add(this.lblClienteNome);
            this.Controls.Add(this.txtClienteNome);
            this.Controls.Add(this.lblClienteEmail);
            this.Controls.Add(this.txtClienteEmail);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.lblHoraInicio);
            this.Controls.Add(this.cmbHoraInicio);
            this.Controls.Add(this.lblHoraFim);
            this.Controls.Add(this.cmbHoraFim);
            this.Controls.Add(this.lblHorasTitulo);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.lblValorTitulo);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormEditarReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "✏️ Editar Reserva - Lan House System";
            this.Load += new System.EventHandler(this.FormEditarReserva_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}