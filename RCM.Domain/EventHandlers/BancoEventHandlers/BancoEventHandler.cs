using MediatR;
using RCM.Domain.Events.BancoEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.BancoEventHandlers
{
    public class BancoEventHandler : DomainEventHandler<BancoEvent>,
                                     INotificationHandler<AddedBancoEvent>,
                                     INotificationHandler<UpdatedBancoEvent>,
                                     INotificationHandler<RemovedBancoEvent>
    {
        public Task Handle(AddedBancoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdatedBancoEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(RemovedBancoEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
