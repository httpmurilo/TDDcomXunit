﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        LeilaoEmAndamento,
        LeilaoFinalizado,
        LeilaoAntesDoPregao
    }
   public class Leilao
    {
        private Interessado _ultimoCliente;
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }
        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
        }

        public void RecebeLance(Interessado cliente, double valor)
        {
            if (Estado == EstadoLeilao.LeilaoEmAndamento)
            {
                if (cliente != _ultimoCliente)
                {
                    _lances.Add(new Lance(cliente, valor));
                    _ultimoCliente = cliente;
                }
               

            }
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null,0))
                .OrderBy(l => l.Valor)
                .LastOrDefault();
            Estado = EstadoLeilao.LeilaoFinalizado;
        }//definindo um valor default apartir de um objeto que sera usado quando o IE tiver vazio
    }
}

    