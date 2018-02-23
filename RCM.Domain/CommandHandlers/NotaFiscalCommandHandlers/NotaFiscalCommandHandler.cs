using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.NotaFiscalCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.NotaFiscalEvents;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

namespace RCM.Domain.CommandHandlers.NotaFiscalCommandHandlers
{
    public class NotaFiscalCommandHandler : CommandHandler<NotaFiscal>,
                                            INotificationHandler<AddNotaFiscalCommand>,
                                            INotificationHandler<UpdateNotaFiscalCommand>,
                                            INotificationHandler<RemoveNotaFiscalCommand>
    {

        public NotaFiscalCommandHandler(IMediatorHandler mediator, INotaFiscalRepository notaFiscalRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                    base(mediator, notaFiscalRepository, unitOfWork, domainNotificationHandler)
        {
        }

        public Task Handle(AddNotaFiscalCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.NotaFiscal);

            if (Commit())
                _mediator.Publish(new AddedNotaFiscalEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateNotaFiscalCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Update(notification.NotaFiscal);

            if (Commit())
                _mediator.Publish(new AddedNotaFiscalEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveNotaFiscalCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Remove(notification.NotaFiscal);

            if (Commit())
                _mediator.Publish(new AddedNotaFiscalEvent());

            return Task.CompletedTask;
        }
    }
}
