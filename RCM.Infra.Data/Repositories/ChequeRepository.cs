using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ChequeModels;
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

        public override Cheque GetById(Guid id)
        {
            return _dbSet
                .AsNoTracking()
                .Include(b => b.Banco)
                .Include(c => c.Cliente)
                .Include(ec => ec.EstadoCheque)
                .FirstOrDefault(ch => ch.Id == id);
        }

        public bool CheckNumeroChequeExists(string numeroDocumento, Guid clienteId, Guid bancoId, Guid novoChequeId)
        {
            var numeroDocumentoSpecification = new ChequeNumeroSpecification(numeroDocumento);
            var clienteIdSpecification = new ChequeClienteIdSpecification(clienteId);
            var bancoIdSpecification = new ChequeBancoIdSpecification(bancoId);

            Cheque cheque = _dbSet
                .Where(numeroDocumentoSpecification
                .And(bancoIdSpecification)
                .And(clienteIdSpecification)
                .ToExpression())
                .AsNoTracking()
                .FirstOrDefault();

            if (cheque == null || novoChequeId == cheque.Id)
                return false;

            return true;
        }
    }
}
