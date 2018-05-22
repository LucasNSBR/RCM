using RCM.Application.ViewModels;
using RCM.Domain.Core.Commands;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IEmpresaApplicationService
    {
        EmpresaViewModel Get();
        Task<CommandResult> AddOrUpdate(EmpresaViewModel viewModel);
        Task<CommandResult> AttachLogo(byte[] logo);
    }
}
