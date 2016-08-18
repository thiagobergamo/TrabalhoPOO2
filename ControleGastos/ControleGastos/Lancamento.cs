using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos
{
    public class Lancamento
    {
        public int id { get; set; }
        public String data { get; set; }
        public String descricao { get; set; }
        public decimal valor { get; set; }

        public Lancamento() { }

        public Lancamento(int id, String data, String descricao, decimal valor)
        {
            this.id = id;
            this.data = data;
            this.descricao = descricao;
            this.valor = valor;
        }

    }
}
