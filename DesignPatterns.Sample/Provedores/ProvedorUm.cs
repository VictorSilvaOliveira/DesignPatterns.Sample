using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatterns.Sample.Provedores
{
    public class ProvedorUm : HttpProvedor, IProvedor
    {
        public ProvedorUm(IHttpClient httpClient) : base(httpClient)
        {
        }

        public void Publica(Imovel imovel)
        {
            EnviaProvedor("provedor-um", new
            {
                QtdQuartos = imovel.Quartos,
                Diaria = imovel.Valor,
                Descricao = imovel.Nome
            });
        }


    }
}
