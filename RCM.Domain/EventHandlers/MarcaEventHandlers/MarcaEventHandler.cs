using MediatR;
using RCM.Domain.Events.MarcaEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.MarcaEventHandlers
{
    public class MarcaEventHandler : DomainEventHandler<MarcaEvent>,
                                     INotificationHandler<AddedMarcaEvent>,
                                     INotificationHandler<UpdatedMarcaEvent>,
                                     INotificationHandler<RemovedMarcaEvent>
    {
        public Task Handle(AddedMarcaEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(UpdatedMarcaEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RemovedMarcaEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }
    }
}
