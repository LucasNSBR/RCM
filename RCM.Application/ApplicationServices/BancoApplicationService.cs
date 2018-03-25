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
            _mediator.SendCommand(new AddBancoCommand(ProjectToModel(viewModel)));
        }

        public override void Update(BancoViewModel viewModel)
        {
            _mediator.SendCommand(new UpdateBancoCommand(ProjectToModel(viewModel)));
        }

        public override void Remove(BancoViewModel viewModel)
        {
            _mediator.SendCommand(new RemoveBancoCommand(ProjectToModel(viewModel)));
        }
    }
}
