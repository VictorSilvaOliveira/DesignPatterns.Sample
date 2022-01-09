using DesignPatterns.Sample;
using DesignPatterns.Sample.Planos;
using System.Collections.Generic;
using System.Dynamic;
using Xunit;

namespace DesignerPatterns.Test
{
    public class GestorImovelTest
    {
        [Fact]
        public void GestorImovel_PublicaEmProvedores()
        {
            var x = new Moq.Mock<IProvedor>();

            var httpClient = new Moq.Mock<IHttpClient>();

            var planos = new List<IPlano>
            {
                new Basico(),
                new Intermediario(),
                new Avancado()
            };

            var gestorImovel = new GestorImovel("Meu imovel", 100M, 3, "1231231-123123-123213", "Intermediário", new List<IProvedor>() { x.Object }, planos, httpClient.Object);

            gestorImovel.PublicaEmProvedores();
            httpClient.Invocations.Count.Equals(0);
            x.Invocations.Count.Equals(1);
        }

        [Fact]
        public void GestorImovel_CobraPlano()
        {
            var x = new Moq.Mock<IProvedor>();
            var httpClient = new Moq.Mock<IHttpClient>();
            var planoIntermediario = new Moq.Mock<IPlano>();

            planoIntermediario
                .SetupGet(p => p.Tipo)
                .Returns("Intermediário");

            planoIntermediario
                .Setup(p => p.CalculaValor(Moq.It.IsAny<uint>(), Moq.It.IsAny<decimal>()))
                .Returns<uint, decimal>((diarias, valor) => diarias * valor * 0.20M);

            var planos = new List<IPlano>
            {
                planoIntermediario.Object
            };

            var gestorImovel = new GestorImovel("Meu imovel", 100M, 3, "1231231-123123-123213", "Intermediário", new List<IProvedor>() { x.Object }, planos, httpClient.Object);

            gestorImovel.CobraPlano(4);
            httpClient.Invocations.Count.Equals(1);
            planoIntermediario.Verify(p => p.CalculaValor(Moq.It.Is<uint>(s => s == 4), Moq.It.Is<decimal>(s => s == 100M)), Moq.Times.Once);
            httpClient.Verify(c => c.Post(Moq.It.Is<string>(s => s == "gateway-pagamento"), Moq.It.Is<Pagamento>(o => (o as Pagamento).Cartao == "1231231-123123-123213" && (o as Pagamento).Valor == (4 * 100M * 0.20M))), Moq.Times.Once);
            x.Invocations.Count.Equals(0);
        }
    }
}