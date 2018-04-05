using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class ClienteApplicationService : BaseApplicationService<Cliente, ClienteViewModel>, IClienteApplicationService
    {
        public ClienteApplicationService(IClienteRepository clienteRepository, IMapper mapper, IMediatorHandler mediator) : base(clienteRepository, mapper, mediator)
        {
        }

        public override void Add(ClienteViewModel viewModel)
        {
            _mediator.SendCommand(new AddClienteCommand(viewModel.Nome, viewModel.Descricao));
        }

        public override void Update(ClienteViewModel viewModel)
        {
            _mediator.SendCommand(new UpdateClienteCommand(viewModel.Id, viewModel.Nome, viewModel.Descricao));
        }

        public override void Remove(ClienteViewModel viewModel)
        {
            _mediator.SendCommand(new RemoveClienteCommand(viewModel.Id));
        }
    }
}
