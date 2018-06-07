using MediatR;
using RCM.Domain.Events.VendaEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.VendaEventHandlers
{
    public class VendaEventHandler : DomainEventHandler<VendaEvent>,
                                     INotificationHandler<AddedVendaEvent>,
                                     INotificationHandler<UpdatedVendaEvent>,
                                     INotificationHandler<RemovedVendaEvent>,
                                     INotificationHandler<AddedVendaProdutoEvent>,
                                     INotificationHandler<RemovedVendaProdutoEvent>,
                                     INotificationHandler<CheckedOutVendaEvent>,
                                     INotificationHandler<PaidInstallmentVendaEvent>
    {
        public Task Handle(AddedVendaEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(UpdatedVendaEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RemovedVendaEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(AddedVendaProdutoEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(RemovedVendaProdutoEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(CheckedOutVendaEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(PaidInstallmentVendaEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }
    }
}
