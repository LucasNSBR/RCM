using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.ProdutoCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using System;
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
            return _mediator.SendCommand(new AddProdutoCommand(viewModel.Nome, viewModel.Quantidade, viewModel.PrecoVenda, viewModel.MarcaId));
        }

        public override Task<CommandResult> Update(ProdutoViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateProdutoCommand(viewModel.Id, viewModel.Nome, viewModel.Quantidade, viewModel.PrecoVenda, viewModel.MarcaId));
        }

        public override Task<CommandResult> Remove(ProdutoViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveProdutoCommand(viewModel.Id));
        }

        public Task<CommandResult> RelacionarAplicacao(ProdutoViewModel produtoViewModel, AplicacaoViewModel aplicacaoViewModel)
        {
            return _mediator.SendCommand(new AttachProdutoAplicacaoCommand(produtoViewModel.Id, aplicacaoViewModel.Id));
        }

        public Task<CommandResult> AdicionarAplicacao(ProdutoViewModel produtoViewModel, AplicacaoViewModel aplicacaoViewModel)
        {
            return _mediator.SendCommand(new AddProdutoAplicacaoCommand(produtoViewModel.Id, aplicacaoViewModel.Marca, aplicacaoViewModel.Modelo, aplicacaoViewModel.Ano, aplicacaoViewModel.Motor, aplicacaoViewModel.Observacao));
        }

        public Task<CommandResult> RemoverAplicacao(Guid produtoId, Guid aplicacaoId)
        {
            return _mediator.SendCommand(new RemoveProdutoAplicacaoCommand(produtoId, aplicacaoId));
        }
    }
}

