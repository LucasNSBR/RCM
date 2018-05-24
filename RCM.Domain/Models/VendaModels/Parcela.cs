using System;

namespace RCM.Domain.Models.VendaModels
{
    public class Parcela
    {
        public int Numero { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }

        public DateTime? DataPagamento { get; private set; }

        public Parcela(int numero, DateTime dataVencimento, decimal valor)
        {
            Numero = numero;
            DataVencimento = dataVencimento;
            Valor = valor;
        }
    }
}
