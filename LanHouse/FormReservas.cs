using System;
using System.Drawing;
using System.Windows.Forms;

namespace LanHouseSystem
{
    public partial class FormReservas : Form
    {
        private Usuario usuario;
        private DataGridView dataGridViewReservas;
        private Button btnNovaReserva;
        private Button btnCancelarReserva;
        private Button btnFechar;
        private Label lblTitulo;
        private GroupBox groupBox1;

        public FormReservas(Usuario usuarioLogado)
        {
            InitializeComponent();
            usuario = usuarioLogado;
            CarregarReservas();
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewReservas = new System.Windows.Forms.DataGridView();
            this.btnNovaReserva = new System.Windows.Forms.Button();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📅 MINHAS RESERVAS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewReservas);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservas Ativas e Histórico";
            // 
            // dataGridViewReservas
            // 
            this.dataGridViewReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReservas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridViewReservas.Location = new System.Drawing.Point(20, 25);
            this.dataGridViewReservas.Name = "dataGridViewReservas";
            this.dataGridViewReservas.ReadOnly = true;
            this.dataGridViewReservas.RowHeadersVisible = false;
            this.dataGridViewReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReservas.Size = new System.Drawing.Size(710, 300);
            this.dataGridViewReservas.TabIndex = 0;
            // 
            // btnNovaReserva
            // 
            this.btnNovaReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNovaReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaReserva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNovaReserva.ForeColor = System.Drawing.Color.White;
            this.btnNovaReserva.Location = new System.Drawing.Point(246, 430);
            this.btnNovaReserva.Name = "btnNovaReserva";
            this.btnNovaReserva.Size = new System.Drawing.Size(180, 40);
            this.btnNovaReserva.TabIndex = 2;
            this.btnNovaReserva.Text = "➕ NOVA RESERVA";
            this.btnNovaReserva.UseVisualStyleBackColor = false;
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancelarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarReserva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelarReserva.ForeColor = System.Drawing.Color.White;
            this.btnCancelarReserva.Location = new System.Drawing.Point(432, 430);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(200, 40);
            this.btnCancelarReserva.TabIndex = 3;
            this.btnCancelarReserva.Text = "❌ CANCELAR RESERVA";
            this.btnCancelarReserva.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(638, 430);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 40);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "🔙 VOLTAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click_1);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "COMPUTADOR";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "DATA INÍCIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "DATA FIM";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "STATUS";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "VALOR";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // FormReservas
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(788, 512);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNovaReserva);
            this.Controls.Add(this.btnCancelarReserva);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📅 Minhas Reservas - Lan House System";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).EndInit();
            this.ResumeLayout(false);

        }

        private void CarregarReservas()
        {
            dataGridViewReservas.Rows.Clear();

            // Reservas de exemplo
            dataGridViewReservas.Rows.Add("PC-001", "07/01/2025 14:00", "07/01/2025 16:00", "🟢 ATIVA", "R$ 10,00");
            dataGridViewReservas.Rows.Add("PC-003", "06/01/2025 10:00", "06/01/2025 12:00", "🔵 CONCLUÍDA", "R$ 6,00");
            dataGridViewReservas.Rows.Add("PC-004", "08/01/2025 18:00", "08/01/2025 20:00", "🟢 ATIVA", "R$ 10,00");

            // Colorir status
            foreach (DataGridViewRow row in dataGridViewReservas.Rows)
            {
                if (row.Cells["Status"].Value.ToString().Contains("ATIVA"))
                    row.Cells["Status"].Style.ForeColor = Color.Green;
                else
                    row.Cells["Status"].Style.ForeColor = Color.Blue;
            }
        }

        private void btnNovaReserva_Click(object sender, EventArgs e)
        {
            FormComputadores formComputadores = new FormComputadores();
            formComputadores.ShowDialog();
            CarregarReservas(); // Recarrega após possível nova reserva
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservas.CurrentRow != null)
            {
                string computador = dataGridViewReservas.CurrentRow.Cells["Computador"].Value.ToString();
                string status = dataGridViewReservas.CurrentRow.Cells["Status"].Value.ToString();

                if (status.Contains("ATIVA"))
                {
                    DialogResult result = MessageBox.Show(
                        $"Tem certeza que deseja cancelar a reserva do computador {computador}?",
                        "Confirmar Cancelamento",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show($"✅ Reserva do computador {computador} cancelada com sucesso!",
                                      "Reserva Cancelada",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        CarregarReservas();
                    }
                }
                else
                {
                    MessageBox.Show("⚠️ Apenas reservas ATIVAS podem ser canceladas.",
                                  "Reserva Não Cancelável",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione uma reserva para cancelar.",
                              "Seleção Necessária",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

        private void btnFechar_Click_1(object sender, EventArgs e)
        {

        }
    }
}