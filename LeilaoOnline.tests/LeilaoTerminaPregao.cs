using LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeilaoOnline.tests
{
    public class LeilaoTerminaPregao
    {

        [Theory]
        //dados de entrada, agrupando um grupo de valores, array com 4 elementos 
        [InlineData(800, new double[] { 800, 900, 1000, 1100 })]
        [InlineData(800, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(
            double valorEsperado,
            double[] ofertas)
        //recebe argumento de entrada
        {
            //Arranje - cenário
            var Leilao = new Leilao("Van Gogh");
            var Artur = new Interessado("Artur", Leilao);

            Leilao.IniciaPregao();
            foreach (var valor in ofertas)
            {
                //parametrizando os valores de entrada
                Leilao.RecebeLance(Artur, valor);
            }
            Leilao.TerminaPregao();
            var valorObtido = Leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);

        }


        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            var Leilao = new Leilao("Van gohh");
            Leilao.TerminaPregao();

            var valorEsperado = 0;
            var valorObtido = Leilao.Ganhador.Valor;

            Assert.Equal(valorObtido, valorEsperado);

        }

    }
}
