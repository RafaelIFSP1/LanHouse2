using System;
using System.Drawing;
using System.Windows.Forms;

namespace LanHouseSystem
{
    public partial class FormPrincipal : Form
    {
        private Usuario usuarioLogado;

        // Declaração de TODOS os controles como campos da classe
        private Panel panelMenu;
        private Panel panelConteudo;
        private Label lblBemVindo;
        private Label lblEmail;
        private Label lblTipoUsuario;
        private Button btnComputadores;
        private Button btnReservas;
        private Button btnGerenciarUsuarios;
        private Button btnRelatorios;
        private Button btnSair;
        private PictureBox pictureBox1;

        public FormPrincipal(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
            ConfigurarInterface();
        }

        private void InitializeComponent()
        {
            // Configuração básica do form
            this.Text = "Lan House System - Dashboard";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            this.FormClosed += new FormClosedEventHandler(FormPrincipal_FormClosed);

            CriarMenuLateral();
            CriarAreaConteudo();
        }

        private void CriarMenuLateral()
        {
            // Panel Menu Lateral
            panelMenu = new Panel();
            panelMenu.Size = new Size(250, 600);
            panelMenu.BackColor = Color.FromArgb(33, 37, 41);
            panelMenu.Location = new Point(0, 0);
            this.Controls.Add(panelMenu);

            // PictureBox Logo
            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.Location = new Point(50, 20);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = CreateSampleImage();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            panelMenu.Controls.Add(pictureBox1);

            // Label Bem-vindo
            lblBemVindo = new Label();
            lblBemVindo.Text = "Bem-vindo!";
            lblBemVindo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblBemVindo.ForeColor = Color.White;
            lblBemVindo.Size = new Size(200, 30);
            lblBemVindo.Location = new Point(25, 180);
            lblBemVindo.TextAlign = ContentAlignment.MiddleLeft;
            panelMenu.Controls.Add(lblBemVindo);

            // Label Email
            lblEmail = new Label();
            lblEmail.Text = "email@exemplo.com";
            lblEmail.Font = new Font("Segoe UI", 9);
            lblEmail.ForeColor = Color.LightGray;
            lblEmail.Size = new Size(200, 20);
            lblEmail.Location = new Point(25, 210);
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            panelMenu.Controls.Add(lblEmail);

            // Label Tipo Usuário
            lblTipoUsuario = new Label();
            lblTipoUsuario.Text = "Tipo de Usuário";
            lblTipoUsuario.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTipoUsuario.ForeColor = Color.FromArgb(0, 123, 255);
            lblTipoUsuario.Size = new Size(200, 25);
            lblTipoUsuario.Location = new Point(25, 235);
            lblTipoUsuario.TextAlign = ContentAlignment.MiddleLeft;
            panelMenu.Controls.Add(lblTipoUsuario);

            // Botão Computadores
            btnComputadores = new Button();
            btnComputadores.Text = "💻 COMPUTADORES";
            btnComputadores.Size = new Size(220, 45);
            btnComputadores.Location = new Point(15, 280);
            btnComputadores.BackColor = Color.FromArgb(0, 123, 255);
            btnComputadores.ForeColor = Color.White;
            btnComputadores.FlatStyle = FlatStyle.Flat;
            btnComputadores.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnComputadores.TextAlign = ContentAlignment.MiddleLeft;
            btnComputadores.Click += new EventHandler(btnComputadores_Click);
            panelMenu.Controls.Add(btnComputadores);

            // Botão Reservas
            btnReservas = new Button();
            btnReservas.Text = "📅 MINHAS RESERVAS";
            btnReservas.Size = new Size(220, 45);
            btnReservas.Location = new Point(15, 335);
            btnReservas.BackColor = Color.FromArgb(111, 66, 193);
            btnReservas.ForeColor = Color.White;
            btnReservas.FlatStyle = FlatStyle.Flat;
            btnReservas.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReservas.TextAlign = ContentAlignment.MiddleLeft;
            btnReservas.Click += new EventHandler(btnReservas_Click);
            panelMenu.Controls.Add(btnReservas);

            // Botão Gerenciar Usuários
            btnGerenciarUsuarios = new Button();
            btnGerenciarUsuarios.Text = "👥 GERENCIAR USUÁRIOS";
            btnGerenciarUsuarios.Size = new Size(220, 45);
            btnGerenciarUsuarios.Location = new Point(15, 390);
            btnGerenciarUsuarios.BackColor = Color.FromArgb(220, 53, 69);
            btnGerenciarUsuarios.ForeColor = Color.White;
            btnGerenciarUsuarios.FlatStyle = FlatStyle.Flat;
            btnGerenciarUsuarios.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnGerenciarUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnGerenciarUsuarios.Click += new EventHandler(btnGerenciarUsuarios_Click);
            panelMenu.Controls.Add(btnGerenciarUsuarios);

            // Botão Relatórios
            btnRelatorios = new Button();
            btnRelatorios.Text = "📊 RELATÓRIOS";
            btnRelatorios.Size = new Size(220, 45);
            btnRelatorios.Location = new Point(15, 445);
            btnRelatorios.BackColor = Color.FromArgb(40, 167, 69);
            btnRelatorios.ForeColor = Color.White;
            btnRelatorios.FlatStyle = FlatStyle.Flat;
            btnRelatorios.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRelatorios.TextAlign = ContentAlignment.MiddleLeft;
            btnRelatorios.Click += new EventHandler(btnRelatorios_Click);
            panelMenu.Controls.Add(btnRelatorios);

            // Botão Sair
            btnSair = new Button();
            btnSair.Text = "🚪 SAIR DO SISTEMA";
            btnSair.Size = new Size(220, 45);
            btnSair.Location = new Point(15, 520);
            btnSair.BackColor = Color.FromArgb(108, 117, 125);
            btnSair.ForeColor = Color.White;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSair.TextAlign = ContentAlignment.MiddleLeft;
            btnSair.Click += new EventHandler(btnSair_Click);
            panelMenu.Controls.Add(btnSair);
        }

        private void CriarAreaConteudo()
        {
            // Panel Conteúdo
            panelConteudo = new Panel();
            panelConteudo.Size = new Size(734, 560);
            panelConteudo.BackColor = Color.FromArgb(248, 249, 250);
            panelConteudo.Location = new Point(250, 0);
            this.Controls.Add(panelConteudo);

            // Label de Boas-vindas no conteúdo
            Label lblDashboard = new Label();
            lblDashboard.Text = "🏠 DASHBOARD PRINCIPAL";
            lblDashboard.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblDashboard.ForeColor = Color.FromArgb(33, 37, 41);
            lblDashboard.Size = new Size(500, 50);
            lblDashboard.Location = new Point(100, 50);
            lblDashboard.TextAlign = ContentAlignment.MiddleCenter;
            panelConteudo.Controls.Add(lblDashboard);

            Label lblInfo = new Label();
            lblInfo.Text = "Selecione uma opção no menu lateral para começar";
            lblInfo.Font = new Font("Segoe UI", 12);
            lblInfo.ForeColor = Color.FromArgb(108, 117, 125);
            lblInfo.Size = new Size(500, 30);
            lblInfo.Location = new Point(117, 120);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            panelConteudo.Controls.Add(lblInfo);
        }

        private void ConfigurarInterface()
        {
            // Configurar informações do usuário logado
            lblBemVindo.Text = $"Bem-vindo, {usuarioLogado.Nome}!";
            lblEmail.Text = usuarioLogado.Email;

            if (usuarioLogado.TipoUsuario == "Admin")
            {
                lblTipoUsuario.Text = "👑 ADMINISTRADOR";
                lblTipoUsuario.ForeColor = Color.FromArgb(220, 53, 69);
                btnGerenciarUsuarios.Visible = true;
                btnRelatorios.Visible = true;
            }
            else
            {
                lblTipoUsuario.Text = "👤 USUÁRIO COMUM";
                lblTipoUsuario.ForeColor = Color.FromArgb(0, 123, 255);
                btnGerenciarUsuarios.Visible = false;
                btnRelatorios.Visible = false;
            }
        }

        // === MÉTODOS PARA ACESSAR OS FORMS ===

        private void btnComputadores_Click(object sender, EventArgs e)
        {
            try
            {
                FormComputadores formComputadores = new FormComputadores();
                formComputadores.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir Computadores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            try
            {
                FormReservas formReservas = new FormReservas(usuarioLogado);
                formReservas.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir Reservas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerenciarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se é administrador
                if (usuarioLogado.TipoUsuario != "Admin")
                {
                    MessageBox.Show("❌ Acesso negado!\n\nApenas administradores podem gerenciar usuários.",
                                  "Permissão Insuficiente",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                FormGerenciarUsuarios formGerenciarUsuarios = new FormGerenciarUsuarios();
                formGerenciarUsuarios.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir Gerenciar Usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se é administrador
                if (usuarioLogado.TipoUsuario != "Admin")
                {
                    MessageBox.Show("❌ Acesso negado!\n\nApenas administradores podem acessar relatórios.",
                                  "Permissão Insuficiente",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                FormRelatorios formRelatorios = new FormRelatorios();
                formRelatorios.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir Relatórios: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "🚪 Tem certeza que deseja sair do sistema?",
                "Confirmação de Saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Método para criar uma imagem de exemplo
        private Image CreateSampleImage()
        {
            Bitmap bmp = new Bitmap(150, 150);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(0, 123, 255));
                g.FillRectangle(new SolidBrush(Color.FromArgb(0, 86, 179)), 0, 0, 150, 40);

                // Desenhar ícone de computador
                g.FillRectangle(Brushes.White, 40, 60, 70, 50);
                g.FillRectangle(Brushes.LightGray, 45, 65, 60, 35);
                g.FillRectangle(Brushes.Black, 50, 115, 50, 5);
                g.FillRectangle(Brushes.Gray, 65, 120, 20, 10);

                // Texto
                g.DrawString("LAN HOUSE", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.White, new PointF(30, 10));
                g.DrawString("SYSTEM", new Font("Segoe UI", 8, FontStyle.Regular), Brushes.White, new PointF(50, 135));
            }
            return bmp;
        }
    }
}