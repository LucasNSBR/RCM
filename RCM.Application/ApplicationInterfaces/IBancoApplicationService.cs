using RCM.Application.ViewModels;
using RCM.Domain.Models.BancoModels;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IBancoApplicationService : IBaseApplicationService<Banco, BancoViewModel>
    {
    }
}
