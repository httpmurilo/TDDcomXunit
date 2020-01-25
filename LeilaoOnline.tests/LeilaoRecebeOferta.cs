using System;
using LeilaoOnline.Core;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace LeilaoOnline.tests
{
    public class LeilaoRecebeOferta
    {

        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessado("Fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);

            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert
            var qtdeEsperada = 1;
            var qtdeObtida = leilao.Lances.Count();
            Assert.Equal(qtdeEsperada, qtdeObtida);
        }

        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            var excecaoCapturada = Assert.Throws<ArgumentException>(
              () => new Lance(null, -100));
        }




        [Theory]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int QuantidadeEsperada, double[] ofertas)
        {
            var Leilao = new Leilao("Van gohh");
            var Fulano = new Interessado("Fulano", Leilao);
            var maria = new Interessado("Maria", Leilao);

            Leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    Leilao.RecebeLance(Fulano, valor);
                }
                else
                {
                    Leilao.RecebeLance(maria, valor);
                }
            }

            Leilao.TerminaPregao();
            Leilao.RecebeLance(Fulano, 1000);
            var quantidadeObtida = Leilao.Lances.Count();
            Assert.Equal(QuantidadeEsperada, quantidadeObtida);

        }

    }
}