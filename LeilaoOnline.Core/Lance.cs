using System;
using System.Collections.Generic;
using System.Text;

namespace LeilaoOnline.Core
{
   public class Lance
    {
        public Interessado Cliente { get; }
        public double Valor { get; }

        public Lance(Interessado cliente, double valor)
        {
            Cliente = cliente;
            if (valor < 0)
            {
                throw new ArgumentException("Lance inválido: valor deve ser maior que zero.");
            }
            Valor = valor;
        }
    }
}
    