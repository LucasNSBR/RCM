using RCM.Domain.Models.ChequeModels;
using System;

namespace RCM.Domain.Repositories
{
    public interface IChequeRepository : IBaseRepository<Cheque>
    {
        bool CheckNumeroChequeExists(string numeroDocumento, Guid clienteId, Guid bancoId, Guid novoChequeId);
    }
}
