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
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado()
        {
                var Leilao = new Leilao("Van gohh");
            var Fulano = new Interessado("Fulano", Leilao);
            Leilao.RecebeLance(Fulano, 900);
            Leilao.RecebeLance(Fulano, 1000);
            Leilao.TerminaPregao();


            Leilao.RecebeLance(Fulano, 1010);
            var valorEsperado = 2;
                var valorObtido = Leilao.Lances.Count();

                Assert.Equal(valorObtido, valorEsperado);

            }

        }
    }
