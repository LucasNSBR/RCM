using RCM.Application.ViewModels;
using RCM.Domain.Core.Commands;
using RCM.Domain.Models.BancoModels;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IBancoApplicationService : IBaseApplicationService<Banco, BancoViewModel>
    {
    }
}
