using System.Net.Http.Headers;
using System.Text.Json;

namespace DesignPatterns.Sample
{
    public class GestorImovel
    {
        private readonly Imovel _imovel = null;
        private readonly IEnumerable<IProvedor> _provedores;
        private readonly IEnumerable<IPlano> _planos;
        private readonly IHttpClient _httpClient;

        public GestorImovel(Imovel imovel, IEnumerable<IProvedor> provedores, IEnumerable<IPlano> planos, IHttpClient httpClient)
        {
            _imovel = imovel;
            _provedores = provedores;
            _planos = planos;
            _httpClient = httpClient;
        }

        public void PublicaEmProvedores()
        {
            foreach (var provedor in _provedores)
            {
                provedor.Publica(_imovel);
            }

        }

        public void CobraPlano(uint qtdDiaria)
        {

            HttpClient httpClient = new HttpClient();

            var valorPlano = _planos
                .First(p => p.Tipo == _imovel.Plano)
                .CalculaValor(qtdDiaria, _imovel.Valor);

            _httpClient.Post("gateway-pagamento", new Pagamento(_imovel.Cartao, valorPlano));

        }

        
    }
}