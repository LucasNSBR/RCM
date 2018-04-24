using MediatR;
using RCM.Domain.Commands.OrdemServicoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.Errors;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.OrdemServico;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.OrdemServicoCommandHandlers
{
    public class OrdemServicoCommandHandler : CommandHandler<OrdemServico>,
                                              IRequestHandler<AddOrdemServicoCommand, CommandResult>,
                                              IRequestHandler<UpdateOrdemServicoCommand, CommandResult>,
                                              IRequestHandler<RemoveOrdemServicoCommand, CommandResult>
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        private readonly IClienteRepository _clienteRepository;

        public OrdemServicoCommandHandler(IOrdemServicoRepository ordemServicoRepository, IClienteRepository clienteRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) :
                                                                                                                                                    base(mediator, unitOfWork)
        {
            _ordemServicoRepository = ordemServicoRepository;
            _clienteRepository = clienteRepository;
        }

        public Task<CommandResult> Handle(AddOrdemServicoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cliente cliente = _clienteRepository.GetById(command.ClienteId);
            if (cliente == null)
            {
                NotifyCommandError("Cliente não encontrado", "Erro de repositório");
                return Response();
            }

            OrdemServico ordemServico = new OrdemServico(cliente, command.Produtos);
            _ordemServicoRepository.Add(ordemServico);

            if (Commit())
                _mediator.Publish(new AddedOrdemServicoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(UpdateOrdemServicoCommand command, CancellationToken cancellationToken)
        {
            var cliente = _clienteRepository.GetById(command.ClienteId);

            if (cliente == null)
            {
                NotifyCommandError("Cliente não encontrado", "Erro de repositório");
                return Task.FromResult(_commandResponse);
            }

            var ordemServico = new OrdemServico(cliente, command.Produtos);
            _ordemServicoRepository.Update(ordemServico);

            if (Commit())
                _mediator.Publish(new UpdatedOrdemServicoEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveOrdemServicoCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            OrdemServico ordemServico = _ordemServicoRepository.GetById(command.Id);

            _ordemServicoRepository.Remove(ordemServico);

            if (Commit())
                _mediator.Publish(new RemovedOrdemServicoEvent());

            return Response();
        }
    }
}
