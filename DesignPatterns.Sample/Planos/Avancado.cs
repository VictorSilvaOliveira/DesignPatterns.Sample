using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Sample.Planos
{
    public class Avancado : IPlano
    {
        public string Tipo => "Avancado";

        public decimal Taxa => 0.15M;

        public decimal CalculaValor(uint diarias, decimal valor)
        {
            return diarias * valor * Taxa;
        }
    }
}
