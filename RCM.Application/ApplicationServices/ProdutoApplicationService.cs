using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.ProdutoCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class ProdutoApplicationService : BaseApplicationService<Produto, ProdutoViewModel>, IProdutoApplicationService
    {
        public ProdutoApplicationService(IProdutoRepository produtoRepository, IMapper mapper, IMediatorHandler mediator) : base(produtoRepository, mapper, mediator)
        {
        }

        public override void Add(ProdutoViewModel viewModel)
        {
            _mediator.SendCommand(new AddProdutoCommand(viewModel.Nome, viewModel.Aplicacao, viewModel.Quantidade, viewModel.PrecoVenda));
        }

        public override void Update(ProdutoViewModel viewModel)
        {
            _mediator.SendCommand(new UpdateProdutoCommand(viewModel.Id, viewModel.Nome, viewModel.Aplicacao, viewModel.Quantidade, viewModel.PrecoVenda));
        }

        public override void Remove(ProdutoViewModel viewModel)
        {
            _mediator.SendCommand(new RemoveProdutoCommand(viewModel.Id));
        }
    }
}

