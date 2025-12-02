using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using lanhause;

namespace lanhause
{
    public partial class FormNovaReserva : Form
    {
        private decimal valorTotal = 0;

        // Classe auxiliar para os itens do ComboBox
        private class ComputadorItem
        {
            public string Id { get; set; }
            public string Display { get; set; }
            public decimal PrecoHora { get; set; }

            public override string ToString()
            {
                return Display;
            }
        }

        // MÉTODO PARA GERAR ID AUTOMÁTICO - ADICIONE ESTE MÉTODO
        private string GerarIdReserva()
        {
            DateTime agora = DateTime.Now;
            return $"RES-{agora:yyyyMMdd}-{agora:HHmmss}";
        }

        public FormNovaReserva()
        {
            InitializeComponent();
            CarregarComputadores();
            CarregarHorarios();
        }

        private void FormNovaReserva_Load(object sender, EventArgs e)
        {
            dtpData.MinDate = DateTime.Today;
            dtpData.Value = DateTime.Today;
        }

        private void CarregarComputadores()
        {
            try
            {
                cmbComputadores.Items.Clear();

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    // CORREÇÃO: Filtrar por status que contenha "DISPONÍVEL" (com ou sem emoji)
                    string query = @"SELECT Id, Nome, PrecoHora FROM Computadores 
                           WHERE Status LIKE '%DISPONÍVEL%' OR Status LIKE '%DISPONIVEL%' 
                           ORDER BY Id";

                    using (var cmd = new SqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbComputadores.Items.Add(new ComputadorItem
                            {
                                Display = $"{reader["Nome"]} (R$ {reader["PrecoHora"]}/h)",
                                Id = reader["Id"].ToString(),
                                PrecoHora = Convert.ToDecimal(reader["PrecoHora"])
                            });
                        }
                    }
                }

                // DEBUG: Verificar quantos computadores foram carregados
                if (cmbComputadores.Items.Count == 0)
                {
                    MessageBox.Show("Nenhum computador disponível encontrado.", "Info",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Selecionar o primeiro computador automaticamente
                    cmbComputadores.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar computadores:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarHorarios()
        {
            cmbHoraInicio.Items.Clear();
            cmbHoraFim.Items.Clear();

            for (int hora = 8; hora <= 22; hora++)
            {
                for (int minuto = 0; minuto < 60; minuto += 30)
                {
                    string horario = $"{hora:00}.{minuto:00}";
                    cmbHoraInicio.Items.Add(horario);
                    cmbHoraFim.Items.Add(horario);
                }
            }

            // Definir horários padrão
            cmbHoraInicio.SelectedIndex = 0; // 08.00
            if (cmbHoraFim.Items.Count > 2)
                cmbHoraFim.SelectedIndex = 2; // 09.00
        }

        private void CalcularValor()
        {
            if (cmbComputadores.SelectedItem is ComputadorItem pc &&
                cmbHoraInicio.SelectedItem != null &&
                cmbHoraFim.SelectedItem != null)
            {
                TimeSpan duracao = CalcularDuracao();
                int horas = (int)Math.Ceiling(duracao.TotalHours);

                // NOVO: Calcular preço ajustado pelo horário
                string horaInicio = cmbHoraInicio.SelectedItem.ToString();
                decimal precoAjustado = DatabaseHelper.CalcularPrecoComHorario(pc.PrecoHora, horaInicio);

                valorTotal = precoAjustado * horas;

                // Mostrar informações detalhadas
                string periodoDia = DatabaseHelper.ObterPeriodoDia(horaInicio);
                lblHoras.Text = $"{horas} hora{(horas != 1 ? "s" : "")} ({duracao.TotalHours:F1}h)\n{periodoDia}";
                lblValor.Text = $"R$ {valorTotal:F2}\n(Base: R$ {pc.PrecoHora:F2} → Ajustado: R$ {precoAjustado:F2})";
            }
        }

        private TimeSpan CalcularDuracao()
        {
            if (cmbHoraInicio.SelectedItem != null && cmbHoraFim.SelectedItem != null)
            {
                try
                {
                    string iniStr = cmbHoraInicio.SelectedItem.ToString().Replace('.', ':');
                    string fimStr = cmbHoraFim.SelectedItem.ToString().Replace('.', ':');

                    TimeSpan inicio = TimeSpan.Parse(iniStr);
                    TimeSpan fim = TimeSpan.Parse(fimStr);

                    return fim > inicio ? fim - inicio : (TimeSpan.FromHours(24) - inicio) + fim;
                }
                catch
                {
                    return TimeSpan.Zero;
                }
            }
            return TimeSpan.Zero;
        }

        private bool ValidarDados()
        {
            if (string.IsNullOrWhiteSpace(txtClienteNome.Text))
            {
                MessageBox.Show("⚠️ Informe o nome do cliente.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClienteNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtClienteEmail.Text))
            {
                MessageBox.Show("⚠️ Informe o e-mail do cliente.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClienteEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtClienteEmail.Text.Trim()))
            {
                MessageBox.Show("⚠️ Informe um e-mail válido.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClienteEmail.Focus();
                return false;
            }

            if (cmbComputadores.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Selecione um computador.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbComputadores.Focus();
                return false;
            }

            if (cmbHoraInicio.SelectedItem == null || cmbHoraFim.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Selecione ambos os horários.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            TimeSpan duracao = CalcularDuracao();
            if (duracao.TotalHours <= 0)
            {
                MessageBox.Show("⚠️ Horário de fim deve ser maior que horário de início.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (duracao.TotalHours > 8)
            {
                MessageBox.Show("⚠️ A reserva não pode exceder 8 horas.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarDados()) return;

            try
            {
                var pc = (ComputadorItem)cmbComputadores.SelectedItem;
                string horaIni = cmbHoraInicio.SelectedItem.ToString();
                string horaFim = cmbHoraFim.SelectedItem.ToString();

                // VERIFICAÇÃO DE CONFLITO - NOVA RESERVA
                if (!DatabaseHelper.ComputadorDisponivelNoHorario(pc.Id, dtpData.Value, horaIni, horaFim, null))
                {
                    string detalhesConflito = DatabaseHelper.ObterDetalhesConflito(pc.Id, dtpData.Value, horaIni, horaFim);

                    MessageBox.Show($"❌ Este computador não está disponível no horário selecionado!\n\n" +
                                  $"Já existe uma reserva CONFIRMADA:\n\n" +
                                  $"{detalhesConflito}\n\n" +
                                  $"Por favor, escolha outro horário ou computador.",
                                  "Conflito de Horário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // CORREÇÃO: ADICIONAR O CAMPO Id NA QUERY E GERAR ID AUTOMÁTICO
                    string query = @"
                        INSERT INTO Reservas 
                        (Id, ComputadorId, ClienteNome, ClienteEmail, DataReserva, HoraInicio, HoraFim, ValorTotal, Status, UsuarioId, DataCriacao)
                        VALUES 
                        (@Id, @ComputadorId, @ClienteNome, @ClienteEmail, @DataReserva, @HoraInicio, @HoraFim, @ValorTotal, @Status, @UsuarioId, @DataCriacao)";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        // GERAR ID AUTOMÁTICO - CORREÇÃO DO ERRO
                        string idReserva = GerarIdReserva();

                        cmd.Parameters.AddWithValue("@Id", idReserva);
                        cmd.Parameters.AddWithValue("@ComputadorId", pc.Id);
                        cmd.Parameters.AddWithValue("@ClienteNome", txtClienteNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@ClienteEmail", txtClienteEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@DataReserva", dtpData.Value.Date);
                        cmd.Parameters.AddWithValue("@HoraInicio", horaIni);
                        cmd.Parameters.AddWithValue("@HoraFim", horaFim);
                        cmd.Parameters.AddWithValue("@ValorTotal", valorTotal);
                        cmd.Parameters.AddWithValue("@Status", "● CONFIRMADA");
                        cmd.Parameters.AddWithValue("@UsuarioId", FormLogin.UsuarioId);
                        cmd.Parameters.AddWithValue("@DataCriacao", DateTime.Now); // ADICIONADO TAMBÉM

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"✅ Reserva criada com sucesso!\nID: {idReserva}", "Sucesso",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("❌ Erro ao criar reserva!", "Erro",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar reserva:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbComputadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularValor();
        }

        private void cmbHoraInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularValor();
        }

        private void cmbHoraFim_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularValor();
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            CalcularValor();
        }
    }
}
