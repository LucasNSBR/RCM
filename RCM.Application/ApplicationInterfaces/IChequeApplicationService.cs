using RCM.Application.ViewModels;
using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ChequeModels;
using System;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IChequeApplicationService : IBaseApplicationService<Cheque, ChequeViewModel>
    {
        Task<CommandResult> BloquearCheque(Guid id);
        Task<CommandResult> CompensarCheque(Guid id);
        Task<CommandResult> RepassarCheque(Guid id);
        Task<CommandResult> DevolverCheque(Guid id);
        Task<CommandResult> SustarCheque(Guid id);
    }
}
