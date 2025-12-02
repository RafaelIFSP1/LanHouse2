using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LanHouseSystem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lanhause
{
    public partial class FormEditarReserva : Form
    {
        private string reservaId;
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

        public FormEditarReserva(string reservaId)
        {
            this.reservaId = reservaId;
            InitializeComponent();
            CarregarDadosReserva();
            CarregarComputadores();
            CarregarHorarios();
        }

        private void FormEditarReserva_Load(object sender, EventArgs e)
        {
            // Configurações adicionais podem ser feitas aqui
        }

        private void CarregarDadosReserva()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT ComputadorId, ClienteNome, ClienteEmail, 
                               DataReserva, HoraInicio, HoraFim, ValorTotal
                        FROM Reservas WHERE Id = @Id";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", reservaId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtClienteNome.Text = reader["ClienteNome"].ToString();
                                txtClienteEmail.Text = reader["ClienteEmail"].ToString();
                                dtpData.Value = Convert.ToDateTime(reader["DataReserva"]);
                                valorTotal = Convert.ToDecimal(reader["ValorTotal"]);

                                // Armazenar dados temporariamente para seleção posterior
                                var horaInicio = reader["HoraInicio"].ToString();
                                var horaFim = reader["HoraFim"].ToString();
                                var computadorId = reader["ComputadorId"].ToString();

                                // Atualizar labels com valores iniciais
                                lblValor.Text = $"R$ {valorTotal:F2}";

                                // Calcular horas totais iniciais
                                TimeSpan duracao = CalcularDuracaoStrings(horaInicio, horaFim);
                                int horas = (int)Math.Ceiling(duracao.TotalHours);
                                lblHoras.Text = $"{horas} hora{(horas != 1 ? "s" : "")} ({duracao.TotalHours:F1}h)";

                                // Armazenar dados para uso posterior
                                txtClienteNome.Tag = computadorId;
                                txtClienteEmail.Tag = horaInicio;
                                dtpData.Tag = horaFim;
                            }
                            else
                            {
                                MessageBox.Show("Reserva não encontrada!", "Erro",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private TimeSpan CalcularDuracaoStrings(string horaInicioStr, string horaFimStr)
        {
            try
            {
                string iniStr = horaInicioStr.Replace('.', ':');
                string fimStr = horaFimStr.Replace('.', ':');

                TimeSpan inicio = TimeSpan.Parse(iniStr);
                TimeSpan fim = TimeSpan.Parse(fimStr);

                return fim > inicio ? fim - inicio : (TimeSpan.FromHours(24) - inicio) + fim;
            }
            catch
            {
                return TimeSpan.Zero;
            }
        }

        private void CarregarComputadores()
        {
            try
            {
                cmbComputadores.Items.Clear();

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // MOSTRA TODOS OS COMPUTADORES (sem filtro de status)
                    string query = "SELECT Id, Nome, PrecoHora FROM Computadores";

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

                // Selecionar computador atual da reserva
                string pcId = txtClienteNome.Tag?.ToString();
                if (pcId != null)
                {
                    for (int i = 0; i < cmbComputadores.Items.Count; i++)
                    {
                        if (((ComputadorItem)cmbComputadores.Items[i]).Id == pcId)
                        {
                            cmbComputadores.SelectedIndex = i;
                            break;
                        }
                    }
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

            // Selecionar horários atuais
            string horaIni = txtClienteEmail.Tag?.ToString();
            string horaFim = dtpData.Tag?.ToString();

            if (horaIni != null)
            {
                cmbHoraInicio.SelectedItem = horaIni;
            }
            if (horaFim != null)
            {
                cmbHoraFim.SelectedItem = horaFim;
            }
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


        // Método local para obter período do dia
        private string ObterPeriodoDiaLocal(string hora)
        {
            try
            {
                // Converter formato "08.30" para TimeSpan
                string horaFormatada = hora.Replace('.', ':');
                TimeSpan horario = TimeSpan.Parse(horaFormatada);

                if (horario >= TimeSpan.FromHours(8) && horario < TimeSpan.FromHours(12))
                    return "🕗 Período: Manhã";
                else if (horario >= TimeSpan.FromHours(12) && horario < TimeSpan.FromHours(18))
                    return "🕛 Período: Tarde";
                else if (horario >= TimeSpan.FromHours(18) && horario <= TimeSpan.FromHours(22))
                    return "🕕 Período: Noite";
                else
                    return "⏰ Fora do horário comercial";
            }
            catch
            {
                return "⏰ Período não identificado";
            }
        }

        // Método local para calcular preço com horário
        private decimal CalcularPrecoComHorarioLocal(decimal precoBase, string hora)
        {
            try
            {
                string horaFormatada = hora.Replace('.', ':');
                TimeSpan horario = TimeSpan.Parse(horaFormatada);

                // Ajuste de preço por período
                if (horario >= TimeSpan.FromHours(8) && horario < TimeSpan.FromHours(12))
                {
                    // Manhã: preço normal
                    return precoBase;
                }
                else if (horario >= TimeSpan.FromHours(12) && horario < TimeSpan.FromHours(18))
                {
                    // Tarde: +10%
                    return precoBase * 1.10m;
                }
                else if (horario >= TimeSpan.FromHours(18) && horario <= TimeSpan.FromHours(22))
                {
                    // Noite: +20%
                    return precoBase * 1.20m;
                }
                else
                {
                    // Fora do horário comercial: preço normal
                    return precoBase;
                }
            }
            catch
            {
                return precoBase;
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

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarDados()) return;

            try
            {
                var pc = (ComputadorItem)cmbComputadores.SelectedItem;
                string horaIni = cmbHoraInicio.SelectedItem.ToString();
                string horaFim = cmbHoraFim.SelectedItem.ToString();

                // Verificar disponibilidade usando método existente
                if (!DatabaseHelper.ComputadorDisponivelNoHorario(
                    pc.Id, dtpData.Value, horaIni, horaFim, reservaId))
                {
                    MessageBox.Show("❌ Este computador não está disponível no horário selecionado!",
                                  "Conflito de Horário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // CORREÇÃO: Removida a coluna DataAtualizacao
                    string query = @"
                UPDATE Reservas SET
                    ComputadorId = @ComputadorId,
                    ClienteNome = @ClienteNome,
                    ClienteEmail = @ClienteEmail,
                    DataReserva = @DataReserva,
                    HoraInicio = @HoraInicio,
                    HoraFim = @HoraFim,
                    ValorTotal = @ValorTotal
                WHERE Id = @Id";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ComputadorId", pc.Id);
                        cmd.Parameters.AddWithValue("@ClienteNome", txtClienteNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@ClienteEmail", txtClienteEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@DataReserva", dtpData.Value.Date);
                        cmd.Parameters.AddWithValue("@HoraInicio", horaIni);
                        cmd.Parameters.AddWithValue("@HoraFim", horaFim);
                        cmd.Parameters.AddWithValue("@ValorTotal", valorTotal);
                        cmd.Parameters.AddWithValue("@Id", reservaId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Reserva atualizada com sucesso!", "Sucesso",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("❌ Nenhuma reserva foi atualizada!", "Erro",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar:\n{ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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