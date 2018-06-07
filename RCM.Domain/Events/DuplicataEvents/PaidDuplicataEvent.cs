using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.ValueObjects;

namespace RCM.Domain.Events.DuplicataEvents
{
    public class PaidDuplicataEvent : DuplicataEvent
    {
        public Pagamento Pagamento { get; private set; }

        public PaidDuplicataEvent(Duplicata duplicata, Pagamento pagamento) : base(duplicata)
        {
            Pagamento = pagamento;
        }

        public override void Normalize()
        {
            Args.Add(nameof(Pagamento.DataPagamento), Pagamento.DataPagamento);
            Args.Add(nameof(Pagamento.ValorPago), Pagamento.ValorPago);
        }
    }
}
