using RCM.Application.ViewModels;
using RCM.Domain.Core.Commands;
using RCM.Domain.Models.DuplicataModels;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IDuplicataApplicationService : IBaseApplicationService<Duplicata, DuplicataViewModel>
    {
        Task<CommandResult> Pagar(DuplicataViewModel viewModel, PagamentoViewModel pagamentoViewModel);
        Task<CommandResult> Estornar(DuplicataViewModel viewModel);
    }
}
