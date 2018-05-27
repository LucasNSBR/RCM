using Newtonsoft.Json;
using RCM.Domain.Core.Models;
using System;

namespace RCM.Domain.Models.VendaModels
{
    public class Parcela : ValueObject
    {
        public int Numero { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }

        public DateTime? DataPagamento { get; private set; }
        
        [JsonIgnore]
        public bool Paga
        {
            get
            {
                return DataPagamento != null;
            }
        }


        public Parcela(int numero, DateTime dataVencimento, decimal valor)
        {
            Numero = numero;
            DataVencimento = dataVencimento;
            Valor = valor;
        }

        [JsonConstructor]
        public Parcela(int numero, DateTime dataVencimento, decimal valor, DateTime? dataPagamento)
        {
            Numero = numero;
            DataVencimento = dataVencimento;
            Valor = valor;
            DataPagamento = dataPagamento;
        }
    }
}
