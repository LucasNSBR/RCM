using MediatR;
using RCM.Domain.Events.EmpresaEvents;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers.EmpresaEventHandlers
{
    public class EmpresaEventHandler : DomainEventHandler<EmpresaEvent>,
                                       INotificationHandler<UpdatedEmpresaEvent>,
                                       INotificationHandler<AttachedEmpresaLogoEvent>
    {
        public Task Handle(UpdatedEmpresaEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }

        public Task Handle(AttachedEmpresaLogoEvent notification, CancellationToken cancellationToken)
        {
            return Response();
        }
    }
}
