using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Events.ChequeEvents;

namespace RCM.Domain.EventHandlers.ChequeEventHandlers
{
    public class ChequeEventHandler : EventHandler,
                                      INotificationHandler<AddedChequeEvent>,
                                      INotificationHandler<UpdatedChequeEvent>,
                                      INotificationHandler<RemovedChequeEvent>
    {
        public Task Handle(AddedChequeEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdatedChequeEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(RemovedChequeEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
