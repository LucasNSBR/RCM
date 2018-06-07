using MediatR;
using RCM.Domain.Events.ChequeEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.ChequeEventHandlers
{
    public class ChequeEventHandler : DomainEventHandler<ChequeEvent>,
                                      INotificationHandler<AddedChequeEvent>,
                                      INotificationHandler<UpdatedChequeEvent>,
                                      INotificationHandler<RemovedChequeEvent>,
                                      INotificationHandler<BlockedChequeEvent>,
                                      INotificationHandler<PaidChequeEvent>,
                                      INotificationHandler<PassedChequeEvent>,
                                      INotificationHandler<RefundedChequeEvent>,
                                      INotificationHandler<CanceledChequeEvent>
    {
        public Task Handle(AddedChequeEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(UpdatedChequeEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RemovedChequeEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(BlockedChequeEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(PaidChequeEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(PassedChequeEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RefundedChequeEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(CanceledChequeEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }
    }
}
