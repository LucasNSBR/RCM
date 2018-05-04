using System.Threading.Tasks;
using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.VendaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.VendaModels;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class VendaApplicationService : BaseApplicationService<Venda, VendaViewModel>, IVendaApplicationService
    {
        public VendaApplicationService(IVendaRepository vendaRepository, IMapper mapper, IMediatorHandler mediator) : base(vendaRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(VendaViewModel viewModel)
        {
            return _mediator.SendCommand(new AddVendaCommand(viewModel.DataVenda, viewModel.Detalhes, viewModel.ClienteId));
        }

        public override Task<CommandResult> Update(VendaViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateVendaCommand(viewModel.Id, viewModel.DataVenda, viewModel.Detalhes, viewModel.ClienteId));
        }

        public override Task<CommandResult> Remove(VendaViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveVendaCommand(viewModel.Id));
        }
    }
}
