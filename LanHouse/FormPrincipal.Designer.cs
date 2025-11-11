namespace lanhause
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.lblBemVindo = new System.Windows.Forms.Label();
            this.panelBotoes = new System.Windows.Forms.Panel();
            this.btnReservas = new System.Windows.Forms.Button();
            this.btnComputadores = new System.Windows.Forms.Button();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.btnGerenciarUsuarios = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelCabecalho.SuspendLayout();
            this.panelBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarUsuarioToolStripMenuItem,
            this.gerenciarUsuariosToolStripMenuItem});
            this.usuariosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuários";
            // 
            // cadastrarUsuarioToolStripMenuItem
            // 
            this.cadastrarUsuarioToolStripMenuItem.Name = "cadastrarUsuarioToolStripMenuItem";
            this.cadastrarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cadastrarUsuarioToolStripMenuItem.Text = "Cadastrar Usuário";
            this.cadastrarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.cadastrarUsuarioToolStripMenuItem_Click);
            // 
            // gerenciarUsuariosToolStripMenuItem
            // 
            this.gerenciarUsuariosToolStripMenuItem.Name = "gerenciarUsuariosToolStripMenuItem";
            this.gerenciarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.gerenciarUsuariosToolStripMenuItem.Text = "Gerenciar Usuários";
            this.gerenciarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gerenciarUsuariosToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelCabecalho.Controls.Add(this.lblTipoUsuario);
            this.panelCabecalho.Controls.Add(this.lblBemVindo);
            this.panelCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecalho.Location = new System.Drawing.Point(0, 24);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(1000, 80);
            this.panelCabecalho.TabIndex = 1;
            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.AutoSize = true;
            this.lblTipoUsuario.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoUsuario.ForeColor = System.Drawing.Color.White;
            this.lblTipoUsuario.Location = new System.Drawing.Point(30, 45);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(46, 20);
            this.lblTipoUsuario.TabIndex = 1;
            this.lblTipoUsuario.Text = "Tipo: ";
            // 
            // lblBemVindo
            // 
            this.lblBemVindo.AutoSize = true;
            this.lblBemVindo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBemVindo.ForeColor = System.Drawing.Color.White;
            this.lblBemVindo.Location = new System.Drawing.Point(28, 15);
            this.lblBemVindo.Name = "lblBemVindo";
            this.lblBemVindo.Size = new System.Drawing.Size(133, 30);
            this.lblBemVindo.TabIndex = 0;
            this.lblBemVindo.Text = "Bem-vindo!";
            // 
            // panelBotoes
            // 
            this.panelBotoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.panelBotoes.Controls.Add(this.btnReservas);
            this.panelBotoes.Controls.Add(this.btnComputadores);
            this.panelBotoes.Controls.Add(this.btnRelatorios);
            this.panelBotoes.Controls.Add(this.btnGerenciarUsuarios);
            this.panelBotoes.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBotoes.Location = new System.Drawing.Point(0, 104);
            this.panelBotoes.Name = "panelBotoes";
            this.panelBotoes.Size = new System.Drawing.Size(200, 557);
            this.panelBotoes.TabIndex = 2;
            // 
            // btnReservas
            // 
            this.btnReservas.BackColor = System.Drawing.Color.Transparent;
            this.btnReservas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReservas.FlatAppearance.BorderSize = 0;
            this.btnReservas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnReservas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.btnReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservas.ForeColor = System.Drawing.Color.White;
            this.btnReservas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservas.Location = new System.Drawing.Point(0, 120);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReservas.Size = new System.Drawing.Size(200, 40);
            this.btnReservas.TabIndex = 3;
            this.btnReservas.Text = "   📅 Reservas";
            this.btnReservas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservas.UseVisualStyleBackColor = false;
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            // 
            // btnComputadores
            // 
            this.btnComputadores.BackColor = System.Drawing.Color.Transparent;
            this.btnComputadores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnComputadores.FlatAppearance.BorderSize = 0;
            this.btnComputadores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnComputadores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.btnComputadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputadores.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComputadores.ForeColor = System.Drawing.Color.White;
            this.btnComputadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComputadores.Location = new System.Drawing.Point(0, 80);
            this.btnComputadores.Name = "btnComputadores";
            this.btnComputadores.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnComputadores.Size = new System.Drawing.Size(200, 40);
            this.btnComputadores.TabIndex = 2;
            this.btnComputadores.Text = "   💻 Computadores";
            this.btnComputadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComputadores.UseVisualStyleBackColor = false;
            this.btnComputadores.Click += new System.EventHandler(this.btnComputadores_Click);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.BackColor = System.Drawing.Color.Transparent;
            this.btnRelatorios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRelatorios.FlatAppearance.BorderSize = 0;
            this.btnRelatorios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRelatorios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.btnRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorios.ForeColor = System.Drawing.Color.White;
            this.btnRelatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorios.Location = new System.Drawing.Point(0, 40);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRelatorios.Size = new System.Drawing.Size(200, 40);
            this.btnRelatorios.TabIndex = 1;
            this.btnRelatorios.Text = "   📊 Relatórios";
            this.btnRelatorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorios.UseVisualStyleBackColor = false;
            this.btnRelatorios.Click += new System.EventHandler(this.btnRelatorios_Click);
            // 
            // btnGerenciarUsuarios
            // 
            this.btnGerenciarUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnGerenciarUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGerenciarUsuarios.FlatAppearance.BorderSize = 0;
            this.btnGerenciarUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGerenciarUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.btnGerenciarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerenciarUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerenciarUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnGerenciarUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerenciarUsuarios.Location = new System.Drawing.Point(0, 0);
            this.btnGerenciarUsuarios.Name = "btnGerenciarUsuarios";
            this.btnGerenciarUsuarios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGerenciarUsuarios.Size = new System.Drawing.Size(200, 40);
            this.btnGerenciarUsuarios.TabIndex = 0;
            this.btnGerenciarUsuarios.Text = "   👥 Gerenciar Usuários";
            this.btnGerenciarUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerenciarUsuarios.UseVisualStyleBackColor = false;
            this.btnGerenciarUsuarios.Click += new System.EventHandler(this.btnGerenciarUsuarios_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1000, 661);
            this.Controls.Add(this.panelBotoes);
            this.Controls.Add(this.panelCabecalho);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1016, 700);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema LanHouse - Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelCabecalho.ResumeLayout(false);
            this.panelCabecalho.PerformLayout();
            this.panelBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.Panel panelCabecalho;
        private System.Windows.Forms.Label lblBemVindo;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.Panel panelBotoes;
        private System.Windows.Forms.Button btnGerenciarUsuarios;
        private System.Windows.Forms.Button btnRelatorios;
        private System.Windows.Forms.Button btnComputadores;
        private System.Windows.Forms.Button btnReservas;
    }
}