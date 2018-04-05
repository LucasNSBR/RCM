using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.BancoCommands;
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

        public override void Add(BancoViewModel viewModel)
        {
            _mediator.SendCommand(new AddBancoCommand(viewModel.Nome, viewModel.CodigoCompensacao));
        }

        public override void Update(BancoViewModel viewModel)
        {
            _mediator.SendCommand(new UpdateBancoCommand(viewModel.Id, viewModel.Nome, viewModel.CodigoCompensacao));
        }

        public override void Remove(BancoViewModel viewModel)
        {
            _mediator.SendCommand(new RemoveBancoCommand(viewModel.Id));
        }
    }
}
