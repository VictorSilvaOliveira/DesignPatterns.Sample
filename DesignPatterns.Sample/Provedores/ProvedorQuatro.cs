using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatterns.Sample.Provedores
{
    public class ProvedorQuatro : BaseProvedor
    {
        public void Publica(string nomeDoImovel, decimal valor, uint quartos)
        {
            EnviaProvedor("provedor-quatro", new
            {
                Quartos = quartos,
                Valor = valor,
                Imovel = nomeDoImovel
            });
        }
    }
}
