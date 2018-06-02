using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Events.ClienteEvents
{
    public class UpdatedClienteEvent : ClienteEvent
    {
        public UpdatedClienteEvent(Cliente cliente) : base(cliente)
        {
        }
    }
}
