using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public class FormGerenciarUsuarios : Form
    {
        private DataGridView dataGridViewUsuarios;
        private Button btnNovoUsuario, btnEditarUsuario, btnDesativarUsuario, btnExcluirUsuario, btnFechar;
        private Label lblTitulo;
        private GroupBox groupBox1;
        private string usuarioLogadoTipo;

        public FormGerenciarUsuarios()
        {
            // Buscar o tipo de usuário do FormLogin
            usuarioLogadoTipo = FormLogin.TipoUsuarioLogado ?? "Cliente";
            InitializeComponent();
            CarregarUsuarios();
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.btnNovoUsuario = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnDesativarUsuario = new System.Windows.Forms.Button();
            this.btnExcluirUsuario = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "👥 GERENCIAR USUÁRIOS";

            // groupBox1
            this.groupBox1.Controls.Add(this.dataGridViewUsuarios);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Usuários";

            // dataGridViewUsuarios
            this.dataGridViewUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(20, 25);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.RowHeadersVisible = false;
            this.dataGridViewUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(810, 300);
            this.dataGridViewUsuarios.TabIndex = 0;

            // btnNovoUsuario
            this.btnNovoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNovoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNovoUsuario.ForeColor = System.Drawing.Color.White;
            this.btnNovoUsuario.Location = new System.Drawing.Point(406, 416);
            this.btnNovoUsuario.Name = "btnNovoUsuario";
            this.btnNovoUsuario.Size = new System.Drawing.Size(140, 40);
            this.btnNovoUsuario.TabIndex = 2;
            this.btnNovoUsuario.Text = "➕ NOVO USUÁRIO";
            this.btnNovoUsuario.UseVisualStyleBackColor = false;
            this.btnNovoUsuario.Click += new System.EventHandler(this.btnNovoUsuario_Click);

            // btnEditarUsuario
            this.btnEditarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEditarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnEditarUsuario.Location = new System.Drawing.Point(552, 416);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(140, 40);
            this.btnEditarUsuario.TabIndex = 3;
            this.btnEditarUsuario.Text = "✏️ EDITAR";
            this.btnEditarUsuario.UseVisualStyleBackColor = false;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);

            // btnDesativarUsuario
            this.btnDesativarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDesativarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesativarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDesativarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnDesativarUsuario.Location = new System.Drawing.Point(698, 416);
            this.btnDesativarUsuario.Name = "btnDesativarUsuario";
            this.btnDesativarUsuario.Size = new System.Drawing.Size(140, 40);
            this.btnDesativarUsuario.TabIndex = 4;
            this.btnDesativarUsuario.Text = "🚫 DESATIVAR";
            this.btnDesativarUsuario.UseVisualStyleBackColor = false;
            this.btnDesativarUsuario.Click += new System.EventHandler(this.btnDesativarUsuario_Click);

            // btnExcluirUsuario
            this.btnExcluirUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnExcluirUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcluirUsuario.ForeColor = System.Drawing.Color.White;
            this.btnExcluirUsuario.Location = new System.Drawing.Point(280, 416);
            this.btnExcluirUsuario.Name = "btnExcluirUsuario";
            this.btnExcluirUsuario.Size = new System.Drawing.Size(120, 40);
            this.btnExcluirUsuario.TabIndex = 5;
            this.btnExcluirUsuario.Text = "🗑️ EXCLUIR";
            this.btnExcluirUsuario.UseVisualStyleBackColor = false;
            this.btnExcluirUsuario.Click += new System.EventHandler(this.btnExcluirUsuario_Click);

            // btnFechar
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(150, 416);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 40);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "🔙 VOLTAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // FormGerenciarUsuarios
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNovoUsuario);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.btnDesativarUsuario);
            this.Controls.Add(this.btnExcluirUsuario);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormGerenciarUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "👥 Gerenciar Usuários - Lan House System";
            this.Load += new System.EventHandler(this.FormGerenciarUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);
        }

        private void FormGerenciarUsuarios_Load(object sender, EventArgs e)
        {
            // Verificar se usuário é administrador para mostrar botão de excluir
            bool isAdmin = usuarioLogadoTipo?.ToLower() == "administrador";

            if (!isAdmin)
            {
                btnExcluirUsuario.Visible = false;
                // Ajustar posição dos outros botões
                btnFechar.Location = new Point(280, 416);
            }
        }

        private void CarregarUsuarios()
        {
            try
            {
                // Limpar a DataGridView
                dataGridViewUsuarios.Rows.Clear();
                dataGridViewUsuarios.Columns.Clear();

                // Configurar colunas
                dataGridViewUsuarios.Columns.Add("ID", "ID");
                dataGridViewUsuarios.Columns.Add("Nome", "NOME");
                dataGridViewUsuarios.Columns.Add("Email", "E-MAIL");
                dataGridViewUsuarios.Columns.Add("Tipo", "TIPO USUÁRIO");
                dataGridViewUsuarios.Columns.Add("Status", "STATUS");

                // Carregar usuários do banco de dados
                DataTable dtUsuarios = DatabaseHelper.ObterTodosUsuarios();

                if (dtUsuarios != null && dtUsuarios.Rows.Count > 0)
                {
                    foreach (DataRow row in dtUsuarios.Rows)
                    {
                        string id = row["Id"].ToString();
                        string nome = row["Nome"].ToString();
                        string email = row["Email"].ToString();
                        string tipoUsuario = row["TipoUsuario"].ToString();

                        // CORREÇÃO: Usar a coluna "Status" que é retornada pela query
                        string status = row["Status"].ToString(); // ← CORREÇÃO AQUI

                        // Formatar o ID
                        string idFormatado = $"USR-{id.PadLeft(3, '0')}";

                        // Formatar o status com emoji - 2 ESTADOS
                        string statusFormatado = status.ToUpper() == "ATIVO" ? "🟢 ATIVO" : "🔴 INATIVO";

                        // Adicionar linha na DataGridView
                        dataGridViewUsuarios.Rows.Add(idFormatado, nome, email, tipoUsuario, statusFormatado);
                    }

                    // Atualizar título com contagem
                    lblTitulo.Text = $"👥 GERENCIAR USUÁRIOS ({dtUsuarios.Rows.Count} cadastrados)";
                }
                else
                {
                    lblTitulo.Text = "👥 GERENCIAR USUÁRIOS (0 cadastrados)";
                    MessageBox.Show("Nenhum usuário cadastrado no sistema.", "Informação",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            using (var formCadastro = new FormCadastro())
            {
                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    // Recarregar a lista após cadastrar novo usuário
                    CarregarUsuarios();
                    MessageBox.Show("✅ Usuário cadastrado com sucesso!", "Sucesso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                // Obter dados do usuário selecionado
                int rowIndex = dataGridViewUsuarios.CurrentRow.Index;
                string idFormatado = dataGridViewUsuarios.Rows[rowIndex].Cells["ID"].Value.ToString();
                string id = idFormatado.Replace("USR-", ""); // Remover prefixo para obter ID real
                string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
                string email = dataGridViewUsuarios.CurrentRow.Cells["Email"].Value.ToString();
                string tipoUsuario = dataGridViewUsuarios.CurrentRow.Cells["Tipo"].Value.ToString();
                string status = dataGridViewUsuarios.CurrentRow.Cells["Status"].Value.ToString();

                MessageBox.Show($"✏️ Editando usuário:\n\n" +
                              $"ID: {idFormatado}\n" +
                              $"Nome: {nome}\n" +
                              $"Email: {email}\n" +
                              $"Tipo: {tipoUsuario}\n" +
                              $"Status: {status}\n\n" +
                              $"Funcionalidade de edição em desenvolvimento...",
                              "Editar Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um usuário para editar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDesativarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                try
                {
                    // Obter dados do usuário selecionado
                    int rowIndex = dataGridViewUsuarios.CurrentRow.Index;
                    string idFormatado = dataGridViewUsuarios.Rows[rowIndex].Cells["ID"].Value.ToString();
                    string id = idFormatado.Replace("USR-", "");
                    string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
                    string email = dataGridViewUsuarios.CurrentRow.Cells["Email"].Value.ToString();
                    string statusAtual = dataGridViewUsuarios.CurrentRow.Cells["Status"].Value.ToString();

                    // Verificar se é o admin principal (não pode ser desativado)
                    if (email.ToLower() == "admin@gmail.com")
                    {
                        MessageBox.Show("❌ O usuário administrador principal não pode ser desativado!",
                                      "Operação Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Determinar ação baseada no status atual (2 estados)
                    string acao = "";
                    bool novoStatus = false;

                    if (statusAtual.Contains("🟢") || statusAtual.Contains("ATIVO"))
                    {
                        acao = "desativar";
                        novoStatus = false; // Muda para INATIVO
                    }
                    else
                    {
                        acao = "reativar";
                        novoStatus = true; // Muda para ATIVO
                    }

                    DialogResult result = MessageBox.Show(
                        $"Tem certeza que deseja {acao} o usuário?\n\n" +
                        $"Nome: {nome}\n" +
                        $"Email: {email}\n" +
                        $"Status atual: {statusAtual}\n" +
                        $"Novo status: {(novoStatus ? "🟢 ATIVO" : "🔴 INATIVO")}",
                        $"Confirmar {acao.ToUpper()}",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (DatabaseHelper.AlterarStatusUsuario(int.Parse(id), novoStatus))
                        {
                            // Recarregar lista IMEDIATAMENTE
                            CarregarUsuarios();

                            MessageBox.Show($"✅ Usuário {acao} com sucesso!\n" +
                                          $"Status: {(novoStatus ? "🟢 ATIVO" : "🔴 INATIVO")}",
                                          "Operação Concluída",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("❌ Erro ao alterar status do usuário.",
                                          "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar operação:\n{ex.Message}", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um usuário para desativar/reativar.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExcluirUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                try
                {
                    // Obter dados do usuário selecionado
                    int rowIndex = dataGridViewUsuarios.CurrentRow.Index;
                    string idFormatado = dataGridViewUsuarios.Rows[rowIndex].Cells["ID"].Value.ToString();
                    string id = idFormatado.Replace("USR-", ""); // Remover prefixo para obter ID real
                    string nome = dataGridViewUsuarios.CurrentRow.Cells["Nome"].Value.ToString();
                    string email = dataGridViewUsuarios.CurrentRow.Cells["Email"].Value.ToString();
                    string tipoUsuario = dataGridViewUsuarios.CurrentRow.Cells["Tipo"].Value.ToString();
                    string status = dataGridViewUsuarios.CurrentRow.Cells["Status"].Value.ToString();

                    // Verificar se é o admin principal (não pode ser excluído)
                    if (email.ToLower() == "admin@gmail.com" || email.ToLower() == "admin@lanhouse.com")
                    {
                        MessageBox.Show("❌ O usuário administrador principal não pode ser excluído!",
                                      "Operação Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Verificar se está tentando excluir a si mesmo
                    if (usuarioLogadoTipo == "Administrador" && email.ToLower() == FormLogin.EmailLogado?.ToLower())
                    {
                        MessageBox.Show("❌ Você não pode excluir seu próprio usuário!",
                                      "Operação Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Mensagem personalizada baseada no status
                    string mensagemStatus = "";
                    if (status.Contains("🔴") || status.Contains("INATIVO"))
                    {
                        mensagemStatus = "\n✅ Usuário INATIVO - Pode ser excluído mesmo com reservas ativas.";
                    }
                    else
                    {
                        mensagemStatus = "\n⚠️ Usuário ATIVO - Necessita APAGAR reservas ativas primeiro.";
                    }

                    // Confirmação EXTRA para excluir usuário
                    DialogResult result = MessageBox.Show(
                        $"🚨🚨🚨 ATENÇÃO 🚨🚨🚨\n\n" +
                        $"Você está prestes a EXCLUIR PERMANENTEMENTE o usuário:\n\n" +
                        $"Nome: {nome}\n" +
                        $"Email: {email}\n" +
                        $"Tipo: {tipoUsuario}\n" +
                        $"Status: {status}\n" +
                        $"{mensagemStatus}\n\n" +
                        $"⚠️  Esta ação NÃO PODE ser desfeita!\n" +
                        $"⚠️  Todos os dados do usuário serão perdidos!\n\n" +
                        $"Tem certeza ABSOLUTA que deseja continuar?",
                        "CONFIRMAR EXCLUSÃO PERMANENTE",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Chamar método do DatabaseHelper para excluir usuário
                        if (DatabaseHelper.ApagarUsuario(int.Parse(id)))
                        {
                            // Recarregar lista
                            CarregarUsuarios();
                            MessageBox.Show($"✅ Usuário {nome} excluído permanentemente com sucesso!",
                                          "Exclusão Concluída",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("❌ Erro ao excluir usuário.",
                                          "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar operação:\n{ex.Message}", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um usuário para excluir.",
                              "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}