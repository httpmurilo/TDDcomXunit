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
        [InlineData(1100, new double[] { 800, 900, 1000, 1100 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(
            double valorEsperado,
            double[] ofertas)
        //recebe argumento de entrada
        {
            //Arranje - cenário
            var Leilao = new Leilao("Van Gogh");
            var Artur = new Interessado("Artur", Leilao);
            var maria = new Interessado("Maria", Leilao);

            Leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    Leilao.RecebeLance(Artur, valor);
                }
                else
                {
                    Leilao.RecebeLance(maria, valor);
                }
            }
            Leilao.TerminaPregao();
            var valorObtido = Leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);

        }
        [Fact]
        public void LanceInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            //testando a exceção
            var Leilao = new Leilao("Van gohh");
          var excecaoObtida =   Assert.Throws<System.InvalidOperationException>(
                () => //passando o teste da exceção como delegate
                Leilao.TerminaPregao()
                );
            var msgEsperada = "Não é possivél terminar o pregão sem que ele tenha começado.Para isso utilize o método IniciaPregao()";
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }


        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            var Leilao = new Leilao("Van gohh");
            Leilao.IniciaPregao();
            Leilao.TerminaPregao();

            var valorEsperado = 0;
            var valorObtido = Leilao.Ganhador.Valor;

            Assert.Equal(valorObtido, valorEsperado);

        }


    }
}