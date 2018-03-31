using RCM.Application.ViewModels;
using RCM.Domain.Models.DuplicataModels;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IDuplicataApplicationService : IBaseApplicationService<Duplicata, DuplicataViewModel>
    {
        void Pagar(DuplicataViewModel viewModel, PagamentoViewModel pagamentoViewModel);
        void Estornar(DuplicataViewModel viewModel);
    }
}
