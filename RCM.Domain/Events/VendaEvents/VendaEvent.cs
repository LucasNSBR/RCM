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
        }

        public override void Normalize()
        {
            AggregateId = Venda.Id;

            Args.Add(nameof(Venda.Status), Venda.Status);
            Args.Add(nameof(Venda.DataVenda), Venda.DataVenda);
            Args.Add(nameof(Venda.ClienteId), Venda.ClienteId);
            Args.Add(nameof(Venda.Detalhes), Venda.Detalhes);
            Args.Add(nameof(Venda.QuantidadeProdutos), Venda.QuantidadeProdutos);
            Args.Add(nameof(Venda.TotalVenda), Venda.TotalVenda);
        }
    }
}
