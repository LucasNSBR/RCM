using MediatR;
using RCM.Domain.Events.FornecedorEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.FornecedorEventHandlers
{
    public class FornecedorEventHandler : DomainEventHandler<FornecedorEvent>,
                                          INotificationHandler<AddedFornecedorEvent>,
                                          INotificationHandler<UpdatedFornecedorEvent>,
                                          INotificationHandler<RemovedFornecedorEvent>
    {
        public Task Handle(AddedFornecedorEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(UpdatedFornecedorEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RemovedFornecedorEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }
    }
}
