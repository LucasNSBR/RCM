using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.ChequeEvents;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

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

        public Task Handle(AddChequeCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Cheque);

            if (Commit())
                _mediator.Publish(new AddedChequeEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateChequeCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Cheque);

            if (Commit())
                _mediator.Publish(new UpdatedChequeEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveChequeCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Cheque);
            if (Commit())
                _mediator.Publish(new RemovedChequeEvent());

            return Task.CompletedTask;
        }
    }
}
