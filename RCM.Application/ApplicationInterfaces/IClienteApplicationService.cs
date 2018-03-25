using RCM.Application.ViewModels;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IClienteApplicationService : IBaseApplicationService<Cliente, ClienteViewModel>
    {
    }
}
