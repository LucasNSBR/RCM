using MediatR;
using RCM.Domain.Commands.VendaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.VendaEvents;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.VendaModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.VendaCommandHandlers
{
    public class VendaCommandHandler : CommandHandler<Venda>,
                                       IRequestHandler<AddVendaCommand, CommandResult>,
                                       IRequestHandler<UpdateVendaCommand, CommandResult>,
                                       IRequestHandler<RemoveVendaCommand, CommandResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IClienteRepository _clienteRepository;

        public VendaCommandHandler(IVendaRepository vendaRepository, IClienteRepository clienteRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : base(mediator, unitOfWork)
        {
            _vendaRepository = vendaRepository;
            _clienteRepository = clienteRepository;
        }

        public Task<CommandResult> Handle(AddVendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cliente cliente = _clienteRepository.GetById(command.ClienteId);
            Venda venda = new Venda(command.DataVenda, command.Detalhes, cliente);

            _vendaRepository.Add(venda);

            if (Commit())
                _mediator.Publish(new AddedVendaEvent());

            return Response();
        }

        public Task<CommandResult> Handle(UpdateVendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cliente cliente = _clienteRepository.GetById(command.Id);
            Venda venda = new Venda(command.Id, command.DataVenda, command.Detalhes, cliente);

            _vendaRepository.Update(venda);

            if (Commit())
                _mediator.Publish(new UpdatedVendaEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveVendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Venda venda = _vendaRepository.GetById(command.Id);
            _vendaRepository.Remove(venda);

            if (Commit())
                _mediator.Publish(new RemovedVendaEvent());

            return Response();
        }
    }
}
