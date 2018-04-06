using System.Threading.Tasks;
using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.BancoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class BancoApplicationService : BaseApplicationService<Banco, BancoViewModel>, IBancoApplicationService
    {
        public BancoApplicationService(IBancoRepository bancoRepository, IMapper mapper, IMediatorHandler mediator) : base(bancoRepository, mapper, mediator)
        {
        }

        public override Task<RequestResponse> Add(BancoViewModel viewModel)
        {
            return _mediator.SendRequest(new AddBancoCommand(viewModel.Nome, viewModel.CodigoCompensacao));
        }

        public override Task<RequestResponse> Update(BancoViewModel viewModel)
        {
            return _mediator.SendRequest(new UpdateBancoCommand(viewModel.Id, viewModel.Nome, viewModel.CodigoCompensacao));
        }

        public override Task<RequestResponse> Remove(BancoViewModel viewModel)
        {
            return _mediator.SendRequest(new RemoveBancoCommand(viewModel.Id));
        }
    }
}
