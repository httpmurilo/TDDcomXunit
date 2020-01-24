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
        [Theory]
        [InlineData(1, new double[] { 1000, 1200, 1400, 1300 })]
        [InlineData(1, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int QuantidadeEsperada, double[] ofertas)
        {
            var Leilao = new Leilao("Van gohh");
            var Fulano = new Interessado("Fulano", Leilao);

            Leilao.IniciaPregao();
            foreach (var valor in ofertas)
            {
                Leilao.RecebeLance(Fulano, valor);

            }

            Leilao.TerminaPregao();
            //Leilao.RecebeLance(Fulano, 1000);
            //Leilao.RecebeLance(Fulano, 1010);
            var quantidadeObtida = Leilao.Lances.Count();
            Assert.Equal(QuantidadeEsperada, quantidadeObtida);

        }

    }
}
