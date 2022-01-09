using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Sample
{
    public interface IPlano
    {
        string Tipo { get; }
        decimal Taxa { get; }
        decimal CalculaValor(uint diarias, decimal valor);
    }
}
