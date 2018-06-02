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
            throw new System.NotImplementedException();
        }

        public Task Handle(UpdatedFornecedorEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(RemovedFornecedorEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
