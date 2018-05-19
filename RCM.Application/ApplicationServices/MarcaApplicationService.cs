using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.MarcaCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class MarcaApplicationService : BaseApplicationService<Marca, MarcaViewModel>, IMarcaApplicationService
    {
        public MarcaApplicationService(IMarcaRepository marcaRepository, IMapper mapper, IMediatorHandler mediator) : base(marcaRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(MarcaViewModel viewModel)
        {
            return _mediator.SendCommand(new AddMarcaCommand(viewModel.Nome, viewModel.Observacao));
        }

        public override Task<CommandResult> Update(MarcaViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateMarcaCommand(viewModel.Id, viewModel.Nome, viewModel.Observacao));
        }

        public override Task<CommandResult> Remove(MarcaViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveMarcaCommand(viewModel.Id));
        }
    }
}
