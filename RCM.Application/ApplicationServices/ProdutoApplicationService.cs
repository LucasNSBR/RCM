using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.ProdutoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class ProdutoApplicationService : BaseApplicationService<Produto, ProdutoViewModel>, IProdutoApplicationService
    {
        public ProdutoApplicationService(IProdutoRepository produtoRepository, IMapper mapper, IMediatorHandler mediator) : base(produtoRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(ProdutoViewModel viewModel)
        {
            return _mediator.SendCommand(new AddProdutoCommand(viewModel.Nome, viewModel.Aplicacao, viewModel.Quantidade, viewModel.PrecoVenda, viewModel.MarcaId));
        }

        public override Task<CommandResult> Update(ProdutoViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateProdutoCommand(viewModel.Id, viewModel.Nome, viewModel.Aplicacao, viewModel.Quantidade, viewModel.PrecoVenda, viewModel.MarcaId));
        }

        public override Task<CommandResult> Remove(ProdutoViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveProdutoCommand(viewModel.Id));
        }
    }
}

