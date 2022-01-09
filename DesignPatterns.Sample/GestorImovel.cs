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

        public GestorImovel(string nomeDoImovel, decimal valor, uint quartos, string cartao, string plano)
        {
            _nomeDoImovel = nomeDoImovel;
            _valor = valor;
            _plano = plano;
            _quartos = quartos;
            _cartao = cartao;
        }

        public void PublicaEmProvedores()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.PostAsync("provedor-um", GenerateBody(new
            {
                QtdQuartos = _quartos,
                Diaria = _valor,
                Descricao = _nomeDoImovel
            }));

            httpClient.PostAsync("provedor-dois", GenerateBody(new
            {
                QtdRooms = _quartos,
                UnitValue = _valor,
                Description = _nomeDoImovel
            }));

            httpClient.PostAsync("provedor-tres", GenerateBody(new
            {
                Quatos = _quartos,
                DiariaValor = _valor,
                Nome = _nomeDoImovel
            }));

            httpClient.PostAsync("provedor-quatro", GenerateBody(new
            {
                Quartos = _quartos,
                Valor = _valor,
                Imovel = _nomeDoImovel
            }));
        }

        public void CobraPlano(uint qtdDiaria)
        {
            HttpClient httpClient = new HttpClient();

            var valorPlano = 0M;
            switch (_plano)
            {
                case "Avançado":
                    valorPlano = qtdDiaria * _valor * 0.15M;
                    break;
                case "Intermediário":
                    valorPlano = qtdDiaria * _valor * 0.20M;
                    break;
                case "Basico":
                default:
                    valorPlano = qtdDiaria * _valor * 0.25M;
                    break;
            }

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