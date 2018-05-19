using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.VendaModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Infra.Data.Repositories
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Venda> Get(Expression<Func<Venda, bool>> expression)
        {
            return _dbSet
                .Include(pv => pv.Produtos)
                .ThenInclude(vp => vp.Produto)
                .Include(pv => pv.Cliente)
                .Where(expression)
                .AsNoTracking();
        }

        public override Venda GetById(Guid id)
        {
            return _dbSet
                .Include(pv => pv.Produtos)
                .ThenInclude((VendaProduto vp) => vp.Produto)
                .ThenInclude(m => m.Marca)
                .Include(pv => pv.Cliente)
                .AsNoTracking()
                .FirstOrDefault(v => v.Id == id);
        }
    }
}
