using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace lanhause
{
    public class FormNovaReserva : Form
    {
        private ComboBox cmbComputadores;
        private TextBox txtClienteNome;
        private TextBox txtClienteEmail;
        private DateTimePicker dtpData;
        private ComboBox cmbHoraInicio;
        private ComboBox cmbHoraFim;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label lblValor;
        private Label lblHoras;
        private decimal valorTotal = 0;
        private int horasTotais = 0;

        public FormNovaReserva()
        {
            InitializeComponent();
            CarregarComputadores();
            CarregarHorarios();
            CalcularValor();
        }

        private void InitializeComponent()
        {
            // Configuração básica do form
            this.Text = "➕ Nova Reserva - Lan House System";
            this.Size = new Size(500, 500);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Título
            var lblTitulo = new Label();
            lblTitulo.Text = "➕ NOVA RESERVA";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(40, 167, 69);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(300, 30);
            this.Controls.Add(lblTitulo);

            // Computador
            var lblComputador = new Label();
            lblComputador.Text = "Computador:";
            lblComputador.Location = new Point(20, 70);
            lblComputador.Size = new Size(100, 20);
            this.Controls.Add(lblComputador);

            cmbComputadores = new ComboBox();
            cmbComputadores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbComputadores.Location = new Point(120, 67);
            cmbComputadores.Size = new Size(200, 25);
         
            this.Controls.Add(cmbComputadores);

            // Cliente
            var lblClienteNome = new Label();
            lblClienteNome.Text = "Nome do Cliente:";
            lblClienteNome.Location = new Point(20, 110);
            lblClienteNome.Size = new Size(100, 20);
            this.Controls.Add(lblClienteNome);

            txtClienteNome = new TextBox();
            txtClienteNome.Location = new Point(120, 107);
            txtClienteNome.Size = new Size(200, 25);
            this.Controls.Add(txtClienteNome);

            // Email
            var lblClienteEmail = new Label();
            lblClienteEmail.Text = "E-mail:";
            lblClienteEmail.Location = new Point(20, 150);
            lblClienteEmail.Size = new Size(100, 20);
            this.Controls.Add(lblClienteEmail);

            txtClienteEmail = new TextBox();
            txtClienteEmail.Location = new Point(120, 147);
            txtClienteEmail.Size = new Size(200, 25);
            this.Controls.Add(txtClienteEmail);

            // Data
            var lblData = new Label();
            lblData.Text = "Data:";
            lblData.Location = new Point(20, 190);
            lblData.Size = new Size(100, 20);
            this.Controls.Add(lblData);

            dtpData = new DateTimePicker();
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Location = new Point(120, 187);
            dtpData.Size = new Size(120, 25);
            dtpData.MinDate = DateTime.Today;
            this.Controls.Add(dtpData);

            // Hora Início
            var lblHoraInicio = new Label();
            lblHoraInicio.Text = "Hora Início:";
            lblHoraInicio.Location = new Point(20, 230);
            lblHoraInicio.Size = new Size(100, 20);
            this.Controls.Add(lblHoraInicio);

            cmbHoraInicio = new ComboBox();
            cmbHoraInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHoraInicio.Location = new Point(120, 227);
            cmbHoraInicio.Size = new Size(100, 25);
           
            this.Controls.Add(cmbHoraInicio);

            // Hora Fim
            var lblHoraFim = new Label();
            lblHoraFim.Text = "Hora Fim:";
            lblHoraFim.Location = new Point(20, 270);
            lblHoraFim.Size = new Size(100, 20);
            this.Controls.Add(lblHoraFim);

            cmbHoraFim = new ComboBox();
            cmbHoraFim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHoraFim.Location = new Point(120, 267);
            cmbHoraFim.Size = new Size(100, 25);
         
            this.Controls.Add(cmbHoraFim);

            // Horas Totais
            var lblHorasTitulo = new Label();
            lblHorasTitulo.Text = "Horas Totais:";
            lblHorasTitulo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblHorasTitulo.Location = new Point(20, 310);
            lblHorasTitulo.Size = new Size(100, 20);
            this.Controls.Add(lblHorasTitulo);

            lblHoras = new Label();
            lblHoras.Text = "0 horas";
            lblHoras.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblHoras.ForeColor = Color.Blue;
            lblHoras.Location = new Point(120, 307);
            lblHoras.Size = new Size(150, 25);
            this.Controls.Add(lblHoras);

            // Valor
            var lblValorTitulo = new Label();
            lblValorTitulo.Text = "Valor Total:";
            lblValorTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblValorTitulo.Location = new Point(20, 340);
            lblValorTitulo.Size = new Size(100, 20);
            this.Controls.Add(lblValorTitulo);

            lblValor = new Label();
            lblValor.Text = "R$ 0,00";
            lblValor.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblValor.ForeColor = Color.Green;
            lblValor.Location = new Point(120, 337);
            lblValor.Size = new Size(150, 25);
            this.Controls.Add(lblValor);

            // Botões
            btnConfirmar = new Button();
            btnConfirmar.Text = "✅ CONFIRMAR";
            btnConfirmar.BackColor = Color.FromArgb(40, 167, 69);
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(120, 380);
            btnConfirmar.Size = new Size(140, 40);
            btnConfirmar.Click += new EventHandler(btnConfirmar_Click);
            this.Controls.Add(btnConfirmar);

            btnCancelar = new Button();
            btnCancelar.Text = "❌ CANCELAR";
            btnCancelar.BackColor = Color.FromArgb(108, 117, 125);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(270, 380);
            btnCancelar.Size = new Size(140, 40);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.Controls.Add(btnCancelar);
        }

        private void CarregarComputadores()
        {
            try
            {
                cmbComputadores.Items.Clear();

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Id, Nome, PrecoHora FROM Computadores WHERE Status = '🟢 DISPONÍVEL'";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string display = $"{reader["Nome"]} (R$ {reader["PrecoHora"]}/h)";
                            cmbComputadores.Items.Add(new ComputadorItem
                            {
                                Display = display,
                                Id = reader["Id"].ToString(),
                                PrecoHora = Convert.ToDecimal(reader["PrecoHora"])
                            });
                        }
                    }
                }

                if (cmbComputadores.Items.Count > 0)
                    cmbComputadores.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar computadores: {ex.Message}", "Erro",
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

            if (cmbHoraInicio.Items.Count > 0) cmbHoraInicio.SelectedIndex = 0;
            if (cmbHoraFim.Items.Count > 1) cmbHoraFim.SelectedIndex = 2;
        }

        private void CalcularValor()
        {
            if (cmbComputadores.SelectedItem is ComputadorItem computador &&
                cmbHoraInicio.SelectedItem != null &&
                cmbHoraFim.SelectedItem != null)
            {
                TimeSpan duracao = CalcularDuracao();
                horasTotais = (int)Math.Ceiling(duracao.TotalHours);
                valorTotal = computador.PrecoHora * horasTotais;

                // Atualizar labels
                lblHoras.Text = $"{horasTotais} hora{(horasTotais != 1 ? "s" : "")} ({duracao.TotalHours:F1}h reais)";
                lblValor.Text = $"R$ {valorTotal:F2}";
            }
            else
            {
                horasTotais = 0;
                valorTotal = 0;
                lblHoras.Text = "0 horas";
                lblValor.Text = "R$ 0,00";
            }
        }

        private TimeSpan CalcularDuracao()
        {
            if (cmbHoraInicio.SelectedItem != null && cmbHoraFim.SelectedItem != null)
            {
                // Converter de "08.00" para TimeSpan
                string inicioStr = cmbHoraInicio.SelectedItem.ToString().Replace('.', ':');
                string fimStr = cmbHoraFim.SelectedItem.ToString().Replace('.', ':');

                TimeSpan inicio = TimeSpan.Parse(inicioStr);
                TimeSpan fim = TimeSpan.Parse(fimStr);

                if (fim > inicio)
                    return fim - inicio;
                else
                    // Se horário fim for menor que início, considerar que passa para o dia seguinte
                    return (TimeSpan.FromHours(24) - inicio) + fim;
            }
            return TimeSpan.Zero;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDados())
            {
                try
                {
                    string reservaId = $"RES-{DateTime.Now:yyyyMMdd-HHmmss}";

                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();

                        var computador = (ComputadorItem)cmbComputadores.SelectedItem;
                        TimeSpan duracao = CalcularDuracao();
                        decimal horasReais = (decimal)duracao.TotalHours;

                        string query = @"
                            INSERT INTO Reservas (Id, ComputadorId, ClienteNome, ClienteEmail, 
                                                DataReserva, HoraInicio, HoraFim, Status, ValorTotal)
                            VALUES (@Id, @ComputadorId, @ClienteNome, @ClienteEmail, 
                                    @DataReserva, @HoraInicio, @HoraFim, @Status, @ValorTotal)";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", reservaId);
                            command.Parameters.AddWithValue("@ComputadorId", computador.Id);
                            command.Parameters.AddWithValue("@ClienteNome", txtClienteNome.Text);
                            command.Parameters.AddWithValue("@ClienteEmail", txtClienteEmail.Text);
                            command.Parameters.AddWithValue("@DataReserva", dtpData.Value.ToString("yyyy-MM-dd"));
                            command.Parameters.AddWithValue("@HoraInicio", cmbHoraInicio.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@HoraFim", cmbHoraFim.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@Status", "🟢 CONFIRMADA");
                            command.Parameters.AddWithValue("@ValorTotal", valorTotal);

                            command.ExecuteNonQuery();
                        }

                        // REGISTRAR USO DO COMPUTADOR com horas reais
                        DatabaseHelper.RegistrarUsoComputador(
                            computador.Id,
                            dtpData.Value,
                            horasReais,
                            valorTotal
                        );
                    }

                    MessageBox.Show($"✅ Reserva confirmada com sucesso!\n\n" +
                                  $"Código: {reservaId}\n" +
                                  $"Cliente: {txtClienteNome.Text}\n" +
                                  $"Horas: {horasTotais}h\n" +
                                  $"Valor: R$ {valorTotal:F2}",
                                  "Reserva Confirmada",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao criar reserva: {ex.Message}", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarDados()
        {
            if (string.IsNullOrWhiteSpace(txtClienteNome.Text))
            {
                MessageBox.Show("⚠️ Informe o nome do cliente.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtClienteNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtClienteEmail.Text))
            {
                MessageBox.Show("⚠️ Informe o e-mail do cliente.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtClienteEmail.Focus();
                return false;
            }

            if (cmbComputadores.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Selecione um computador.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            TimeSpan duracao = CalcularDuracao();
            if (duracao.TotalHours <= 0)
            {
                MessageBox.Show("⚠️ Horário de término deve ser após o horário de início.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public class ComputadorItem
    {
        public string Display { get; set; }
        public string Id { get; set; }
        public decimal PrecoHora { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}