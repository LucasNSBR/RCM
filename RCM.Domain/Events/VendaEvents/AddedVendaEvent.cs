using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class AddedVendaEvent : VendaEvent
    {
        public AddedVendaEvent(Venda venda) : base(venda)
        {
        }
    }
}
