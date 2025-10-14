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
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblBemVindo.Text = $"Bem-vindo, {FormLogin.UsuarioLogado}!";

            string tipoUsuario = FormLogin.IsAdmin ? "Administrador" : "Usuário Comum";
            lblTipoUsuario.Text = $"Tipo: {tipoUsuario}";

            AplicarTemaUsuario();
        }

        private void AplicarTemaUsuario()
        {
            if (FormLogin.IsAdmin)
            {
                panelCabecalho.BackColor = Color.FromArgb(0, 122, 204);
            }
            else
            {
                panelCabecalho.BackColor = Color.FromArgb(16, 110, 190);
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