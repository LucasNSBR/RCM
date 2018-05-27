using RCM.Application.ViewModels.VendaViewModels;
using RCM.Domain.Core.Commands;
using RCM.Domain.Models.VendaModels;
using System;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IVendaApplicationService : IBaseApplicationService<Venda, VendaViewModel>
    {
        Task<CommandResult> AttachProduto(VendaProdutoViewModel viewModel);
        Task<CommandResult> RemoveProduto(Guid vendaId, Guid produtoId);
        Task<CommandResult> FinalizarVenda(Guid vendaId, CondicaoPagamentoViewModel viewModel);
        Task<CommandResult> PagarParcela(Guid vendaId, int parcelaId);
    }
}
