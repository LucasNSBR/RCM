using RCM.Application.ViewModels;
using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ClienteModels;
using System;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IClienteApplicationService : IBaseApplicationService<Cliente, ClienteViewModel>
    {
        Task<CommandResult> AdicionarContato(ContatoViewModel viewModel);
        Task<CommandResult> RemoverContato(Guid id);
    }
}
