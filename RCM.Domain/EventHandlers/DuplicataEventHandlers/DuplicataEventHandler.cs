using MediatR;
using RCM.Domain.Events.DuplicataEvents;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.DuplicataEventHandlers
{
    public class DuplicataEventHandler : DomainEventHandler<DuplicataEvent>,
                                         INotificationHandler<AddedDuplicataEvent>,
                                         INotificationHandler<UpdatedDuplicataEvent>,
                                         INotificationHandler<RemovedDuplicataEvent>
    {
        public Task Handle(AddedDuplicataEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(UpdatedDuplicataEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(RemovedDuplicataEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
