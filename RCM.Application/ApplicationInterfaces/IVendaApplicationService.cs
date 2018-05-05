using RCM.Application.ViewModels;
using RCM.Domain.Core.Commands;
using RCM.Domain.Models.VendaModels;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IVendaApplicationService : IBaseApplicationService<Venda, VendaViewModel>
    {
        Task<CommandResult> AttachProduto(VendaProdutoViewModel viewModel);
    }
}
