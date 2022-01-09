using DesignPatterns.Sample;
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

            var gestorImovel = new GestorImovel("Meu imovel", 100M, 3, "1231231-123123-123213", "Intermediario", new List<BaseProvedor>() { x.Object });

            gestorImovel.PublicaEmProvedores();

            x.Invocations.Count.Equals(1);
        }

        [Fact]
        public void GestorImovel_CobraPlano()
        {
            var x = new Moq.Mock<BaseProvedor>();

            var gestorImovel = new GestorImovel("Meu imovel", 100M, 3, "1231231-123123-123213", "Intermediario", new List<BaseProvedor>() { x.Object });

            gestorImovel.CobraPlano(4);

            x.Invocations.Count.Equals(0);
        }
    }
}