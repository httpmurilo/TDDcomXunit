using System;
using LeilaoOnline.Core;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;


public class LeilaoRecebeOfertaQtdePermaneceZeroDadoQuePregaoNaoFoiIniciado
{
    [Fact]
    public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLanche()
    {
        var leilao = new Leilao("Van Goug");
        var fulano = new Interessado("Murilo", leilao);
        leilao.IniciaPregao();
        leilao.RecebeLance(fulano, 800);
        leilao.RecebeLance(fulano, 100);
        var quantidadeEsperada = 1;
        var quantidadeObtida = leilao.Lances.Count();
        Assert.Equal(quantidadeEsperada, quantidadeObtida);
    }


    [Theory]
    [InlineData(new double[] { 200, 300, 400, 500 })]
    [InlineData(new double[] { 200 })]
    [InlineData(new double[] { 200, 300, 400, 500, 600, 700 })]

    public void ValidaLeilaoComPeriodoAntesDoPregao(double[] ofertas)
    {
        var leilao = new Leilao("Van Goug");
        var fulano = new Interessado("Murilo", leilao);
        foreach (var valor in ofertas)
        {
            leilao.RecebeLance(fulano, valor);
        }
        Assert.Empty(leilao.Lances);
        //Assert.Equal não é recomendado para checar um tamanho de coleção.  Assert.Equal(0, leilao.Lances.Count());
    }
}
