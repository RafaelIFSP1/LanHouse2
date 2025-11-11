using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    partial class FormNovoComputador
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelCabecalho;
        private Label lblTitulo;
        private Panel panelConteudo;
        private TextBox txtNome;
        private TextBox txtProcessador;
        private TextBox txtRAM;
        private TextBox txtPrecoHora;
        private ComboBox cmbStatus;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label lblNome;
        private Label lblProcessador;
        private Label lblRAM;
        private Label lblPrecoHora;
        private Label lblStatus;

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
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtPrecoHora = new System.Windows.Forms.TextBox();
            this.txtRAM = new System.Windows.Forms.TextBox();
            this.txtProcessador = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPrecoHora = new System.Windows.Forms.Label();
            this.lblRAM = new System.Windows.Forms.Label();
            this.lblProcessador = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.panelCabecalho.SuspendLayout();
            this.panelConteudo.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelCabecalho
            // 
            this.panelCabecalho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.panelCabecalho.Controls.Add(this.lblTitulo);
            this.panelCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecalho.Location = new System.Drawing.Point(0, 0);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(500, 60);
            this.panelCabecalho.TabIndex = 0;
            this.panelCabecalho.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCabecalho_Paint);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "➕ NOVO COMPUTADOR";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelConteudo
            // 
            this.panelConteudo.BackColor = System.Drawing.Color.White;
            this.panelConteudo.Controls.Add(this.cmbStatus);
            this.panelConteudo.Controls.Add(this.txtPrecoHora);
            this.panelConteudo.Controls.Add(this.txtRAM);
            this.panelConteudo.Controls.Add(this.txtProcessador);
            this.panelConteudo.Controls.Add(this.txtNome);
            this.panelConteudo.Controls.Add(this.btnCancelar);
            this.panelConteudo.Controls.Add(this.btnSalvar);
            this.panelConteudo.Controls.Add(this.lblStatus);
            this.panelConteudo.Controls.Add(this.lblPrecoHora);
            this.panelConteudo.Controls.Add(this.lblRAM);
            this.panelConteudo.Controls.Add(this.lblProcessador);
            this.panelConteudo.Controls.Add(this.lblNome);
            this.panelConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConteudo.Location = new System.Drawing.Point(0, 60);
            this.panelConteudo.Name = "panelConteudo";
            this.panelConteudo.Padding = new System.Windows.Forms.Padding(30);
            this.panelConteudo.Size = new System.Drawing.Size(500, 440);
            this.panelConteudo.TabIndex = 1;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "DISPONÍVEL",
            "EM USO",
            "EM MANUTENÇÃO"});
            this.cmbStatus.Location = new System.Drawing.Point(150, 240);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(320, 25);
            this.cmbStatus.TabIndex = 4;
            // 
            // txtPrecoHora
            // 
            this.txtPrecoHora.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecoHora.Location = new System.Drawing.Point(150, 190);
            this.txtPrecoHora.Name = "txtPrecoHora";
            this.txtPrecoHora.Size = new System.Drawing.Size(320, 25);
            this.txtPrecoHora.TabIndex = 3;
            this.txtPrecoHora.Text = "8,00";
            // 
            // txtRAM
            // 
            this.txtRAM.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRAM.Location = new System.Drawing.Point(150, 140);
            this.txtRAM.Name = "txtRAM";
            this.txtRAM.Size = new System.Drawing.Size(320, 25);
            this.txtRAM.TabIndex = 2;
            this.txtRAM.Text = "8GB DDR4";
            // 
            // txtProcessador
            // 
            this.txtProcessador.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProcessador.Location = new System.Drawing.Point(150, 90);
            this.txtProcessador.Name = "txtProcessador";
            this.txtProcessador.Size = new System.Drawing.Size(320, 25);
            this.txtProcessador.TabIndex = 1;
            this.txtProcessador.Text = "Intel i5-10400F";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNome.Location = new System.Drawing.Point(150, 40);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(320, 25);
            this.txtNome.TabIndex = 0;
            this.txtNome.Text = "Computador ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(260, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "❌ CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(120, 320);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 40);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "💾 SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblStatus.Location = new System.Drawing.Point(30, 240);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 25);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrecoHora
            // 
            this.lblPrecoHora.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrecoHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblPrecoHora.Location = new System.Drawing.Point(30, 190);
            this.lblPrecoHora.Name = "lblPrecoHora";
            this.lblPrecoHora.Size = new System.Drawing.Size(120, 25);
            this.lblPrecoHora.TabIndex = 3;
            this.lblPrecoHora.Text = "Preço/Hora:";
            this.lblPrecoHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRAM
            // 
            this.lblRAM.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblRAM.Location = new System.Drawing.Point(30, 140);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(120, 25);
            this.lblRAM.TabIndex = 2;
            this.lblRAM.Text = "Memória RAM:";
            this.lblRAM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProcessador
            // 
            this.lblProcessador.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProcessador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblProcessador.Location = new System.Drawing.Point(30, 90);
            this.lblProcessador.Name = "lblProcessador";
            this.lblProcessador.Size = new System.Drawing.Size(120, 25);
            this.lblProcessador.TabIndex = 1;
            this.lblProcessador.Text = "Processador:";
            this.lblProcessador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNome
            // 
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblNome.Location = new System.Drawing.Point(30, 40);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(120, 25);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormNovoComputador
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.panelConteudo);
            this.Controls.Add(this.panelCabecalho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNovoComputador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Novo Computador - Lan House System";
            this.Load += new System.EventHandler(this.FormNovoComputador_Load);
            this.panelCabecalho.ResumeLayout(false);
            this.panelConteudo.ResumeLayout(false);
            this.panelConteudo.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}