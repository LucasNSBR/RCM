using AutoMapper;
using AutoMapper.QueryableExtensions;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.OrdemServicoCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using System.Linq;

namespace RCM.Application.ApplicationServices
{
    public class OrdemServicoApplicationService : BaseApplicationService<OrdemServico, OrdemServicoViewModel>, IOrdemServicoApplicationService
    {
        public OrdemServicoApplicationService(IOrdemServicoRepository baseRepository, IMapper mapper, IMediatorHandler mediator) : base(baseRepository, mapper, mediator)
        {
        }

        public override async void Add(OrdemServicoViewModel viewModel)
        {
            var produtos = viewModel.Produtos.AsQueryable().ProjectTo<Produto>();
            var result = await _mediator.SendRequest(new AddOrdemServicoCommand(viewModel.ClienteId, produtos.ToList()));
        }
    }
}
