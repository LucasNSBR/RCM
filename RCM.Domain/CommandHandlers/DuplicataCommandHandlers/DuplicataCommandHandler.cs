using MediatR;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.DuplicataEvents;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.DuplicataCommandHandlers
{
    public class DuplicataCommandHandler : CommandHandler<Duplicata>,
                                           INotificationHandler<AddDuplicataCommand>,
                                           INotificationHandler<UpdateDuplicataCommand>,
                                           INotificationHandler<RemoveDuplicataCommand>,
                                           INotificationHandler<PagarDuplicataCommand>
    {
        public DuplicataCommandHandler(IMediatorHandler mediator, IDuplicataRepository duplicataRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                base(mediator, duplicataRepository, unitOfWork, domainNotificationHandler)
        {
        }

        public Task Handle(AddDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Add(command.Duplicata);

            if (Commit())
                _mediator.Publish(new AddedDuplicataEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Update(command.Duplicata);

            if (Commit())
                _mediator.Publish(new UpdatedDuplicataEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveDuplicataCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Remove(command.Duplicata);

            if (Commit())
                _mediator.Publish(new RemovedDuplicataEvent());

            return Task.CompletedTask;
        }

        public Task Handle(PagarDuplicataCommand command, CancellationToken cancellationToken)
        {
            var valorPago = command.ValorPago;
            var dataPagamento = command.DataPagamento;

            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            command.Duplicata.Pagar(dataPagamento, valorPago);
            _baseRepository.Update(command.Duplicata);

            if (Commit())
                _mediator.Publish(new UpdatedDuplicataEvent());

            return Task.CompletedTask;
        }
    }
}
