using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Events.ClienteEvents
{
    public class AddedClienteEvent : ClienteEvent
    {
        public AddedClienteEvent(Cliente cliente) : base(cliente)
        {
        }
    }
}
