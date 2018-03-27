using RCM.Application.ViewModels;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IProdutoApplicationService : IBaseApplicationService<Produto, ProdutoViewModel>
    {
    }
}