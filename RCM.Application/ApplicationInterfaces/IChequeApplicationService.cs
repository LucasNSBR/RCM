using RCM.Application.ViewModels;
using RCM.Domain.Models.ChequeModels;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IChequeApplicationService : IBaseApplicationService<Cheque, ChequeViewModel>
    {
    }
}
