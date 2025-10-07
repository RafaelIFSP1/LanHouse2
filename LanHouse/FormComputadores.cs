using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LanHouseSystem
{
    public partial class FormComputadores : Form
    {
        private DataGridView dataGridViewComputadores;
        private Button btnReservar;
        private Button btnFechar;
        private Label lblTitulo;
        private GroupBox groupBox1;

        public FormComputadores()
        {
            InitializeComponent();
            CarregarComputadores();
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewComputadores = new System.Windows.Forms.DataGridView();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComputadores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "💻 COMPUTADORES DISPONÍVEIS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewComputadores);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Computadores";
            // 
            // dataGridViewComputadores
            // 
            this.dataGridViewComputadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewComputadores.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewComputadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewComputadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewComputadores.Location = new System.Drawing.Point(20, 25);
            this.dataGridViewComputadores.Name = "dataGridViewComputadores";
            this.dataGridViewComputadores.ReadOnly = true;
            this.dataGridViewComputadores.RowHeadersVisible = false;
            this.dataGridViewComputadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewComputadores.Size = new System.Drawing.Size(610, 300);
            this.dataGridViewComputadores.TabIndex = 0;
            // 
            // btnReservar
            // 
            this.btnReservar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnReservar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReservar.ForeColor = System.Drawing.Color.White;
            this.btnReservar.Location = new System.Drawing.Point(350, 430);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(200, 40);
            this.btnReservar.TabIndex = 2;
            this.btnReservar.Text = "📅 RESERVAR COMPUTADOR";
            this.btnReservar.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(560, 430);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 40);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "❌ FECHAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "COMPUTADOR";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "STATUS";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ESPECIFICAÇÕES";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "PREÇO/HORA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // FormComputadores
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 475);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormComputadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "💻 Gerenciar Computadores - Lan House System";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComputadores)).EndInit();
            this.ResumeLayout(false);

        }

        private void CarregarComputadores()
        {
            // Limpar dados existentes
            dataGridViewComputadores.Rows.Clear();

            // Adicionar computadores de exemplo
            dataGridViewComputadores.Rows.Add("PC-001", "🟢 DISPONÍVEL", "Intel i5 • 8GB RAM • SSD 256GB • Monitor 24\"", "R$ 5,00");
            dataGridViewComputadores.Rows.Add("PC-002", "🔴 OCUPADO", "Intel i7 • 16GB RAM • SSD 512GB • Monitor 27\"", "R$ 8,00");
            dataGridViewComputadores.Rows.Add("PC-003", "🟢 DISPONÍVEL", "Intel i3 • 4GB RAM • HD 1TB • Monitor 22\"", "R$ 3,00");
            dataGridViewComputadores.Rows.Add("PC-004", "🟢 DISPONÍVEL", "Intel i5 • 8GB RAM • SSD 256GB • Monitor 24\"", "R$ 5,00");
            dataGridViewComputadores.Rows.Add("PC-005", "🟡 MANUTENÇÃO", "Intel i7 • 16GB RAM • SSD 1TB • Monitor 27\"", "R$ 8,00");

            // Colorir status
            foreach (DataGridViewRow row in dataGridViewComputadores.Rows)
            {
                if (row.Cells["Status"].Value.ToString().Contains("DISPONÍVEL"))
                    row.Cells["Status"].Style.ForeColor = Color.Green;
                else if (row.Cells["Status"].Value.ToString().Contains("OCUPADO"))
                    row.Cells["Status"].Style.ForeColor = Color.Red;
                else
                    row.Cells["Status"].Style.ForeColor = Color.Orange;
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (dataGridViewComputadores.CurrentRow != null)
            {
                string computador = dataGridViewComputadores.CurrentRow.Cells["Computador"].Value.ToString();
                string status = dataGridViewComputadores.CurrentRow.Cells["Status"].Value.ToString();

                if (status.Contains("DISPONÍVEL"))
                {
                    MessageBox.Show($"✅ Computador {computador} reservado com sucesso!\n\n" +
                                  $"Você receberá uma confirmação por email.",
                                  "Reserva Confirmada",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"❌ Computador {computador} não está disponível para reserva.\n\n" +
                                  $"Status atual: {status}",
                                  "Computador Indisponível",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um computador para reservar.",
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
    }
}