using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public partial class FormEditarComputador : Form
    {
        private dynamic _dadosComputador;

        public FormEditarComputador(dynamic dadosComputador)
        {
            InitializeComponent();
            _dadosComputador = dadosComputador;
        }

        private void FormEditarComputador_Load(object sender, EventArgs e)
        {
            CarregarDadosComputador();
        }

        private void CarregarDadosComputador()
        {
            try
            {
                // Preencher campos com dados atuais
                lblId.Text = $"ID: {_dadosComputador.NomeFormatado}";
                txtNome.Text = _dadosComputador.NomeOriginal;
                txtProcessador.Text = _dadosComputador.Processador;
                txtRAM.Text = _dadosComputador.RAM;
                txtPrecoHora.Text = _dadosComputador.PrecoHora.ToString("F2");

                // Selecionar status atual
                string statusAtual = _dadosComputador.Status;
                for (int i = 0; i < cmbStatus.Items.Count; i++)
                {
                    if (cmbStatus.Items[i].ToString() == statusAtual)
                    {
                        cmbStatus.SelectedIndex = i;
                        break;
                    }
                }

                // Se não encontrou, seleciona o primeiro
                if (cmbStatus.SelectedIndex == -1)
                    cmbStatus.SelectedIndex = 0;

                txtNome.Select();
                txtNome.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao carregar dados:\n{ex.Message}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarDados())
                return;

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        UPDATE Computadores 
                        SET Nome = @Nome, 
                            Processador = @Processador, 
                            RAM = @RAM, 
                            PrecoHora = @PrecoHora, 
                            Status = @Status 
                        WHERE Id = @Id";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", _dadosComputador.Id);
                        cmd.Parameters.AddWithValue("@Nome", txtNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@Processador", txtProcessador.Text.Trim());
                        cmd.Parameters.AddWithValue("@RAM", txtRAM.Text.Trim());
                        cmd.Parameters.AddWithValue("@PrecoHora", decimal.Parse(txtPrecoHora.Text));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"✅ Computador atualizado com sucesso!\n\n{_dadosComputador.NomeFormatado}",
                                          "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao atualizar computador:\n{ex.Message}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidarDados()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("⚠️ Informe o nome do computador.",
                              "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProcessador.Text))
            {
                MessageBox.Show("⚠️ Informe o processador.",
                              "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProcessador.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRAM.Text))
            {
                MessageBox.Show("⚠️ Informe a memória RAM.",
                              "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRAM.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecoHora.Text) || !decimal.TryParse(txtPrecoHora.Text, out decimal preco))
            {
                MessageBox.Show("⚠️ Informe um preço por hora válido.",
                              "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecoHora.Focus();
                return false;
            }

            if (preco <= 0)
            {
                MessageBox.Show("⚠️ O preço por hora deve ser maior que zero.",
                              "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecoHora.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Selecione um status.",
                              "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        private void panelCabecalho_Paint(object sender, PaintEventArgs e)
        {
            // Gradiente no cabeçalho (amarelo para edição)
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                panelCabecalho.ClientRectangle,
                Color.FromArgb(255, 193, 7),
                Color.FromArgb(230, 174, 6),
                90f))
            {
                e.Graphics.FillRectangle(brush, panelCabecalho.ClientRectangle);
            }
        }
    }
}