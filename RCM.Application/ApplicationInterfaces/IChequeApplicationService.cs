using RCM.Application.ViewModels.ChequeViewModels;
using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ChequeModels;
using System;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IChequeApplicationService : IBaseApplicationService<Cheque, ChequeViewModel>
    {
        Task<CommandResult> BloquearCheque(Guid id);
        Task<CommandResult> CompensarCheque(Guid id, EstadoChequeViewModel viewModel);
        Task<CommandResult> RepassarCheque(Guid id, EstadoChequeViewModel viewModel);
        Task<CommandResult> SustarCheque(Guid id, EstadoChequeViewModel viewModel);
        Task<CommandResult> DevolverCheque(Guid id, EstadoChequeViewModel viewModel);
    }
}
