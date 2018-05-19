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
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalCommandHandler(INotaFiscalRepository notaFiscalRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : 
                                                                                                                base(mediator, unitOfWork)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        public Task<CommandResult> Handle(AddNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            NotaFiscal notaFiscal = new NotaFiscal(command.NumeroDocumento, command.DataEmissao, command.Valor);
            _notaFiscalRepository.Add(notaFiscal);

            if (Commit())
                _mediator.Publish(new AddedNotaFiscalEvent());

            return Response();
        }

        public Task<CommandResult> Handle(UpdateNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            NotaFiscal notaFiscal = new NotaFiscal(command.Id, command.NumeroDocumento, command.DataEmissao, command.Valor);
            _notaFiscalRepository.Update(notaFiscal);

            if (Commit())
                _mediator.Publish(new UpdatedNotaFiscalEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            NotaFiscal notaFiscal = _notaFiscalRepository.GetById(command.Id);
            _notaFiscalRepository.Remove(notaFiscal);

            if (Commit())
                _mediator.Publish(new RemovedNotaFiscalEvent());

            return Response();
        }
    }
}
