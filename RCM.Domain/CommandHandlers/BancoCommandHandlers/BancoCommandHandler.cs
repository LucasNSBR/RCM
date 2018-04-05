using MediatR;
using RCM.Domain.Commands.BancoCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.BancoEvents;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

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

        public Task Handle(AddBancoCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Banco banco = new Banco(command.Nome, command.CodigoCompensacao);
            _baseRepository.Add(banco);

            if (Commit())
                _mediator.Publish(new AddedBancoEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateBancoCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Banco banco = new Banco(command.Id, command.Nome, command.CodigoCompensacao);

            _baseRepository.Update(banco);

            if (Commit())
                _mediator.Publish(new UpdatedBancoEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveBancoCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Banco banco = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(banco);

            if (Commit())
                _mediator.Publish(new RemovedBancoEvent());

            return Task.CompletedTask;
        }
    }
}
