using DesignPatterns.Sample;
using Xunit;

namespace DesignerPatterns.Test
{
    public class GestorImovelTest
    {
        [Fact]
        public void GestorImovel_PublicaEmProvedores()
        {
            var gestorImovel = new GestorImovel("Meu imovel", 100M, 3, "1231231-123123-123213", "Intermediario");

            gestorImovel.PublicaEmProvedores();

            //???
        }

        [Fact]
        public void GestorImovel_CobraPlano()
        {
            var gestorImovel = new GestorImovel("Meu imovel", 100M, 3, "1231231-123123-123213", "Intermediario");

            gestorImovel.PublicaEmProvedores();

            //???
        }
    }
}