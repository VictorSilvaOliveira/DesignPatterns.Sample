using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Sample
{
    public class Pagamento
    {
        public Pagamento(string cartao, decimal valor)
        {
            Cartao = cartao;
            Valor = valor;
        }

        public string Cartao { get; private set; }

        public decimal Valor { get; private set; }
    }
}
