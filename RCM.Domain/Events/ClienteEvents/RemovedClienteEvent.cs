using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Events.ClienteEvents
{
    public class RemovedClienteEvent : ClienteEvent
    {
        public RemovedClienteEvent(Cliente cliente) : base(cliente)
        {
        }
    }
}
