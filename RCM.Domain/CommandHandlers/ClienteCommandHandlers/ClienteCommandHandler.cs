using MediatR;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.ClienteEvents;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.ClienteCommandHandlers
{
    public class ClienteCommandHandler : CommandHandler<Cliente>,
                                         IRequestHandler<AddClienteCommand, CommandResult>,
                                         IRequestHandler<UpdateClienteCommand, CommandResult>,
                                         IRequestHandler<RemoveClienteCommand, CommandResult>
    {
        public ClienteCommandHandler(IMediatorHandler mediator, IClienteRepository clienteRepository, IUnitOfWork unitOfWork) : 
                                                                                                        base(mediator, clienteRepository, unitOfWork)
        {
        }

        public Task<CommandResult> Handle(AddClienteCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Cliente cliente = new Cliente(command.Nome, command.Descricao);
            _baseRepository.Add(cliente);

            if (Commit())
                _mediator.Publish(new AddedClienteEvent());
            
            return Response();
        }

        public Task<CommandResult> Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Cliente cliente = new Cliente(command.Id, command.Nome, command.Descricao);
            _baseRepository.Update(cliente);

            if (Commit())
                _mediator.Publish(new UpdatedClienteEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveClienteCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Cliente cliente = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(cliente);

            if (Commit())
                _mediator.Publish(new RemovedClienteEvent());

            return Response();
        }
    }
}
