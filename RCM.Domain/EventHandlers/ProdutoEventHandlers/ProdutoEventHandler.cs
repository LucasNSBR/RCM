using MediatR;
using RCM.Domain.Events.ProdutoEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.ProdutoEventHandlers
{
    public class ProdutoEventHandler : DomainEventHandler<ProdutoEvent>,
                                       INotificationHandler<AddedProdutoEvent>,
                                       INotificationHandler<UpdatedProdutoEvent>,
                                       INotificationHandler<RemovedProdutoEvent>
    {
        public Task Handle(AddedProdutoEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(UpdatedProdutoEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(RemovedProdutoEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
