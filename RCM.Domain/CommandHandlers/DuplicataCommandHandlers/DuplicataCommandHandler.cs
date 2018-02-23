using MediatR;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.DuplicataEvents;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.DuplicataCommandHandlers
{
    public class DuplicataCommandHandler : CommandHandler<Duplicata>,
                                           INotificationHandler<AddDuplicataCommand>,
                                           INotificationHandler<UpdateDuplicataCommand>,
                                           INotificationHandler<RemoveDuplicataCommand>
    {
        public DuplicataCommandHandler(IMediatorHandler mediator, IDuplicataRepository duplicataRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                base(mediator, duplicataRepository, unitOfWork, domainNotificationHandler)
        {
        }

        public Task Handle(AddDuplicataCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Duplicata);

            if (Commit())
                _mediator.Publish(new AddedDuplicataEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateDuplicataCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Update(notification.Duplicata);

            if (Commit())
                _mediator.Publish(new UpdatedDuplicataEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveDuplicataCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Remove(notification.Duplicata);

            if (Commit())
                _mediator.Publish(new RemovedDuplicataEvent());

            return Task.CompletedTask;
        }
    }
}
