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

            NotaFiscal notaFiscal = new NotaFiscal(command.NumeroDocumento, command.DataEmissao, command.Valor);
            _baseRepository.Add(notaFiscal);

            if (Commit())
                _mediator.Publish(new AddedNotaFiscalEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            NotaFiscal notaFiscal = new NotaFiscal(command.Id, command.NumeroDocumento, command.DataEmissao, command.Valor);
            _baseRepository.Update(notaFiscal);

            if (Commit())
                _mediator.Publish(new UpdatedNotaFiscalEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            NotaFiscal notaFiscal = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(notaFiscal);

            if (Commit())
                _mediator.Publish(new RemovedNotaFiscalEvent());

            return Task.CompletedTask;
        }
    }
}
