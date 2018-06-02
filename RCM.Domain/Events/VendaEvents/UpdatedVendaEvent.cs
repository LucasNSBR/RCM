using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class UpdatedVendaEvent : VendaEvent
    {
        public UpdatedVendaEvent(Venda venda) : base(venda)
        {
        }
    }
}
