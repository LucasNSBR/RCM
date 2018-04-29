using RCM.Domain.Core.Models;
using System;
namespace RCM.Domain.Models
{
    public class Pagamento : ValueObject
    {
        public DateTime? DataPagamento { get; private set; }
        public decimal? ValorPago { get; private set; }
        
        public Pagamento() { }

        public Pagamento(DateTime? dataPagamento, decimal? valorPago)
        {
            DataPagamento = dataPagamento;
            ValorPago = valorPago;
        }
    }
}
