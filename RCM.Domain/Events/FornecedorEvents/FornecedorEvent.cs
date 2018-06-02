using RCM.Domain.Core.Events;
using RCM.Domain.Models.FornecedorModels;

namespace RCM.Domain.Events.FornecedorEvents
{
    public abstract class FornecedorEvent : DomainEvent
    {
        public Fornecedor Fornecedor { get; set; }

        public FornecedorEvent(Fornecedor fornecedor)
        {
            Fornecedor = fornecedor;
        }

        public override void Normalize()
        {
            AggregateId = Fornecedor.Id;

            Args.Add(nameof(Fornecedor.Nome), Fornecedor.Nome);
            Args.Add(nameof(Fornecedor.Tipo), Fornecedor.Tipo);
            Args.Add(nameof(Fornecedor.Descricao), Fornecedor.Descricao);
        }
    }
}
