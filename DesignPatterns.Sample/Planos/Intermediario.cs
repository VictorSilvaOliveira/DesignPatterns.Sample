using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Sample.Planos
{
    public class Intermediario : IPlano
    {
        public string Tipo => "Intermediário";

        public decimal Taxa => 0.20M;

        public decimal CalculaValor(uint diarias, decimal valor)
        {
            return diarias * valor * 0.20M;
        }
    }
}
