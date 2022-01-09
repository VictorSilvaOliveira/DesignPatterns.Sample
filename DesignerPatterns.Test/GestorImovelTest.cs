using DesignPatterns.Sample;
using DesignPatterns.Sample.Planos;
using System.Collections.Generic;
using Xunit;

namespace DesignerPatterns.Test
{
    public class GestorImovelTest
    {
        [Fact]
        public void GestorImovel_PublicaEmProvedores()
        {
            var x = new Moq.Mock<BaseProvedor>();

            var httpClient = new Moq.Mock<IHttpClient>();

            var planos = new List<IPlano>
            {
                new Basico(),
                new Intermediario(),
                new Avancado()
            };

            var gestorImovel = new GestorImovel("Meu imovel", 100M, 3, "1231231-123123-123213", "Intermediário", new List<BaseProvedor>() { x.Object }, planos, httpClient.Object);

            gestorImovel.PublicaEmProvedores();
            httpClient.Invocations.Count.Equals(0);
            x.Invocations.Count.Equals(1);
        }

        [Fact]
        public void GestorImovel_CobraPlano()
        {
            var x = new Moq.Mock<BaseProvedor>();
            var httpClient = new Moq.Mock<IHttpClient>();
            var planos = new List<IPlano>
            {
                new Basico(),
                new Intermediario(),
                new Avancado()
            };

            var gestorImovel = new GestorImovel("Meu imovel", 100M, 3, "1231231-123123-123213", "Intermediário", new List<BaseProvedor>() { x.Object }, planos, httpClient.Object);

            gestorImovel.CobraPlano(4);
            httpClient.Invocations.Count.Equals(1);
            x.Invocations.Count.Equals(0);
        }
    }
}