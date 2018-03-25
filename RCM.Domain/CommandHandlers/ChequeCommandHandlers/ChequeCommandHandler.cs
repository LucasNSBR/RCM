using MediatR;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.ChequeEvents;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.ChequeCommandHandlers
{
    public class ChequeCommandHandler : CommandHandler<Cheque>,
                                        INotificationHandler<AddChequeCommand>,
                                        INotificationHandler<UpdateChequeCommand>,
                                        INotificationHandler<RemoveChequeCommand>
    {
        public ChequeCommandHandler(IMediatorHandler mediator, IChequeRepository chequeRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                    base(mediator, chequeRepository, unitOfWork, domainNotificationHandler)
        {
        }

        public Task Handle(AddChequeCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Add(command.Cheque);

            if (Commit())
                _mediator.Publish(new AddedChequeEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateChequeCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Update(command.Cheque);

            if (Commit())
                _mediator.Publish(new UpdatedChequeEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveChequeCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Remove(command.Cheque);

            if (Commit())
                _mediator.Publish(new RemovedChequeEvent());

            return Task.CompletedTask;
        }
    }
}
