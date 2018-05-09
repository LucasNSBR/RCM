using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.VendaModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Venda> Get()
        {
            return _dbSet
                .Include(pv => pv.Produtos)
                .ThenInclude(vp => vp.Produto)
                .Include(pv => pv.Cliente)
                .AsQueryable();
        }

        public override Venda GetById(Guid id)
        {
            return _dbSet
                .Include(pv => pv.Produtos)
                .ThenInclude((VendaProduto vp) => vp.Produto)
                .ThenInclude(m => m.Marca)
                .Include(pv => pv.Cliente)
                .FirstOrDefault(v => v.Id == id);
        }
    }
}
