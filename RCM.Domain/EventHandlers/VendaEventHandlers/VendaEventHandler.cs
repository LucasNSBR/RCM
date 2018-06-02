using MediatR;
using RCM.Domain.Events.VendaEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.VendaEventHandlers
{
    public class VendaEventHandler : DomainEventHandler<VendaEvent>,
                                     INotificationHandler<AddedVendaEvent>,
                                     INotificationHandler<UpdatedVendaEvent>,
                                     INotificationHandler<RemovedVendaEvent>
    {
        public Task Handle(AddedVendaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdatedVendaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(RemovedVendaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
