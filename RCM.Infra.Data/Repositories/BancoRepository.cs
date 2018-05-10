using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class BancoRepository : BaseRepository<Banco>, IBancoRepository
    {
        public BancoRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override Banco GetById(Guid id)
        {
            return _dbSet
                .AsNoTracking()
                .Include(c => c.Cheques)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
