using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ControleGastos
{
    public class LancamentoDAO
    {
        public void Inserir(Lancamento lancamento)
        {
            FabricaDeConexoes fc = new FabricaDeConexoes();
            MySqlConnection conn;
            conn = fc.ObterConexao();
            String comando = "INSERT INTO controle_gastos (data, descricao, valor) VALUES (@data, @descricao, @valor)";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(comando, conn);
            cmd.Parameters.Add(new MySqlParameter("data", lancamento.data));
            cmd.Parameters.Add(new MySqlParameter("descricao", lancamento.descricao));
            cmd.Parameters.Add(new MySqlParameter("valor", lancamento.valor));
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }

        public List<Lancamento> Retornar()
        {
            List<Lancamento> lancamentos = new List<Lancamento>();

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
                    lancamentos.Add(new Lancamento(Convert.ToInt32(dr["id"]), dr["data"].ToString(), dr["descricao"].ToString(), Convert.ToDecimal(dr["valor"])));
                }

            }
            return lancamentos;
        }
    }
}
