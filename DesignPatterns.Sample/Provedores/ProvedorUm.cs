using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatterns.Sample.Provedores
{
    public class ProvedorUm : BaseProvedor
    {
        public override void Publica(string nomeDoImovel, decimal valor, uint quartos)
        {
            EnviaProvedor("provedor-um", new
            {
                QtdQuartos = quartos,
                Diaria = valor,
                Descricao = nomeDoImovel
            });
        }


    }
}
