using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.BancoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class BancoApplicationService : BaseApplicationService<Banco, BancoViewModel>, IBancoApplicationService
    {
        public BancoApplicationService(IBancoRepository bancoRepository, IMapper mapper, IMediatorHandler mediator) : base(bancoRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(BancoViewModel viewModel)
        {
            return _mediator.SendCommand(new AddBancoCommand(viewModel.Nome, viewModel.CodigoCompensacao));
        }

        public override Task<CommandResult> Update(BancoViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateBancoCommand(viewModel.Id, viewModel.Nome, viewModel.CodigoCompensacao));
        }

        public override Task<CommandResult> Remove(BancoViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveBancoCommand(viewModel.Id));
        }
    }
}
