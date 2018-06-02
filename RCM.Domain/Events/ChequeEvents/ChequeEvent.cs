using RCM.Domain.Core.Events;
using RCM.Domain.Models.ChequeModels;

namespace RCM.Domain.Events.ChequeEvents
{
    public abstract class ChequeEvent : DomainEvent
    {
        public Cheque Cheque { get; set; }

        public ChequeEvent(Cheque cheque)
        {
            Cheque = cheque;
        }

        public override void Normalize()
        {
            AggregateId = Cheque.Id;

            Args.Add(nameof(Cheque.BancoId), Cheque.BancoId);
            Args.Add(nameof(Cheque.Agencia), Cheque.Agencia);
            Args.Add(nameof(Cheque.Conta), Cheque.Conta);
            Args.Add(nameof(Cheque.ClienteId), Cheque.ClienteId);
            Args.Add(nameof(Cheque.DataEmissao), Cheque.DataEmissao);
            Args.Add(nameof(Cheque.DataVencimento), Cheque.DataVencimento);
            Args.Add(nameof(Cheque.DataPagamento), Cheque.DataPagamento);
            Args.Add(nameof(Cheque.Valor), Cheque.Valor);
        }
    }
}
