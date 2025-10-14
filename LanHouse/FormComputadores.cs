using System;
using System.Drawing;
using System.Windows.Forms;

namespace lanhause
{
    public partial class FormComputadores : Form
    {
        public FormComputadores()
        {
            InitializeComponent();
            CarregarComputadores();
        }

        private void CarregarComputadores()
        {
            // Limpa as colunas existentes
            dataGridViewComputadores.Columns.Clear();

            // Adiciona as colunas
            dataGridViewComputadores.Columns.Add("ID", "ID");
            dataGridViewComputadores.Columns.Add("Nome", "NOME DO PC");
            dataGridViewComputadores.Columns.Add("Processador", "PROCESSADOR");
            dataGridViewComputadores.Columns.Add("RAM", "MEMÓRIA RAM");
            dataGridViewComputadores.Columns.Add("Status", "STATUS");

            // Limpa as linhas existentes
            dataGridViewComputadores.Rows.Clear();

            // Adiciona os computadores
            dataGridViewComputadores.Rows.Add("PC-001", "Computador 1", "Intel i5", "8GB DDR4", "🟢 DISPONÍVEL");
            dataGridViewComputadores.Rows.Add("PC-002", "Computador 2", "Intel i7", "16GB DDR4", "🟡 OCUPADO");
            dataGridViewComputadores.Rows.Add("PC-003", "Computador 3", "AMD Ryzen 5", "8GB DDR4", "🟢 DISPONÍVEL");
            dataGridViewComputadores.Rows.Add("PC-004", "Computador 4", "Intel i3", "4GB DDR4", "🔴 MANUTENÇÃO");

            // Colorir as linhas baseado no status
            foreach (DataGridViewRow row in dataGridViewComputadores.Rows)
            {
                string status = row.Cells["Status"].Value.ToString();
                if (status.Contains("DISPONÍVEL"))
                    row.Cells["Status"].Style.ForeColor = Color.Green;
                else if (status.Contains("OCUPADO"))
                    row.Cells["Status"].Style.ForeColor = Color.Orange;
                else
                    row.Cells["Status"].Style.ForeColor = Color.Red;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("➕ Funcionalidade: Adicionar Novo Computador\n\n" +
                          "Abrir formulário de cadastro de computadores...",
                          "Adicionar Computador",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewComputadores.CurrentRow != null)
            {
                string nome = dataGridViewComputadores.CurrentRow.Cells["Nome"].Value.ToString();
                MessageBox.Show($"✏️ Editando computador: {nome}",
                              "Editar Computador",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um computador para editar.",
                              "Seleção Necessária",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            }
        }

        private void btnManutencao_Click(object sender, EventArgs e)
        {
            if (dataGridViewComputadores.CurrentRow != null)
            {
                string nome = dataGridViewComputadores.CurrentRow.Cells["Nome"].Value.ToString();
                string statusAtual = dataGridViewComputadores.CurrentRow.Cells["Status"].Value.ToString();

                string novaAcao = statusAtual.Contains("MANUTENÇÃO") ? "retirar da manutenção" : "colocar em manutenção";

                DialogResult result = MessageBox.Show(
                    $"Tem certeza que deseja {novaAcao} o computador {nome}?",
                    $"Confirmar {novaAcao.ToUpper()}",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"✅ Computador {nome} {novaAcao} com sucesso!",
                                  "Operação Concluída",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    CarregarComputadores();
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selecione um computador para manutenção.",
                              "Seleção Necessária",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}