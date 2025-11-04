using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lanhause
{
    public partial class FormNovaReserva : Form
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblComputador = new System.Windows.Forms.Label();
            this.cmbComputadores = new System.Windows.Forms.ComboBox();
            this.lblClienteNome = new System.Windows.Forms.Label();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.lblClienteEmail = new System.Windows.Forms.Label();
            this.txtClienteEmail = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.cmbHoraInicio = new System.Windows.Forms.ComboBox();
            this.lblHoraFim = new System.Windows.Forms.Label();
            this.cmbHoraFim = new System.Windows.Forms.ComboBox();
            this.lblHorasTitulo = new System.Windows.Forms.Label();
            this.lblHoras = new System.Windows.Forms.Label();
            this.lblValorTitulo = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "➕ NOVA RESERVA";
            // 
            // lblComputador
            // 
            this.lblComputador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblComputador.Location = new System.Drawing.Point(20, 70);
            this.lblComputador.Name = "lblComputador";
            this.lblComputador.Size = new System.Drawing.Size(250, 20);
            this.lblComputador.TabIndex = 1;
            this.lblComputador.Text = "🖥️ SELECIONE O PC A SER USADO:";
            // 
            // cmbComputadores
            // 
            this.cmbComputadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComputadores.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbComputadores.Location = new System.Drawing.Point(20, 95);
            this.cmbComputadores.Name = "cmbComputadores";
            this.cmbComputadores.Size = new System.Drawing.Size(300, 23);
            this.cmbComputadores.TabIndex = 2;
            this.cmbComputadores.SelectedIndexChanged += new System.EventHandler(this.cmbComputadores_SelectedIndexChanged);
            // 
            // lblClienteNome
            // 
            this.lblClienteNome.Location = new System.Drawing.Point(20, 140);
            this.lblClienteNome.Name = "lblClienteNome";
            this.lblClienteNome.Size = new System.Drawing.Size(100, 20);
            this.lblClienteNome.TabIndex = 3;
            this.lblClienteNome.Text = "👤 Nome do Cliente:";
            // 
            // txtClienteNome
            // 
            this.txtClienteNome.Location = new System.Drawing.Point(120, 137);
            this.txtClienteNome.Name = "txtClienteNome";
            this.txtClienteNome.Size = new System.Drawing.Size(200, 20);
            this.txtClienteNome.TabIndex = 4;
            // 
            // lblClienteEmail
            // 
            this.lblClienteEmail.Location = new System.Drawing.Point(20, 180);
            this.lblClienteEmail.Name = "lblClienteEmail";
            this.lblClienteEmail.Size = new System.Drawing.Size(100, 20);
            this.lblClienteEmail.TabIndex = 5;
            this.lblClienteEmail.Text = "📧 E-mail:";
            // 
            // txtClienteEmail
            // 
            this.txtClienteEmail.Location = new System.Drawing.Point(120, 177);
            this.txtClienteEmail.Name = "txtClienteEmail";
            this.txtClienteEmail.Size = new System.Drawing.Size(200, 20);
            this.txtClienteEmail.TabIndex = 6;
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(20, 220);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(100, 20);
            this.lblData.TabIndex = 7;
            this.lblData.Text = "📅 Data:";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(120, 217);
            this.dtpData.MinDate = new System.DateTime(2025, 11, 4, 0, 0, 0, 0);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(120, 20);
            this.dtpData.TabIndex = 8;
            this.dtpData.ValueChanged += new System.EventHandler(this.dtpData_ValueChanged);
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.Location = new System.Drawing.Point(20, 260);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(100, 20);
            this.lblHoraInicio.TabIndex = 9;
            this.lblHoraInicio.Text = "⏰ Hora Início:";
            // 
            // cmbHoraInicio
            // 
            this.cmbHoraInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraInicio.Location = new System.Drawing.Point(120, 257);
            this.cmbHoraInicio.Name = "cmbHoraInicio";
            this.cmbHoraInicio.Size = new System.Drawing.Size(100, 21);
            this.cmbHoraInicio.TabIndex = 10;
            this.cmbHoraInicio.SelectedIndexChanged += new System.EventHandler(this.cmbHorarios_SelectedIndexChanged);
            // 
            // lblHoraFim
            // 
            this.lblHoraFim.Location = new System.Drawing.Point(20, 300);
            this.lblHoraFim.Name = "lblHoraFim";
            this.lblHoraFim.Size = new System.Drawing.Size(100, 20);
            this.lblHoraFim.TabIndex = 11;
            this.lblHoraFim.Text = "⏱️ Hora Fim:";
            // 
            // cmbHoraFim
            // 
            this.cmbHoraFim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraFim.Location = new System.Drawing.Point(120, 297);
            this.cmbHoraFim.Name = "cmbHoraFim";
            this.cmbHoraFim.Size = new System.Drawing.Size(100, 21);
            this.cmbHoraFim.TabIndex = 12;
            this.cmbHoraFim.SelectedIndexChanged += new System.EventHandler(this.cmbHorarios_SelectedIndexChanged);
            // 
            // lblHorasTitulo
            // 
            this.lblHorasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHorasTitulo.Location = new System.Drawing.Point(20, 340);
            this.lblHorasTitulo.Name = "lblHorasTitulo";
            this.lblHorasTitulo.Size = new System.Drawing.Size(100, 20);
            this.lblHorasTitulo.TabIndex = 13;
            this.lblHorasTitulo.Text = "⏳ Horas Totais:";
            // 
            // lblHoras
            // 
            this.lblHoras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoras.ForeColor = System.Drawing.Color.Blue;
            this.lblHoras.Location = new System.Drawing.Point(120, 337);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(150, 25);
            this.lblHoras.TabIndex = 14;
            this.lblHoras.Text = "0 horas";
            // 
            // lblValorTitulo
            // 
            this.lblValorTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValorTitulo.Location = new System.Drawing.Point(20, 370);
            this.lblValorTitulo.Name = "lblValorTitulo";
            this.lblValorTitulo.Size = new System.Drawing.Size(100, 20);
            this.lblValorTitulo.TabIndex = 15;
            this.lblValorTitulo.Text = "💰 Valor Total:";
            // 
            // lblValor
            // 
            this.lblValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.Green;
            this.lblValor.Location = new System.Drawing.Point(120, 367);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(150, 25);
            this.lblValor.TabIndex = 16;
            this.lblValor.Text = "R$ 0,00";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(80, 420);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(140, 40);
            this.btnConfirmar.TabIndex = 17;
            this.btnConfirmar.Text = "✅ CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(230, 420);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 40);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "❌ CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormNovaReserva
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 480);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblComputador);
            this.Controls.Add(this.cmbComputadores);
            this.Controls.Add(this.lblClienteNome);
            this.Controls.Add(this.txtClienteNome);
            this.Controls.Add(this.lblClienteEmail);
            this.Controls.Add(this.txtClienteEmail);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.lblHoraInicio);
            this.Controls.Add(this.cmbHoraInicio);
            this.Controls.Add(this.lblHoraFim);
            this.Controls.Add(this.cmbHoraFim);
            this.Controls.Add(this.lblHorasTitulo);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.lblValorTitulo);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormNovaReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "➕ Nova Reserva - Lan House System";
            this.Load += new System.EventHandler(this.FormNovaReserva_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CarregarComputadores()
        {
            try
            {
                cmbComputadores.Items.Clear();

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Id, Nome, PrecoHora FROM Computadores WHERE Status = '🟢 DISPONÍVEL' ORDER BY Nome";

                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nomeComputador = reader["Nome"].ToString();
                            decimal precoHora = Convert.ToDecimal(reader["PrecoHora"]);

                            string display = $"{nomeComputador} - R$ {precoHora:F2}/hora";

                            cmbComputadores.Items.Add(new ComputadorItem
                            {
                                Display = display,
                                Id = reader["Id"].ToString(),
                                PrecoHora = precoHora
                            });
                        }
                    }
                }

                // Se não encontrou computadores no banco, cria os 5 PCs padrão
                if (cmbComputadores.Items.Count == 0)
                {
                    CriarComputadoresPadrao();
                }

                // Adiciona um item padrão no topo
                cmbComputadores.Items.Insert(0, new ComputadorItem
                {
                    Display = "🖥️ SELECIONE UM COMPUTADOR",
                    Id = "",
                    PrecoHora = 0
                });

                cmbComputadores.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar computadores: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Em caso de erro, cria os PCs padrão
                CriarComputadoresPadrao();
            }
        }

        private void CriarComputadoresPadrao()
        {
            cmbComputadores.Items.Clear();

            // Adiciona os 5 PCs padrão
            cmbComputadores.Items.Add(new ComputadorItem
            {
                Display = "🖥️ SELECIONE UM COMPUTADOR",
                Id = "",
                PrecoHora = 0
            });

            cmbComputadores.Items.Add(new ComputadorItem
            {
                Display = "💻 PC Gamer 1 - R$ 8,00/hora",
                Id = "PC-001",
                PrecoHora = 8.00m
            });

            cmbComputadores.Items.Add(new ComputadorItem
            {
                Display = "💻 PC Gamer 2 - R$ 8,00/hora",
                Id = "PC-002",
                PrecoHora = 8.00m
            });

            cmbComputadores.Items.Add(new ComputadorItem
            {
                Display = "💻 PC Standard 1 - R$ 5,00/hora",
                Id = "PC-003",
                PrecoHora = 5.00m
            });

            cmbComputadores.Items.Add(new ComputadorItem
            {
                Display = "💻 PC Standard 2 - R$ 5,00/hora",
                Id = "PC-004",
                PrecoHora = 5.00m
            });

            cmbComputadores.Items.Add(new ComputadorItem
            {
                Display = "💻 PC Básico 1 - R$ 3,00/hora",
                Id = "PC-005",
                PrecoHora = 3.00m
            });

            cmbComputadores.SelectedIndex = 0;
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
                computador.PrecoHora > 0 &&
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
                                                DataReserva, HoraInicio, HoraFim, Status, ValorTotal, UsuarioId)
                            VALUES (@Id, @ComputadorId, @ClienteNome, @ClienteEmail, 
                                    @DataReserva, @HoraInicio, @HoraFim, @Status, @ValorTotal, @UsuarioId)";

                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", reservaId);
                            command.Parameters.AddWithValue("@ComputadorId", computador.Id);
                            command.Parameters.AddWithValue("@ClienteNome", txtClienteNome.Text.Trim());
                            command.Parameters.AddWithValue("@ClienteEmail", txtClienteEmail.Text.Trim());
                            command.Parameters.AddWithValue("@DataReserva", dtpData.Value.ToString("yyyy-MM-dd"));
                            command.Parameters.AddWithValue("@HoraInicio", cmbHoraInicio.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@HoraFim", cmbHoraFim.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@Status", "🟢 CONFIRMADA");
                            command.Parameters.AddWithValue("@ValorTotal", valorTotal);
                            command.Parameters.AddWithValue("@UsuarioId", FormLogin.UsuarioId.ToString());

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"✅ Reserva confirmada com sucesso!\n\n" +
                                  $"Código: {reservaId}\n" +
                                  $"Cliente: {txtClienteNome.Text}\n" +
                                  $"Computador: {((ComputadorItem)cmbComputadores.SelectedItem).Display.Split('-')[0].Trim()}\n" +
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

            if (cmbComputadores.SelectedItem == null ||
                ((ComputadorItem)cmbComputadores.SelectedItem).PrecoHora == 0)
            {
                MessageBox.Show("⚠️ Selecione um computador válido.", "Validação",
                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbComputadores.Focus();
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

        // Event handlers para calcular valor automaticamente
        private void cmbComputadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularValor();
        }

        private void cmbHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularValor();
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            CalcularValor();
        }

        private void FormNovaReserva_Load(object sender, EventArgs e)
        {
            // Configurações adicionais no load se necessário
        }

        private Label lblTitulo;
        private Label lblComputador;
        private Label lblClienteNome;
        private Label lblClienteEmail;
        private Label lblData;
        private Label lblHoraInicio;
        private Label lblHoraFim;
        private Label lblHorasTitulo;
        private Label lblValorTitulo;
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