using MediatR;
using RCM.Domain.Events.ProdutoEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.ProdutoEventHandlers
{
    public class ProdutoEventHandler : DomainEventHandler<ProdutoEvent>,
                                       INotificationHandler<AddedProdutoEvent>,
                                       INotificationHandler<UpdatedProdutoEvent>,
                                       INotificationHandler<RemovedProdutoEvent>,
                                       INotificationHandler<AttachedProdutoAplicacaoEvent>,
                                       INotificationHandler<RemovedProdutoAplicacaoEvent>,
                                       INotificationHandler<AttachedProdutoFornecedorEvent>,
                                       INotificationHandler<RemovedProdutoFornecedorEvent>
    {
        public Task Handle(AddedProdutoEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(UpdatedProdutoEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RemovedProdutoEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(AttachedProdutoAplicacaoEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RemovedProdutoAplicacaoEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(AttachedProdutoFornecedorEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RemovedProdutoFornecedorEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }
    }
}
