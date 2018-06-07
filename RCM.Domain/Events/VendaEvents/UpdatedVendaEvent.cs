using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.VendaModels;

namespace RCM.Domain.Events.VendaEvents
{
    public class UpdatedVendaEvent : VendaEvent
    {
        public Cliente Cliente { get; private set; }

        public UpdatedVendaEvent(Venda venda, Cliente cliente) : base(venda)
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
