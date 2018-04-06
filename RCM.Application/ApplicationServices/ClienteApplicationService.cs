using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class ClienteApplicationService : BaseApplicationService<Cliente, ClienteViewModel>, IClienteApplicationService
    {
        public ClienteApplicationService(IClienteRepository clienteRepository, IMapper mapper, IMediatorHandler mediator) : base(clienteRepository, mapper, mediator)
        {
        }

        public override Task<RequestResponse> Add(ClienteViewModel viewModel)
        {
            return _mediator.SendRequest(new AddClienteCommand(viewModel.Nome, viewModel.Descricao));
        }

        public override Task<RequestResponse> Update(ClienteViewModel viewModel)
        {
            return _mediator.SendRequest(new UpdateClienteCommand(viewModel.Id, viewModel.Nome, viewModel.Descricao));
        }

        public override Task<RequestResponse> Remove(ClienteViewModel viewModel)
        {
            return _mediator.SendRequest(new RemoveClienteCommand(viewModel.Id));
        }
    }
}
