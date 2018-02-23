using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.BancoCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.BancoEvents;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

namespace RCM.Domain.CommandHandlers.BancoCommandHandlers
{
    public class BancoCommandHandler : CommandHandler<Banco>,
                                       INotificationHandler<AddBancoCommand>,
                                       INotificationHandler<UpdateBancoCommand>,
                                       INotificationHandler<RemoveBancoCommand>
    {
        public BancoCommandHandler(IMediatorHandler mediator, IBancoRepository baseRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                base(mediator, baseRepository, unitOfWork, domainNotificationHandler)
        {
        }

        public Task Handle(AddBancoCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Banco);

            if (Commit())
                _mediator.Publish(new AddedBancoEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateBancoCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Banco);

            if (Commit())
                _mediator.Publish(new UpdatedBancoEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveBancoCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Banco);

            if (Commit())
                _mediator.Publish(new RemovedBancoEvent());

            return Task.CompletedTask;
        }
    }
}
