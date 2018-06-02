using RCM.Domain.Core.Events;

namespace RCM.Domain.EventHandlers
{
    public abstract class DomainEventHandler<T> where T : DomainEvent
    {
    }
}
