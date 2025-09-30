namespace LanHouseSystem
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAtualizarComputadores = new System.Windows.Forms.Button();
            this.btnIniciarSessao = new System.Windows.Forms.Button();
            this.comboBoxClientes = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblComputadores = new System.Windows.Forms.Label();
            this.dataGridViewComputadores = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAtualizarSessoes = new System.Windows.Forms.Button();
            this.btnFinalizarSessao = new System.Windows.Forms.Button();
            this.lblSessoesAtivas = new System.Windows.Forms.Label();
            this.dataGridViewSessoes = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnLimparCliente = new System.Windows.Forms.Button();
            this.btnCadastrarCliente = new System.Windows.Forms.Button();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatorioSessoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatorioClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelData = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerAtualizar = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComputadores)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSessoes)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 537);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAtualizarComputadores);
            this.tabPage1.Controls.Add(this.btnIniciarSessao);
            this.tabPage1.Controls.Add(this.comboBoxClientes);
            this.tabPage1.Controls.Add(this.lblInfo);
            this.tabPage1.Controls.Add(this.lblComputadores);
            this.tabPage1.Controls.Add(this.dataGridViewComputadores);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "🎮 Computadores";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarComputadores
            // 
            this.btnAtualizarComputadores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizarComputadores.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAtualizarComputadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizarComputadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarComputadores.ForeColor = System.Drawing.Color.White;
            this.btnAtualizarComputadores.Location = new System.Drawing.Point(850, 60);
            this.btnAtualizarComputadores.Name = "btnAtualizarComputadores";
            this.btnAtualizarComputadores.Size = new System.Drawing.Size(120, 30);
            this.btnAtualizarComputadores.TabIndex = 5;
            this.btnAtualizarComputadores.Text = "🔄 Atualizar";
            this.btnAtualizarComputadores.UseVisualStyleBackColor = false;
            this.btnAtualizarComputadores.Click += new System.EventHandler(this.btnAtualizarComputadores_Click);
            // 
            // btnIniciarSessao
            // 
            this.btnIniciarSessao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciarSessao.BackColor = System.Drawing.Color.ForestGreen;
            this.btnIniciarSessao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSessao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSessao.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSessao.Location = new System.Drawing.Point(850, 20);
            this.btnIniciarSessao.Name = "btnIniciarSessao";
            this.btnIniciarSessao.Size = new System.Drawing.Size(120, 35);
            this.btnIniciarSessao.TabIndex = 4;
            this.btnIniciarSessao.Text = "🎮 Iniciar";
            this.btnIniciarSessao.UseVisualStyleBackColor = false;
            this.btnIniciarSessao.Click += new System.EventHandler(this.btnIniciarSessao_Click);
            // 
            // comboBoxClientes
            // 
            this.comboBoxClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxClientes.FormattingEnabled = true;
            this.comboBoxClientes.Location = new System.Drawing.Point(20, 60);
            this.comboBoxClientes.Name = "comboBoxClientes";
            this.comboBoxClientes.Size = new System.Drawing.Size(824, 24);
            this.comboBoxClientes.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(17, 40);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(252, 15);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Selecione um computador e cliente para iniciar";
            // 
            // lblComputadores
            // 
            this.lblComputadores.AutoSize = true;
            this.lblComputadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputadores.Location = new System.Drawing.Point(16, 16);
            this.lblComputadores.Name = "lblComputadores";
            this.lblComputadores.Size = new System.Drawing.Size(235, 24);
            this.lblComputadores.TabIndex = 1;
            this.lblComputadores.Text = "Computadores Disponíveis";
            // 
            // dataGridViewComputadores
            // 
            this.dataGridViewComputadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewComputadores.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewComputadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComputadores.Location = new System.Drawing.Point(20, 96);
            this.dataGridViewComputadores.Name = "dataGridViewComputadores";
            this.dataGridViewComputadores.ReadOnly = true;
            this.dataGridViewComputadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewComputadores.Size = new System.Drawing.Size(936, 403);
            this.dataGridViewComputadores.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAtualizarSessoes);
            this.tabPage2.Controls.Add(this.btnFinalizarSessao);
            this.tabPage2.Controls.Add(this.lblSessoesAtivas);
            this.tabPage2.Controls.Add(this.dataGridViewSessoes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "⏱️ Sessões Ativas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarSessoes
            // 
            this.btnAtualizarSessoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizarSessoes.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAtualizarSessoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizarSessoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarSessoes.ForeColor = System.Drawing.Color.White;
            this.btnAtualizarSessoes.Location = new System.Drawing.Point(850, 20);
            this.btnAtualizarSessoes.Name = "btnAtualizarSessoes";
            this.btnAtualizarSessoes.Size = new System.Drawing.Size(120, 30);
            this.btnAtualizarSessoes.TabIndex = 3;
            this.btnAtualizarSessoes.Text = "🔄 Atualizar";
            this.btnAtualizarSessoes.UseVisualStyleBackColor = false;
            this.btnAtualizarSessoes.Click += new System.EventHandler(this.btnAtualizarSessoes_Click);
            // 
            // btnFinalizarSessao
            // 
            this.btnFinalizarSessao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizarSessao.BackColor = System.Drawing.Color.Crimson;
            this.btnFinalizarSessao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarSessao.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarSessao.Location = new System.Drawing.Point(724, 20);
            this.btnFinalizarSessao.Name = "btnFinalizarSessao";
            this.btnFinalizarSessao.Size = new System.Drawing.Size(120, 30);
            this.btnFinalizarSessao.TabIndex = 2;
            this.btnFinalizarSessao.Text = "⏹️ Finalizar";
            this.btnFinalizarSessao.UseVisualStyleBackColor = false;
            this.btnFinalizarSessao.Click += new System.EventHandler(this.btnFinalizarSessao_Click);
            // 
            // lblSessoesAtivas
            // 
            this.lblSessoesAtivas.AutoSize = true;
            this.lblSessoesAtivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessoesAtivas.Location = new System.Drawing.Point(16, 20);
            this.lblSessoesAtivas.Name = "lblSessoesAtivas";
            this.lblSessoesAtivas.Size = new System.Drawing.Size(149, 24);
            this.lblSessoesAtivas.TabIndex = 1;
            this.lblSessoesAtivas.Text = "Sessões Ativas";
            // 
            // dataGridViewSessoes
            // 
            this.dataGridViewSessoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSessoes.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSessoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSessoes.Location = new System.Drawing.Point(20, 56);
            this.dataGridViewSessoes.Name = "dataGridViewSessoes";
            this.dataGridViewSessoes.ReadOnly = true;
            this.dataGridViewSessoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSessoes.Size = new System.Drawing.Size(936, 443);
            this.dataGridViewSessoes.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnLimparCliente);
            this.tabPage3.Controls.Add(this.btnCadastrarCliente);
            this.tabPage3.Controls.Add(this.txtEmailCliente);
            this.tabPage3.Controls.Add(this.txtTelefone);
            this.tabPage3.Controls.Add(this.txtCPF);
            this.tabPage3.Controls.Add(this.txtNomeCliente);
            this.tabPage3.Controls.Add(this.lblEmail);
            this.tabPage3.Controls.Add(this.lblTelefone);
            this.tabPage3.Controls.Add(this.lblCPF);
            this.tabPage3.Controls.Add(this.lblNome);
            this.tabPage3.Controls.Add(this.lblClientes);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(976, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "👥 Clientes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnLimparCliente
            // 
            this.btnLimparCliente.BackColor = System.Drawing.Color.Gray;
            this.btnLimparCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCliente.ForeColor = System.Drawing.Color.White;
            this.btnLimparCliente.Location = new System.Drawing.Point(200, 280);
            this.btnLimparCliente.Name = "btnLimparCliente";
            this.btnLimparCliente.Size = new System.Drawing.Size(120, 35);
            this.btnLimparCliente.TabIndex = 10;
            this.btnLimparCliente.Text = "🧹 Limpar";
            this.btnLimparCliente.UseVisualStyleBackColor = false;
            this.btnLimparCliente.Click += new System.EventHandler(this.btnLimparCliente_Click);
            // 
            // btnCadastrarCliente
            // 
            this.btnCadastrarCliente.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCadastrarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarCliente.ForeColor = System.Drawing.Color.White;
            this.btnCadastrarCliente.Location = new System.Drawing.Point(60, 280);
            this.btnCadastrarCliente.Name = "btnCadastrarCliente";
            this.btnCadastrarCliente.Size = new System.Drawing.Size(120, 35);
            this.btnCadastrarCliente.TabIndex = 9;
            this.btnCadastrarCliente.Text = "➕ Cadastrar";
            this.btnCadastrarCliente.UseVisualStyleBackColor = false;
            this.btnCadastrarCliente.Click += new System.EventHandler(this.btnCadastrarCliente_Click);
            // 
            // txtEmailCliente
            // 
            this.txtEmailCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailCliente.Location = new System.Drawing.Point(120, 220);
            this.txtEmailCliente.Name = "txtEmailCliente";
            this.txtEmailCliente.Size = new System.Drawing.Size(300, 22);
            this.txtEmailCliente.TabIndex = 8;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefone.Location = new System.Drawing.Point(120, 180);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(200, 22);
            this.txtTelefone.TabIndex = 7;
            // 
            // txtCPF
            // 
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(120, 140);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(200, 22);
            this.txtCPF.TabIndex = 6;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCliente.Location = new System.Drawing.Point(120, 100);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(400, 22);
            this.txtNomeCliente.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(60, 223);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(51, 16);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefone.Location = new System.Drawing.Point(40, 183);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(74, 16);
            this.lblTelefone.TabIndex = 3;
            this.lblTelefone.Text = "Telefone:";
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPF.Location = new System.Drawing.Point(75, 143);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(39, 16);
            this.lblCPF.TabIndex = 2;
            this.lblCPF.Text = "CPF:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(60, 103);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(54, 16);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome:";
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes.Location = new System.Drawing.Point(56, 40);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(239, 24);
            this.lblClientes.TabIndex = 0;
            this.lblClientes.Text = "Cadastrar Novo Cliente";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.relatoriosToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atualizarToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // atualizarToolStripMenuItem
            // 
            this.atualizarToolStripMenuItem.Name = "atualizarToolStripMenuItem";
            this.atualizarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.atualizarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.atualizarToolStripMenuItem.Text = "Atualizar";
            this.atualizarToolStripMenuItem.Click += new System.EventHandler(this.atualizarToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // relatoriosToolStripMenuItem
            // 
            this.relatoriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatorioSessoesToolStripMenuItem,
            this.relatorioClientesToolStripMenuItem});
            this.relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatoriosToolStripMenuItem.Text = "Relatórios";
            // 
            // relatorioSessoesToolStripMenuItem
            // 
            this.relatorioSessoesToolStripMenuItem.Name = "relatorioSessoesToolStripMenuItem";
            this.relatorioSessoesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.relatorioSessoesToolStripMenuItem.Text = "Relatório Sessões";
            this.relatorioSessoesToolStripMenuItem.Click += new System.EventHandler(this.relatorioSessoesToolStripMenuItem_Click);
            // 
            // relatorioClientesToolStripMenuItem
            // 
            this.relatorioClientesToolStripMenuItem.Name = "relatorioClientesToolStripMenuItem";
            this.relatorioClientesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.relatorioClientesToolStripMenuItem.Text = "Relatório Clientes";
            this.relatorioClientesToolStripMenuItem.Click += new System.EventHandler(this.relatorioClientesToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabelData});
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(867, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "Sistema Lan House - Conectado";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelData
            // 
            this.toolStripStatusLabelData.Name = "toolStripStatusLabelData";
            this.toolStripStatusLabelData.Size = new System.Drawing.Size(102, 17);
            this.toolStripStatusLabelData.Text = "00/00/0000 00:00";
            // 
            // timerAtualizar
            // 
            this.timerAtualizar.Enabled = true;
            this.timerAtualizar.Interval = 1000;
            this.timerAtualizar.Tick += new System.EventHandler(this.timerAtualizar_Tick);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 583);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🏠 Sistema Lan House - Gerenciamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComputadores)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSessoes)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatorioSessoesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatorioClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelData;
        private System.Windows.Forms.Timer timerAtualizar;
        private System.Windows.Forms.DataGridView dataGridViewComputadores;
        private System.Windows.Forms.Label lblComputadores;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.Button btnIniciarSessao;
        private System.Windows.Forms.Button btnAtualizarComputadores;
        private System.Windows.Forms.DataGridView dataGridViewSessoes;
        private System.Windows.Forms.Label lblSessoesAtivas;
        private System.Windows.Forms.Button btnFinalizarSessao;
        private System.Windows.Forms.Button btnAtualizarSessoes;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.Button btnCadastrarCliente;
        private System.Windows.Forms.Button btnLimparCliente;
    }
}