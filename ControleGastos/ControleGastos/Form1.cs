using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ControleGastos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Lancamento lancamento = new Lancamento();
            lancamento.data = dtGasto.Value.ToString("yyyy-MM-dd");
            lancamento.descricao = txtDescricao.Text;
            lancamento.valor = Convert.ToDecimal(txtValor.Text);

            LancamentoDAO dao = new LancamentoDAO();
            dao.Inserir(lancamento);
            CarregaGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            dataGridView1.Rows.Clear();
            FabricaDeConexoes fc = new FabricaDeConexoes();
            MySqlConnection conn;
            conn = fc.ObterConexao();
            String comando = "SELECT * FROM controle_gastos";
            conn.Open();
            MySqlCommand comandoRetornar = new MySqlCommand(comando, conn);
            comandoRetornar.Prepare();
            using (MySqlDataReader dr = comandoRetornar.ExecuteReader())
            {
                while (dr.Read())
                {
                    int index = dataGridView1.Rows.Add();
                    DataGridViewRow linhaTabela = dataGridView1.Rows[index];
                    linhaTabela.Cells["id"].Value = dr["id"];
                    linhaTabela.Cells["data"].Value = dr["data"];
                    linhaTabela.Cells["descricao"].Value = dr["descricao"];
                    linhaTabela.Cells["valor"].Value = dr["valor"];
                }

            }
            /*List<Lancamento> lancamentos = new List<Lancamento>();

            LancamentoDAO dao = new LancamentoDAO();
            lancamentos = dao.Retornar();

            foreach(Lancamento lancamento in lancamentos){
                MessageBox.Show(lancamento.descricao);
            }*/

        }
    }
}
