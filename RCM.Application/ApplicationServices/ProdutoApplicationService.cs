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

        public override Task<RequestResponse> Add(ProdutoViewModel viewModel)
        {
            return _mediator.SendRequest(new AddProdutoCommand(viewModel.Nome, viewModel.Aplicacao, viewModel.Quantidade, viewModel.PrecoVenda));
        }

        public override Task<RequestResponse> Update(ProdutoViewModel viewModel)
        {
            return _mediator.SendRequest(new UpdateProdutoCommand(viewModel.Id, viewModel.Nome, viewModel.Aplicacao, viewModel.Quantidade, viewModel.PrecoVenda));
        }

        public override Task<RequestResponse> Remove(ProdutoViewModel viewModel)
        {
            return _mediator.SendRequest(new RemoveProdutoCommand(viewModel.Id));
        }
    }
}

