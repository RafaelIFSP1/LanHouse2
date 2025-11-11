using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    partial class FormComputadores
    {
        private System.ComponentModel.IContainer components = null;
        protected Panel panelCabecalho;
        protected Label lblTitulo;
        protected Panel panelLista;
        protected ListView listViewComputadores;
        protected Panel panelDetalhes;
        protected Button btnFechar;
        protected Button btnAdicionar;
        protected Button btnEditar;
        protected Button btnManutencao;
        protected Button btnAjustarStatus;

        // Controles de detalhes
        protected Label lblDetalhesTitulo;
        protected Label lblInfoProcessador;
        protected Label lblInfoRAM;
        protected Label lblInfoStatus;
        protected Label lblInfoPreco;
        protected Label lblInfoReservas;
        protected Label lblInfoUso;
        protected Label lblStatusVisual;
        protected Label lblProcessadorTitulo;
        protected Label lblRAMPtitulo;
        protected Label lblStatusTitulo;
        protected Label lblPrecoTitulo;
        protected Label lblReservasTitulo;
        protected Label lblUsoTitulo;

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
            this.panelLista = new System.Windows.Forms.Panel();
            this.listViewComputadores = new System.Windows.Forms.ListView();
            this.panelDetalhes = new System.Windows.Forms.Panel();
            this.lblDetalhesTitulo = new System.Windows.Forms.Label();
            this.lblProcessadorTitulo = new System.Windows.Forms.Label();
            this.lblInfoProcessador = new System.Windows.Forms.Label();
            this.lblRAMPtitulo = new System.Windows.Forms.Label();
            this.lblInfoRAM = new System.Windows.Forms.Label();
            this.lblStatusTitulo = new System.Windows.Forms.Label();
            this.lblInfoStatus = new System.Windows.Forms.Label();
            this.lblPrecoTitulo = new System.Windows.Forms.Label();
            this.lblInfoPreco = new System.Windows.Forms.Label();
            this.lblReservasTitulo = new System.Windows.Forms.Label();
            this.lblInfoReservas = new System.Windows.Forms.Label();
            this.lblUsoTitulo = new System.Windows.Forms.Label();
            this.lblInfoUso = new System.Windows.Forms.Label();
            this.lblStatusVisual = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnAjustarStatus = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnManutencao = new System.Windows.Forms.Button();
            this.panelCabecalho.SuspendLayout();
            this.panelLista.SuspendLayout();
            this.panelDetalhes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelCabecalho.Controls.Add(this.lblTitulo);
            this.panelCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecalho.Location = new System.Drawing.Point(0, 0);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(984, 80);
            this.panelCabecalho.TabIndex = 0;
            this.panelCabecalho.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCabecalho_Paint);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🖥️ GERENCIAR COMPUTADORES";
            // 
            // panelLista
            // 
            this.panelLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.panelLista.Controls.Add(this.listViewComputadores);
            this.panelLista.Location = new System.Drawing.Point(20, 100);
            this.panelLista.Name = "panelLista";
            this.panelLista.Size = new System.Drawing.Size(300, 400);
            this.panelLista.TabIndex = 1;
            // 
            // listViewComputadores
            // 
            this.listViewComputadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.listViewComputadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewComputadores.ForeColor = System.Drawing.Color.White;
            this.listViewComputadores.FullRowSelect = true;
            this.listViewComputadores.HideSelection = false;
            this.listViewComputadores.Location = new System.Drawing.Point(10, 10);
            this.listViewComputadores.Name = "listViewComputadores";
            this.listViewComputadores.Size = new System.Drawing.Size(280, 380);
            this.listViewComputadores.TabIndex = 0;
            this.listViewComputadores.UseCompatibleStateImageBehavior = false;
            this.listViewComputadores.View = System.Windows.Forms.View.Details;
            this.listViewComputadores.SelectedIndexChanged += new System.EventHandler(this.listViewComputadores_SelectedIndexChanged);
            // 
            // panelDetalhes
            // 
            this.panelDetalhes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelDetalhes.Controls.Add(this.lblDetalhesTitulo);
            this.panelDetalhes.Controls.Add(this.lblProcessadorTitulo);
            this.panelDetalhes.Controls.Add(this.lblInfoProcessador);
            this.panelDetalhes.Controls.Add(this.lblRAMPtitulo);
            this.panelDetalhes.Controls.Add(this.lblInfoRAM);
            this.panelDetalhes.Controls.Add(this.lblStatusTitulo);
            this.panelDetalhes.Controls.Add(this.lblInfoStatus);
            this.panelDetalhes.Controls.Add(this.lblPrecoTitulo);
            this.panelDetalhes.Controls.Add(this.lblInfoPreco);
            this.panelDetalhes.Controls.Add(this.lblReservasTitulo);
            this.panelDetalhes.Controls.Add(this.lblInfoReservas);
            this.panelDetalhes.Controls.Add(this.lblUsoTitulo);
            this.panelDetalhes.Controls.Add(this.lblInfoUso);
            this.panelDetalhes.Controls.Add(this.lblStatusVisual);
            this.panelDetalhes.Location = new System.Drawing.Point(340, 100);
            this.panelDetalhes.Name = "panelDetalhes";
            this.panelDetalhes.Size = new System.Drawing.Size(630, 400);
            this.panelDetalhes.TabIndex = 2;
            // 
            // lblDetalhesTitulo
            // 
            this.lblDetalhesTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDetalhesTitulo.ForeColor = System.Drawing.Color.White;
            this.lblDetalhesTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblDetalhesTitulo.Name = "lblDetalhesTitulo";
            this.lblDetalhesTitulo.Size = new System.Drawing.Size(400, 35);
            this.lblDetalhesTitulo.TabIndex = 0;
            this.lblDetalhesTitulo.Text = "Detalhes do Computador";
            // 
            // lblProcessadorTitulo
            // 
            this.lblProcessadorTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProcessadorTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblProcessadorTitulo.Location = new System.Drawing.Point(20, 70);
            this.lblProcessadorTitulo.Name = "lblProcessadorTitulo";
            this.lblProcessadorTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblProcessadorTitulo.TabIndex = 1;
            this.lblProcessadorTitulo.Text = "Processador:";
            // 
            // lblInfoProcessador
            // 
            this.lblInfoProcessador.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoProcessador.ForeColor = System.Drawing.Color.White;
            this.lblInfoProcessador.Location = new System.Drawing.Point(180, 70);
            this.lblInfoProcessador.Name = "lblInfoProcessador";
            this.lblInfoProcessador.Size = new System.Drawing.Size(300, 20);
            this.lblInfoProcessador.TabIndex = 2;
            this.lblInfoProcessador.Text = "Intel i5-10400F";
            // 
            // lblRAMPtitulo
            // 
            this.lblRAMPtitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRAMPtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblRAMPtitulo.Location = new System.Drawing.Point(20, 110);
            this.lblRAMPtitulo.Name = "lblRAMPtitulo";
            this.lblRAMPtitulo.Size = new System.Drawing.Size(150, 20);
            this.lblRAMPtitulo.TabIndex = 3;
            this.lblRAMPtitulo.Text = "Memória RAM:";
            // 
            // lblInfoRAM
            // 
            this.lblInfoRAM.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoRAM.ForeColor = System.Drawing.Color.White;
            this.lblInfoRAM.Location = new System.Drawing.Point(180, 110);
            this.lblInfoRAM.Name = "lblInfoRAM";
            this.lblInfoRAM.Size = new System.Drawing.Size(300, 20);
            this.lblInfoRAM.TabIndex = 4;
            this.lblInfoRAM.Text = "8GB DDR4 2666MHz";
            // 
            // lblStatusTitulo
            // 
            this.lblStatusTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblStatusTitulo.Location = new System.Drawing.Point(20, 150);
            this.lblStatusTitulo.Name = "lblStatusTitulo";
            this.lblStatusTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblStatusTitulo.TabIndex = 5;
            this.lblStatusTitulo.Text = "Status:";
            // 
            // lblInfoStatus
            // 
            this.lblInfoStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoStatus.ForeColor = System.Drawing.Color.White;
            this.lblInfoStatus.Location = new System.Drawing.Point(180, 150);
            this.lblInfoStatus.Name = "lblInfoStatus";
            this.lblInfoStatus.Size = new System.Drawing.Size(300, 20);
            this.lblInfoStatus.TabIndex = 6;
            this.lblInfoStatus.Text = "🟢 DISPONÍVEL";
            // 
            // lblPrecoTitulo
            // 
            this.lblPrecoTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrecoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblPrecoTitulo.Location = new System.Drawing.Point(20, 190);
            this.lblPrecoTitulo.Name = "lblPrecoTitulo";
            this.lblPrecoTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblPrecoTitulo.TabIndex = 7;
            this.lblPrecoTitulo.Text = "Preço/Hora:";
            // 
            // lblInfoPreco
            // 
            this.lblInfoPreco.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoPreco.ForeColor = System.Drawing.Color.White;
            this.lblInfoPreco.Location = new System.Drawing.Point(180, 190);
            this.lblInfoPreco.Name = "lblInfoPreco";
            this.lblInfoPreco.Size = new System.Drawing.Size(300, 20);
            this.lblInfoPreco.TabIndex = 8;
            this.lblInfoPreco.Text = "R$ 5,00";
            // 
            // lblReservasTitulo
            // 
            this.lblReservasTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReservasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblReservasTitulo.Location = new System.Drawing.Point(20, 230);
            this.lblReservasTitulo.Name = "lblReservasTitulo";
            this.lblReservasTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblReservasTitulo.TabIndex = 9;
            this.lblReservasTitulo.Text = "Reservas Hoje:";
            // 
            // lblInfoReservas
            // 
            this.lblInfoReservas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoReservas.ForeColor = System.Drawing.Color.White;
            this.lblInfoReservas.Location = new System.Drawing.Point(180, 230);
            this.lblInfoReservas.Name = "lblInfoReservas";
            this.lblInfoReservas.Size = new System.Drawing.Size(300, 20);
            this.lblInfoReservas.TabIndex = 10;
            this.lblInfoReservas.Text = "3 reservas";
            // 
            // lblUsoTitulo
            // 
            this.lblUsoTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblUsoTitulo.Location = new System.Drawing.Point(20, 270);
            this.lblUsoTitulo.Name = "lblUsoTitulo";
            this.lblUsoTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblUsoTitulo.TabIndex = 11;
            this.lblUsoTitulo.Text = "Horas de Uso:";
            // 
            // lblInfoUso
            // 
            this.lblInfoUso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoUso.ForeColor = System.Drawing.Color.White;
            this.lblInfoUso.Location = new System.Drawing.Point(180, 270);
            this.lblInfoUso.Name = "lblInfoUso";
            this.lblInfoUso.Size = new System.Drawing.Size(300, 20);
            this.lblInfoUso.TabIndex = 12;
            this.lblInfoUso.Text = "12,5 horas";
            // 
            // lblStatusVisual
            // 
            this.lblStatusVisual.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatusVisual.ForeColor = System.Drawing.Color.Green;
            this.lblStatusVisual.Location = new System.Drawing.Point(20, 320);
            this.lblStatusVisual.Name = "lblStatusVisual";
            this.lblStatusVisual.Size = new System.Drawing.Size(300, 30);
            this.lblStatusVisual.TabIndex = 13;
            this.lblStatusVisual.Text = "● STATUS: DISPONÍVEL";
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(20, 509);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 40);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "🔙 VOLTAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnAjustarStatus
            // 
            this.btnAjustarStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnAjustarStatus.FlatAppearance.BorderSize = 0;
            this.btnAjustarStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustarStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAjustarStatus.ForeColor = System.Drawing.Color.White;
            this.btnAjustarStatus.Location = new System.Drawing.Point(350, 509);
            this.btnAjustarStatus.Name = "btnAjustarStatus";
            this.btnAjustarStatus.Size = new System.Drawing.Size(160, 40);
            this.btnAjustarStatus.TabIndex = 4;
            this.btnAjustarStatus.Text = "🔄 AJUSTAR STATUS";
            this.btnAjustarStatus.UseVisualStyleBackColor = false;
            this.btnAjustarStatus.Click += new System.EventHandler(this.btnAjustarStatus_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAdicionar.FlatAppearance.BorderSize = 0;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(524, 509);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(140, 40);
            this.btnAdicionar.TabIndex = 5;
            this.btnAdicionar.Text = "➕ ADICIONAR";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Location = new System.Drawing.Point(680, 509);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 40);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "✏️ EDITAR";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnManutencao
            // 
            this.btnManutencao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(126)))), ((int)(((byte)(20)))));
            this.btnManutencao.FlatAppearance.BorderSize = 0;
            this.btnManutencao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManutencao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManutencao.ForeColor = System.Drawing.Color.White;
            this.btnManutencao.Location = new System.Drawing.Point(830, 509);
            this.btnManutencao.Name = "btnManutencao";
            this.btnManutencao.Size = new System.Drawing.Size(140, 40);
            this.btnManutencao.TabIndex = 7;
            this.btnManutencao.Text = "🔧 MANUTENÇÃO";
            this.btnManutencao.UseVisualStyleBackColor = false;
            this.btnManutencao.Click += new System.EventHandler(this.btnManutencao_Click);
            // 
            // FormComputadores
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(984, 558);
            this.Controls.Add(this.panelCabecalho);
            this.Controls.Add(this.panelLista);
            this.Controls.Add(this.panelDetalhes);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnAjustarStatus);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnManutencao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormComputadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🖥️ Computadores - Lan House System";
            this.Load += new System.EventHandler(this.FormComputadores_Load);
            this.panelCabecalho.ResumeLayout(false);
            this.panelLista.ResumeLayout(false);
            this.panelDetalhes.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}