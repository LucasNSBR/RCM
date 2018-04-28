using RCM.Domain.Core.Models;
using System;
namespace RCM.Domain.Models
{
    public class Pagamento : ValueObject
    {
        public DateTime? DataPagamento { get; private set; }
        public decimal? ValorPago { get; private set; }

        public bool Pago
        {
            get
            {
                return DataPagamento != null && ValorPago != null;
            }
        }

        public Pagamento() { }

        public Pagamento(DateTime? dataPagamento, decimal? valorPago)
        {
            DataPagamento = dataPagamento;
            ValorPago = valorPago;
        }
    }
}
