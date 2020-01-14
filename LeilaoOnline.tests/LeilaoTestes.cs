using LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeilaoOnline.tests
{
    public class LeilaoTestes
    {

        [Theory]
        //dados de entrada, agrupando um grupo de valores, array com 4 elementos 
        [InlineData(1000, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void LeilaoComVariosLances(
            double valorEsperado,
            double[] ofertas)
        //recebe argumento de entrada
        {
            //Arranje - cenário
            var Leilao = new Leilao("Van Gogh");
            var Murilo = new Interessado("Murilo", Leilao);
            var Artur = new Interessado("Artur", Leilao);

            foreach (var valor in ofertas)
            {
                //parametrizando os valores de entrada
                Leilao.RecebeLance(Murilo, valor);
            }

            var valorObtido = Leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);

        }


        [Fact]
        public void LeilaoSemLances()
        {
            var Leilao = new Leilao("Van gohh");
            Leilao.TerminaPregao();

            var valorEsperado = 0;
            var valorObtido = Leilao.Ganhador.Valor;

            Assert.Equal(valorObtido, valorEsperado);

        }

    }
}
