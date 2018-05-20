using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;

namespace RCM.Infra.Data.Repositories
{
    public class DuplicataRepository : BaseRepository<Duplicata>, IDuplicataRepository
    {
        public DuplicataRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override Duplicata GetById(Guid id)
        {
            return _dbSet
                .AsNoTracking()
                .Include(f => f.Fornecedor)
                .Include(p => p.Pagamento)
                .FirstOrDefault(d => d.Id == id);
        }

        public bool CheckNumeroDocumentoExists(string numeroDocumento, Guid fornecedorId, Guid novaDuplicataId)
        {
            var numeroDocumentoSpecification = new DuplicataNumeroDocumentoSpecification(numeroDocumento);
            var fornecedorSpecification = new DuplicataFornecedorIdSpecification(fornecedorId);

            Duplicata duplicata = _dbSet
                .AsNoTracking()
                .Where(numeroDocumentoSpecification
                .And(fornecedorSpecification)
                .ToExpression())
                .FirstOrDefault();

            if (duplicata == null || novaDuplicataId == duplicata.Id)
                return false;

            return true;
        }
    }
}
