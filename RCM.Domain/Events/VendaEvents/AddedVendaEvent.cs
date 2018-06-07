using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class AddedVendaEvent : VendaEvent
    {
        public Cliente Cliente { get; private set; }

        public AddedVendaEvent(Venda venda, Cliente cliente) : base(venda)
        {
            Cliente = cliente;
        }

        public override void Normalize()
        {
            base.Normalize();
            Args.Add("Nome do Cliente", Cliente.Nome);
        }
    }
}
