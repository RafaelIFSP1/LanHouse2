using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanHouseSystem;

namespace lanhause
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            // Inicializar banco de dados
            DatabaseHelper.InitializeDatabase();

            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblBemVindo.Text = $"Bem-vindo, {FormLogin.UsuarioLogado}!";

            // MOSTRAR "Administrador" SE FOR ADMIN, SENÃO "Usuário Comum"
            string tipoUsuario = FormLogin.IsAdmin ? "Administrador" : "Usuário Comum";
            lblTipoUsuario.Text = $"Tipo: {tipoUsuario}";

            AplicarTemaUsuario();
            ConfigurarPermissoesUsuario();
        }

        private void AplicarTemaUsuario()
        {
            if (FormLogin.IsAdmin)
            {
                // Tema para Administrador - Azul mais escuro
                panelCabecalho.BackColor = Color.FromArgb(0, 91, 158); // Azul escuro
                menuStrip1.BackColor = Color.FromArgb(30, 30, 30); // Preto mais escuro
            }
            else
            {
                // Tema para Usuário Comum - Azul normal
                panelCabecalho.BackColor = Color.FromArgb(0, 122, 204); // Azul padrão
                menuStrip1.BackColor = Color.FromArgb(45, 45, 48); // Cinza escuro padrão
            }
        }

        private void ConfigurarPermissoesUsuario()
        {
            if (!FormLogin.IsAdmin)
            {
                // OCULTAR funcionalidades administrativas para usuários comuns
                gerenciarUsuariosToolStripMenuItem.Visible = false;
                btnGerenciarUsuarios.Visible = false;
                btnRelatorios.Visible = false; // ADICIONE ESTA LINHA
            }
            else
            {
                // Administrador tem acesso a tudo
                gerenciarUsuariosToolStripMenuItem.Visible = true;
                btnGerenciarUsuarios.Visible = true;
                btnRelatorios.Visible = true; // ADICIONE ESTA LINHA (opcional, para clareza)
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cadastrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Só permite cadastrar usuário se for administrador
            if (!FormLogin.IsAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem cadastrar novos usuários!",
                              "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormCadastro formCadastro = new FormCadastro();
            formCadastro.ShowDialog();
        }

        private void gerenciarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormGerenciarUsuarios();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema LanHouse\nDesenvolvido por: RAFAEL FRANCISCO DE LIMA DA SILVA\nVersão 1.0",
                          "Sobre o Sistema",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void btnGerenciarUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormGerenciarUsuarios();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            AbrirFormRelatorios();
        }

        private void btnComputadores_Click(object sender, EventArgs e)
        {
            AbrirFormComputadores();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            AbrirFormReservas();
        }

        private void AbrirFormGerenciarUsuarios()
        {
            // Só permite gerenciar usuários se for administrador
            if (!FormLogin.IsAdmin)
            {
                MessageBox.Show("❌ Apenas administradores podem gerenciar usuários!",
                              "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FormGerenciarUsuarios form = new FormGerenciarUsuarios();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir Gerenciar Usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirFormRelatorios()
        {
            try
            {
                FormRelatorios form = new FormRelatorios();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir Relatórios: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirFormComputadores()
        {
            try
            {
                FormComputadores form = new FormComputadores();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir Computadores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirFormReservas()
        {
            try
            {
                FormReservas form = new FormReservas();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir Reservas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}