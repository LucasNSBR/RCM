using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override Marca GetById(Guid id, bool loadRelatedData = true)
        {
            if (loadRelatedData)
            {
                return _dbSet
                    .Include(m => m.Produtos)
                    .FirstOrDefault(m => m.Id == id);
            }
            else
                return base.GetById(id, false);
        }
    }
}
