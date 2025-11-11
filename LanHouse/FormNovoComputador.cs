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

                    // Obter próximo ID disponível - CORREÇÃO AQUI
                    string queryNextId = @"
                        SELECT 
                            CASE 
                                WHEN MAX(TRY_CAST(Id AS INT)) IS NULL THEN '1'
                                ELSE CAST(MAX(TRY_CAST(Id AS INT)) + 1 AS NVARCHAR(10))
                            END
                        FROM Computadores 
                        WHERE TRY_CAST(Id AS INT) IS NOT NULL";

                    string novoId;
                    using (var cmdId = new SqlCommand(queryNextId, connection))
                    {
                        var result = cmdId.ExecuteScalar();
                        novoId = result?.ToString() ?? "1";
                    }

                    // Formatar o ID como PC-001
                    string idFormatado = $"PC-{novoId.PadLeft(3, '0')}";

                    // Inserir novo computador
                    string queryInsert = @"
                        INSERT INTO Computadores (Id, Nome, Processador, RAM, PrecoHora, Status)
                        VALUES (@Id, @Nome, @Processador, @RAM, @PrecoHora, @Status)";

                    using (var cmd = new SqlCommand(queryInsert, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", idFormatado); // Usar o ID formatado
                        cmd.Parameters.AddWithValue("@Nome", txtNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@Processador", txtProcessador.Text.Trim());
                        cmd.Parameters.AddWithValue("@RAM", txtRAM.Text.Trim());
                        cmd.Parameters.AddWithValue("@PrecoHora", decimal.Parse(txtPrecoHora.Text));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"✅ Computador cadastrado com sucesso!\n\nID: {idFormatado}",
                                          "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violação de chave única (ID duplicado)
                {
                    // Tentar novamente com próximo ID
                    TentarNovamenteComProximoId();
                }
                else
                {
                    MessageBox.Show($"❌ Erro ao salvar computador:\n{ex.Message}",
                                  "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao salvar computador:\n{ex.Message}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TentarNovamenteComProximoId()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Buscar o maior ID numérico e somar 1
                    string queryNextId = @"
                        SELECT ISNULL(MAX(CAST(REPLACE(Id, 'PC-', '') AS INT)), 0) + 1 
                        FROM Computadores 
                        WHERE Id LIKE 'PC-%'";

                    string novoId;
                    using (var cmdId = new SqlCommand(queryNextId, connection))
                    {
                        novoId = cmdId.ExecuteScalar().ToString();
                    }

                    string idFormatado = $"PC-{novoId.PadLeft(3, '0')}";

                    // Tentar inserir novamente
                    string queryInsert = @"
                        INSERT INTO Computadores (Id, Nome, Processador, RAM, PrecoHora, Status)
                        VALUES (@Id, @Nome, @Processador, @RAM, @PrecoHora, @Status)";

                    using (var cmd = new SqlCommand(queryInsert, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", idFormatado);
                        cmd.Parameters.AddWithValue("@Nome", txtNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@Processador", txtProcessador.Text.Trim());
                        cmd.Parameters.AddWithValue("@RAM", txtRAM.Text.Trim());
                        cmd.Parameters.AddWithValue("@PrecoHora", decimal.Parse(txtPrecoHora.Text));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"✅ Computador cadastrado com sucesso!\n\nID: {idFormatado}",
                                          "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao salvar computador após tentativa de correção:\n{ex.Message}",
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

        // Método alternativo mais simples - se ainda houver problemas
        private void btnSalvar_Alternativo_Click(object sender, EventArgs e)
        {
            if (!ValidarDados())
                return;

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Método SIMPLES - buscar todos os IDs e encontrar o próximo
                    string queryIds = "SELECT Id FROM Computadores WHERE Id LIKE 'PC-%'";
                    int maxId = 0;

                    using (var cmdIds = new SqlCommand(queryIds, connection))
                    using (var reader = cmdIds.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["Id"].ToString();
                            if (id.StartsWith("PC-") && int.TryParse(id.Substring(3), out int idNum))
                            {
                                if (idNum > maxId) maxId = idNum;
                            }
                        }
                    }

                    string novoId = $"PC-{(maxId + 1).ToString().PadLeft(3, '0')}";

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
                            MessageBox.Show($"✅ Computador cadastrado com sucesso!\n\nID: {novoId}",
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
    }
}