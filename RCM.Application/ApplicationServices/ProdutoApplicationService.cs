using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels.ProdutoViewModels;
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
            return _mediator.SendCommand(new AddProdutoCommand(viewModel.Nome, viewModel.Unidade, viewModel.Estoque, viewModel.EstoqueMinimo, viewModel.EstoqueIdeal, viewModel.PrecoVenda, viewModel.MarcaId, viewModel.ReferenciaFabricante, viewModel.ReferenciaOriginal, viewModel.ReferenciaAuxiliar));
        }

        public override Task<CommandResult> Update(ProdutoViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateProdutoCommand(viewModel.Id, viewModel.Nome, viewModel.Unidade, viewModel.Estoque, viewModel.EstoqueMinimo, viewModel.EstoqueIdeal, viewModel.PrecoVenda, viewModel.MarcaId, viewModel.ReferenciaFabricante, viewModel.ReferenciaOriginal, viewModel.ReferenciaAuxiliar));
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
            return _mediator.SendCommand(new AddProdutoAplicacaoCommand(produtoViewModel.Id, aplicacaoViewModel.CarroMarca, aplicacaoViewModel.CarroModelo, aplicacaoViewModel.CarroAno, aplicacaoViewModel.CarroMotor, aplicacaoViewModel.Observacao));
        }

        public Task<CommandResult> RemoverAplicacao(Guid produtoId, Guid aplicacaoId)
        {
            return _mediator.SendCommand(new RemoveProdutoAplicacaoCommand(produtoId, aplicacaoId));
        }

        public Task<CommandResult> AdicionarFornecedor(ProdutoFornecedorViewModel produtoFornecedorViewModel)
        {
            return _mediator.SendCommand(new AttachFornecedorCommand(produtoFornecedorViewModel.ProdutoId, produtoFornecedorViewModel.FornecedorId, produtoFornecedorViewModel.PrecoCusto, produtoFornecedorViewModel.Disponibilidade));
        }

        public Task<CommandResult> RemoverFornecedor(Guid produtoId, Guid fornecedorId)
        {
            return _mediator.SendCommand(new RemoveProdutoFornecedorCommand(produtoId, fornecedorId));
        }
    }
}

