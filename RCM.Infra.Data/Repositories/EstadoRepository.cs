using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.EstadoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;

namespace RCM.Infra.Data.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly DbSet<Estado> _dbSet;

        public EstadoRepository(RCMDbContext dbContext)
        {
            _dbSet = dbContext.Estados;
        }

        public IQueryable<Estado> Get()
        {
            return _dbSet
                .AsNoTracking();
        }

        public Estado GetById(Guid id)
        {
            return _dbSet
                .Find(id);
        }
    }
}
