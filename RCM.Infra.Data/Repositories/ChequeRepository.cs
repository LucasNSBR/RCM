using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class ChequeRepository : BaseRepository<Cheque>, IChequeRepository
    {
        public ChequeRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public bool CheckNumeroChequeExists(string numeroDocumento, Guid clienteId, Guid bancoId, Guid novoChequeId)
        {
            var numeroDocumentoSpecification = new ChequeNumeroSpecification(numeroDocumento);
            var clienteIdSpecification = new ChequeClienteIdSpecification(clienteId);
            var bancoIdSpecification = new ChequeBancoIdSpecification(bancoId);

            Cheque cheque = _dbSet.AsNoTracking()
                .Where(numeroDocumentoSpecification
                .And(bancoIdSpecification)
                .And(clienteIdSpecification)
                .ToExpression())
                .FirstOrDefault();

            if (cheque == null || novoChequeId == cheque.Id)
                return false;

            return true;
        }
    }
}
