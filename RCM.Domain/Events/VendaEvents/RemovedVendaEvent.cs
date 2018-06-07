using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class RemovedVendaEvent : VendaEvent
    {
        public RemovedVendaEvent(Venda venda) : base(venda)
        {
        }

        public override void Normalize()
        {
            Args.Add(nameof(Venda.Id), Venda.Id);
        }
    }
}
