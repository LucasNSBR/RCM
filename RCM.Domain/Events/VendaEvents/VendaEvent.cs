using RCM.Domain.Core.Events;
using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public abstract class VendaEvent : DomainEvent
    {
        public Venda Venda { get; set; }

        public VendaEvent(Venda venda)
        {
            Venda = venda;
            AggregateId = Venda.Id;
        }

        public override void Normalize()
        {
            Args.Add(nameof(Venda.Status), Venda.Status);
            Args.Add(nameof(Venda.DataVenda), Venda.DataVenda);
            Args.Add(nameof(Venda.ClienteId), Venda.ClienteId);
            Args.Add(nameof(Venda.Detalhes), Venda.Detalhes);
            Args.Add(nameof(Venda.QuantidadeItens), Venda.QuantidadeItens);
            Args.Add(nameof(Venda.TotalVenda), Venda.TotalVenda);
        }
    }
}
