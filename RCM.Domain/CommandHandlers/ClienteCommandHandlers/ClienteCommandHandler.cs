using MediatR;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.ClienteEvents;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.ClienteCommandHandlers
{
    public class ClienteCommandHandler : CommandHandler<Cliente>,
                                         INotificationHandler<AddClienteCommand>,
                                         INotificationHandler<UpdateClienteCommand>,
                                         INotificationHandler<RemoveClienteCommand>
    {
        public ClienteCommandHandler(IMediatorHandler mediator, IClienteRepository clienteRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                        base(mediator, clienteRepository, unitOfWork, domainNotificationHandler)
        {
        }

        public Task Handle(AddClienteCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Add(command.Cliente);

            if (Commit())
                _mediator.Publish(new AddedClienteEvent());
            
            return Task.CompletedTask;
        }

        public Task Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Update(command.Cliente);

            if (Commit())
                _mediator.Publish(new UpdatedClienteEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveClienteCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            _baseRepository.Remove(command.Cliente);

            if (Commit())
                _mediator.Publish(new RemovedClienteEvent());

            return Task.CompletedTask;
        }
    }
}
