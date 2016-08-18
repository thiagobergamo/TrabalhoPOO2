using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ControleGastos
{
    public class FabricaDeConexoes
    {
        public MySqlConnection ObterConexao()
        {
            String str = @"server=localhost;database=controlegastos;userid=usuario;password=senha;";
            MySqlConnection conn = new MySqlConnection(str);
            return conn;
        }
    }
}
