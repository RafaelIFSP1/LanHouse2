using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public partial class FormNovoComputador : Form
    {
        public FormNovoComputador()
        {
            InitializeComponent();
        }

        private void FormNovoComputador_Load(object sender, EventArgs e)
        {
            // Configurar valores padrão
            cmbStatus.SelectedIndex = 0; // DISPONÍVEL
            txtNome.Select();
            txtNome.SelectAll();
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

                    // Obter próximo ID disponível
                    string queryNextId = "SELECT ISNULL(MAX(CAST(Id AS INT)), 0) + 1 FROM Computadores";
                    string novoId;
                    using (var cmdId = new SqlCommand(queryNextId, connection))
                    {
                        novoId = cmdId.ExecuteScalar().ToString();
                    }

                    // Inserir novo computador
                    string queryInsert = @"
                        INSERT INTO Computadores (Id, Nome, Processador, RAM, PrecoHora, Status)
                        VALUES (@Id, @Nome, @Processador, @RAM, @PrecoHora, @Status)";

                    using (var cmd = new SqlCommand(queryInsert, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", novoId);
                        cmd.Parameters.AddWithValue("@Nome", txtNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@Processador", txtProcessador.Text.Trim());
                        cmd.Parameters.AddWithValue("@RAM", txtRAM.Text.Trim());
                        cmd.Parameters.AddWithValue("@PrecoHora", decimal.Parse(txtPrecoHora.Text));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"✅ Computador cadastrado com sucesso!\n\nID: PC-{novoId.PadLeft(3, '0')}",
                                          "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao salvar computador:\n{ex.Message}",
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
            // Gradiente no cabeçalho
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                panelCabecalho.ClientRectangle,
                Color.FromArgb(23, 162, 184),
                Color.FromArgb(20, 140, 160),
                90f))
            {
                e.Graphics.FillRectangle(brush, panelCabecalho.ClientRectangle);
            }
        }
    }
}