using System;
using System.Data;
using System.Windows.Forms;

namespace lanhause
{
    public partial class FormGerenciarUsuarios : Form
    {
        public FormGerenciarUsuarios()
        {
            InitializeComponent();
        }

        private void CarregarUsuarios()
        {
            try
            {
                // VERIFICAÇÃO DE SEGURANÇA ADICIONADA
                if (dataGridViewUsuarios == null)
                {
                    MessageBox.Show("DataGridView não foi inicializado corretamente.", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = DatabaseHelper.ObterTodosUsuarios();

                // VERIFICAÇÃO ADICIONADA
                if (dt == null)
                {
                    MessageBox.Show("Não foi possível carregar os dados dos usuários.", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridViewUsuarios.DataSource = dt;

                // Configurar colunas COM VERIFICAÇÃO
                if (dataGridViewUsuarios.Columns.Count > 0)
                {
                    // VERIFICAÇÃO DE COLUNAS EXISTENTES
                    if (dataGridViewUsuarios.Columns.Contains("Id"))
                        dataGridViewUsuarios.Columns["Id"].Width = 50;

                    if (dataGridViewUsuarios.Columns.Contains("Nome"))
                        dataGridViewUsuarios.Columns["Nome"].Width = 200;

                    if (dataGridViewUsuarios.Columns.Contains("Email"))
                        dataGridViewUsuarios.Columns["Email"].Width = 200;

                    if (dataGridViewUsuarios.Columns.Contains("TipoUsuario"))
                    {
                        dataGridViewUsuarios.Columns["TipoUsuario"].Width = 120;
                        dataGridViewUsuarios.Columns["TipoUsuario"].HeaderText = "TIPO";
                    }

                    if (dataGridViewUsuarios.Columns.Contains("Status"))
                        dataGridViewUsuarios.Columns["Status"].Width = 100;

                    if (dataGridViewUsuarios.Columns.Contains("DataCadastro"))
                    {
                        dataGridViewUsuarios.Columns["DataCadastro"].Width = 100;
                        dataGridViewUsuarios.Columns["DataCadastro"].HeaderText = "CADASTRO";
                    }
                }

                AtualizarTitulo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no carregar usuários:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTitulo()
        {
            // VERIFICAÇÃO ADICIONADA
            if (dataGridViewUsuarios == null || lblTitulo == null) return;

            int total = dataGridViewUsuarios.Rows.Count;
            lblTitulo.Text = $"👥 GERENCIAR USUÁRIOS ({total} cadastrado{(total != 1 ? "s" : "")})";
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            using (var form = new FormCadastro())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CarregarUsuarios();
                    MessageBox.Show("✅ Usuário cadastrado com sucesso!", "Sucesso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            // VERIFICAÇÃO ADICIONADA
            if (dataGridViewUsuarios == null || dataGridViewUsuarios.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Selecione um usuário para editar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
            MessageBox.Show($"✏️ Funcionalidade de edição em desenvolvimento.\n\nUsuário: {nome}",
                          "Em Desenvolvimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDesativarUsuario_Click(object sender, EventArgs e)
        {
            // VERIFICAÇÃO ADICIONADA
            if (dataGridViewUsuarios == null || dataGridViewUsuarios.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Selecione um usuário para excluir permanentemente.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewUsuarios.CurrentRow.Cells["Id"].Value);
            string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
            string email = dataGridViewUsuarios.CurrentRow.Cells["Email"].Value.ToString();

            // Não permite excluir o admin principal
            if (email.ToLower() == "admin@gmail.com")
            {
                MessageBox.Show("❌ O usuário administrador principal não pode ser excluído!",
                              "Operação Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CONFIRMAÇÃO MAIS SÉRIA PARA EXCLUSÃO PERMANENTE
            var result = MessageBox.Show(
                $"🚨🚨🚨 ATENÇÃO: EXCLUSÃO PERMANENTE! 🚨🚨🚨\n\n" +
                $"Você está prestes a EXCLUIR PERMANENTEMENTE o usuário:\n\n" +
                $"Nome: {nome}\n" +
                $"Email: {email}\n\n" +
                $"⚠️ ESTA AÇÃO NÃO PODE SER DESFEITA!\n" +
                $"⚠️ TODOS OS DADOS SERÃO PERDIDOS!\n\n" +
                $"Digite 'EXCLUIR' para confirmar:",
                "CONFIRMAÇÃO DE EXCLUSÃO PERMANENTE",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                // CAIXA DE DIÁLOGO PERSONALIZADA PARA CONFIRMAÇÃO FINAL
                using (var formConfirmacao = new FormConfirmacaoExclusao(nome, email))
                {
                    if (formConfirmacao.ShowDialog() == DialogResult.Yes)
                    {
                        // EXCLUIR PERMANENTEMENTE DO BANCO DE DADOS
                        if (DatabaseHelper.ExcluirUsuarioPermanentemente(id))
                        {
                            CarregarUsuarios();
                            MessageBox.Show($"✅ Usuário '{nome}' excluído permanentemente com sucesso!",
                                          "Exclusão Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"❌ Erro ao excluir o usuário '{nome}'.",
                                          "Erro na Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            // VERIFICAÇÃO ADICIONADA
            if (dataGridViewUsuarios == null || dataGridViewUsuarios.DataSource == null) return;

            if (dataGridViewUsuarios.DataSource is DataTable dt)
            {
                string filtro = txtPesquisar.Text.Trim();

                if (string.IsNullOrEmpty(filtro))
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    dt.DefaultView.RowFilter = $"Nome LIKE '%{filtro}%' OR Email LIKE '%{filtro}%'";
                }
            }
        }

        private void dataGridViewUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            // VERIFICAÇÃO ADICIONADA
            if (dataGridViewUsuarios == null || btnEditarUsuario == null || btnDesativarUsuario == null) return;

            bool temSelecao = dataGridViewUsuarios.CurrentRow != null;
            btnEditarUsuario.Enabled = temSelecao;
            btnDesativarUsuario.Enabled = temSelecao;

            // MUDANÇA: Agora o botão sempre mostra "EXCLUIR" já que é exclusão permanente
            if (temSelecao)
            {
                btnDesativarUsuario.Text = "🗑️ EXCLUIR";
            }
        }

        private void FormGerenciarUsuarios_Load(object sender, EventArgs e)
        {
            // AGORA O CARREGAMENTO ACONTECE AQUI, QUANDO O FORM JÁ ESTÁ INICIALIZADO
            CarregarUsuarios();
        }
    }

    // FORM DE CONFIRMAÇÃO PERSONALIZADO PARA EXCLUSÃO
    public class FormConfirmacaoExclusao : Form
    {
        private TextBox txtConfirmacao;
        private Button btnConfirmar, btnCancelar;
        private Label lblMensagem;

        public FormConfirmacaoExclusao(string nome, string email)
        {
            InitializeComponent(nome, email);
        }

        private void InitializeComponent(string nome, string email)
        {
            this.Size = new System.Drawing.Size(450, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Confirmação Final - Exclusão Permanente";

            lblMensagem = new Label
            {
                Text = $"Digite 'EXCLUIR {nome}' para confirmar a exclusão permanente:\n\n" +
                      $"Usuário: {nome}\n" +
                      $"Email: {email}",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(400, 60),
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
            };

            txtConfirmacao = new TextBox
            {
                Location = new System.Drawing.Point(20, 90),
                Size = new System.Drawing.Size(400, 25),
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };

            btnConfirmar = new Button
            {
                Text = "CONFIRMAR EXCLUSÃO",
                BackColor = System.Drawing.Color.Red,
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(20, 130),
                Size = new System.Drawing.Size(180, 35),
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
            };

            btnCancelar = new Button
            {
                Text = "CANCELAR",
                BackColor = System.Drawing.Color.Gray,
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(220, 130),
                Size = new System.Drawing.Size(200, 35),
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
            };

            btnConfirmar.Click += (s, e) =>
            {
                if (txtConfirmacao.Text.Trim() == $"EXCLUIR {nome}")
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Texto de confirmação incorreto! Digite exatamente como solicitado.",
                                  "Confirmação Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            btnCancelar.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            };

            this.Controls.AddRange(new Control[] { lblMensagem, txtConfirmacao, btnConfirmar, btnCancelar });
        }
    }
}