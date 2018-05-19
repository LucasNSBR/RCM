using RCM.Application.ViewModels.ProdutoViewModels;
using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IProdutoApplicationService : IBaseApplicationService<Produto, ProdutoViewModel>
    {
        Task<CommandResult> RelacionarAplicacao(ProdutoViewModel produtoViewModel, AplicacaoViewModel aplicacaoViewModel);
        Task<CommandResult> AdicionarAplicacao(ProdutoViewModel viewModel, AplicacaoViewModel aplicacaoViewModel);
        Task<CommandResult> RemoverAplicacao(Guid produtoId, Guid aplicacaoId);
        Task<CommandResult> AdicionarFornecedor(ProdutoFornecedorViewModel produtoFornecedorViewModel);
        Task<CommandResult> RemoverFornecedor(Guid produtoId, Guid aplicacaoId);
    }
}