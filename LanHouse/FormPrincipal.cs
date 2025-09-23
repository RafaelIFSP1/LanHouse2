using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanHouse
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            CarregarPCs();  // ← Corrigi o nome do método
        }

        private void CarregarPCs()  // ← Nome correto (era "CarregarPGs")
        {
            try
            {
                using (SqlConnection conexao = Database.GetConnection())
                {
                    conexao.Open();
                    string sql = "SELECT * FROM PCs";  // ← Tabela é "PCs", não "PGs"
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao);  // ← "SqlDataAdapter"
                    DataTable dt = new DataTable();  // ← Removi o "(t)"
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;  // ← Isso deve estar DENTRO do using
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarPCs();  // ← Nome correto
        }
    }
}