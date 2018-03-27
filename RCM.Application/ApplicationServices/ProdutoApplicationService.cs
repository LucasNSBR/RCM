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
            _mediator.SendCommand(new AddProdutoCommand(ProjectToModel(viewModel)));
        }

        public override void Update(ProdutoViewModel viewModel)
        {
            _mediator.SendCommand(new UpdateProdutoCommand(ProjectToModel(viewModel)));
        }

        public override void Remove(ProdutoViewModel viewModel)
        {
            _mediator.SendCommand(new RemoveProdutoCommand(ProjectToModel(viewModel)));
        }
    }
}

