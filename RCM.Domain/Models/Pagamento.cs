using RCM.Domain.Core.Models;
using System;
namespace RCM.Domain.Models
{
    public class Pagamento : ValueObject
    {
        public DateTime DataPagamento { get; private set; }
        public decimal ValorPago { get; private set; }

        //EF Core doesn't allow null Complex Objects
        public Pagamento() {
            DataPagamento = default(DateTime);
        }
        
        public Pagamento(DateTime dataPagamento, decimal valorPago)
        {
            DataPagamento = dataPagamento;
            ValorPago = valorPago;
        }

        public bool IsEmpty()
        {
            return DataPagamento == DateTime.MinValue;
        }
    }
}
