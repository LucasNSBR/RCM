using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ChequeModels.ChequeStates;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;

namespace RCM.Infra.Data.Repositories
{
    public class ChequeRepository : BaseRepository<Cheque>, IChequeRepository
    {
        public ChequeRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override Cheque GetById(Guid id, bool loadRelatedData = true)
        {
            if (loadRelatedData)
            {
                return _dbSet
                    .Include(b => b.Banco)
                    .Include(c => c.Cliente)
                    .Include(ec => ec.EstadoCheque)
                    .ThenInclude(cl => (cl as ChequeRepassado).Fornecedor)
                    .FirstOrDefault(ch => ch.Id == id);
            }
            else
                return base.GetById(id, false);
        }

        public bool CheckNumeroChequeExists(string numeroDocumento, Guid clienteId, Guid bancoId, Guid novoChequeId)
        {
            var numeroDocumentoSpecification = new ChequeNumeroSpecification(numeroDocumento);
            var clienteIdSpecification = new ChequeClienteIdSpecification(clienteId);
            var bancoIdSpecification = new ChequeBancoIdSpecification(bancoId);

            Cheque cheque = _dbSet
                .AsNoTracking()
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
