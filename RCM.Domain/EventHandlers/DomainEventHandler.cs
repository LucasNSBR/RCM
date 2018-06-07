using RCM.Domain.Core.Events;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers
{
    public abstract class DomainEventHandler<T> where T : DomainEvent
    {
        public Task Response()
        {
            return Task.CompletedTask;
        }
    }
}
