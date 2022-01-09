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

        public GestorImovel(string nomeDoImovel, decimal valor, uint quartos, string cartao, string plano, IEnumerable<BaseProvedor> provedores, IEnumerable<IPlano> planos)
        {
            _nomeDoImovel = nomeDoImovel;
            _valor = valor;
            _plano = plano;
            _quartos = quartos;
            _cartao = cartao;
            _provedores = provedores;
            _planos = planos;
        }

        public void PublicaEmProvedores()
        {
            foreach(var provedor in _provedores)
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

            httpClient.PostAsync("gateway-pagamento", GenerateBody(new
            {
                cartao = _cartao,
                Valor = valorPlano,
            }));

        }

        private ByteArrayContent GenerateBody(object rawBody)
        {
            var myContent = JsonSerializer.Serialize(rawBody, options: new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}