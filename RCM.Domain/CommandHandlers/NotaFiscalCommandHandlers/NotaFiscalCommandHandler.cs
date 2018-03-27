using MediatR;
using RCM.Domain.Commands.NotaFiscalCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.NotaFiscalEvents;
using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

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

        public Task Handle(AddNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Add(command.NotaFiscal);

            if (Commit())
                _mediator.Publish(new AddedNotaFiscalEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Update(command.NotaFiscal);

            if (Commit())
                _mediator.Publish(new UpdatedNotaFiscalEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Remove(command.NotaFiscal);

            if (Commit())
                _mediator.Publish(new RemovedNotaFiscalEvent());

            return Task.CompletedTask;
        }
    }
}
