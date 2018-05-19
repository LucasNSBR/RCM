using AutoMapper;
using AutoMapper.QueryableExtensions;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.OrdemServicoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class OrdemServicoApplicationService : BaseApplicationService<OrdemServico, OrdemServicoViewModel>, IOrdemServicoApplicationService
    {
        public OrdemServicoApplicationService(IOrdemServicoRepository ordemServicoRepository, IMapper mapper, IMediatorHandler mediator) : base(ordemServicoRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(OrdemServicoViewModel viewModel)
        {
            var produtos = viewModel.Produtos.AsQueryable().ProjectTo<Produto>();
            return _mediator.SendCommand(new AddOrdemServicoCommand(viewModel.ClienteId, produtos.ToList()));
        }

        public override Task<CommandResult> Remove(OrdemServicoViewModel viewModel)
        {
            var produtos = viewModel.Produtos.AsQueryable().ProjectTo<Produto>();
            return _mediator.SendCommand(new UpdateOrdemServicoCommand(viewModel.Id, viewModel.ClienteId, produtos.ToList()));
        }

        public override Task<CommandResult> Update(OrdemServicoViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveOrdemServicoCommand(viewModel.Id));
        }
    }
}
