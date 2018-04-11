using MediatR;
using RCM.Domain.Commands.NotaFiscalCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.NotaFiscalEvents;
using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.NotaFiscalCommandHandlers
{
    public class NotaFiscalCommandHandler : CommandHandler<NotaFiscal>,
                                            IRequestHandler<AddNotaFiscalCommand, CommandResult>,
                                            IRequestHandler<UpdateNotaFiscalCommand, CommandResult>,
                                            IRequestHandler<RemoveNotaFiscalCommand, CommandResult>
    {
        public NotaFiscalCommandHandler(IMediatorHandler mediator, INotaFiscalRepository notaFiscalRepository, IUnitOfWork unitOfWork) : 
                                                                                                                base(mediator, notaFiscalRepository, unitOfWork)
        {
        }

        public Task<CommandResult> Handle(AddNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            NotaFiscal notaFiscal = new NotaFiscal(command.NumeroDocumento, command.DataEmissao, command.Valor);
            _baseRepository.Add(notaFiscal);

            if (Commit())
                _mediator.Publish(new AddedNotaFiscalEvent());

            return Response();
        }

        public Task<CommandResult> Handle(UpdateNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            NotaFiscal notaFiscal = new NotaFiscal(command.Id, command.NumeroDocumento, command.DataEmissao, command.Valor);
            _baseRepository.Update(notaFiscal);

            if (Commit())
                _mediator.Publish(new UpdatedNotaFiscalEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            NotaFiscal notaFiscal = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(notaFiscal);

            if (Commit())
                _mediator.Publish(new RemovedNotaFiscalEvent());

            return Response();
        }
    }
}
