using System.Net.Http.Headers;
using System.Text.Json;

namespace DesignPatterns.Sample
{
    public class GestorImovel
    {
        public string _nomeDoImovel = string.Empty;
        public decimal _valor = 0M;
        string _plano = string.Empty;
        uint _quartos = 1;
        private string _cartao;
        private readonly IEnumerable<BaseProvedor> _provedores;
        private readonly IEnumerable<IPlano> _planos;
        private readonly IHttpClient _httpClient;

        public GestorImovel(string nomeDoImovel, decimal valor, uint quartos, string cartao, string plano, IEnumerable<BaseProvedor> provedores, IEnumerable<IPlano> planos, IHttpClient httpClient)
        {
            _nomeDoImovel = nomeDoImovel;
            _valor = valor;
            _plano = plano;
            _quartos = quartos;
            _cartao = cartao;
            _provedores = provedores;
            _planos = planos;
            _httpClient = httpClient;
        }

        public void PublicaEmProvedores()
        {
            foreach (var provedor in _provedores)
            {
                provedor.Publica(_nomeDoImovel, _valor, _quartos);
            }

        }

        public void CobraPlano(uint qtdDiaria)
        {

            HttpClient httpClient = new HttpClient();

            var valorPlano = _planos
                .First(p => p.Tipo == _plano)
                .CalculaValor(qtdDiaria, _valor);

            _httpClient.Post("gateway-pagamento", new Pagamento(_cartao, valorPlano));

        }

        
    }
}