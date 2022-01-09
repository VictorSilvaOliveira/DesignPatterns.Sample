using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatterns.Sample.Provedores
{
    public class ProvedorDois : HttpProvedor, IProvedor
    {
        public ProvedorDois(IHttpClient httpClient) : base(httpClient)
        {
        }


        public void Publica(Imovel imovel)
        {
            EnviaProvedor("provedor-dois", new
            {
                QtdRooms = imovel.Quartos,
                UnitValue = imovel.Valor,
                Description = imovel.Nome
            });

        }
    }
}
