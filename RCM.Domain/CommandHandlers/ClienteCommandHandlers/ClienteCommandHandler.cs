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

            Cliente cliente = new Cliente(command.Nome, command.Descricao);
            _baseRepository.Add(cliente);

            if (Commit())
                _mediator.Publish(new AddedClienteEvent());
            
            return Task.CompletedTask;
        }

        public Task Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Cliente cliente = new Cliente(command.Id, command.Nome, command.Descricao);
            _baseRepository.Update(cliente);

            if (Commit())
                _mediator.Publish(new UpdatedClienteEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveClienteCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Cliente cliente = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(cliente);

            if (Commit())
                _mediator.Publish(new RemovedClienteEvent());

            return Task.CompletedTask;
        }
    }
}
