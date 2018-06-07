using MediatR;
using RCM.Domain.Events.DuplicataEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.DuplicataEventHandlers
{
    public class DuplicataEventHandler : DomainEventHandler<DuplicataEvent>,
                                         INotificationHandler<AddedDuplicataEvent>,
                                         INotificationHandler<UpdatedDuplicataEvent>,
                                         INotificationHandler<RemovedDuplicataEvent>,
                                         INotificationHandler<PaidDuplicataEvent>,
                                         INotificationHandler<RevertedPaymentDuplicataEvent>
    {
        public Task Handle(AddedDuplicataEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(UpdatedDuplicataEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RemovedDuplicataEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(PaidDuplicataEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RevertedPaymentDuplicataEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }
    }
}
