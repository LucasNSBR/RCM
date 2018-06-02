using RCM.Domain.Core.Events;
using RCM.Domain.Models.DuplicataModels;

namespace RCM.Domain.Events.DuplicataEvents
{
    public abstract class DuplicataEvent : DomainEvent
    {
        public Duplicata Duplicata { get; set; }

        public DuplicataEvent(Duplicata duplicata)
        {
            Duplicata = duplicata;
        }

        public override void Normalize()
        {
            AggregateId = Duplicata.Id;

            Args.Add(nameof(Duplicata.NumeroDocumento), Duplicata.NumeroDocumento);
            Args.Add(nameof(Duplicata.NotaFiscalId), Duplicata.NotaFiscalId);
            Args.Add(nameof(Duplicata.Observacao), Duplicata.Observacao);
            Args.Add(nameof(Duplicata.DataEmissao), Duplicata.DataEmissao);
            Args.Add(nameof(Duplicata.DataVencimento), Duplicata.DataVencimento);
            Args.Add(nameof(Duplicata.FornecedorId), Duplicata.FornecedorId);
            Args.Add(nameof(Duplicata.Valor), Duplicata.Valor);
        }
    }
}