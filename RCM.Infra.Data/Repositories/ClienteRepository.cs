using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public override Cliente GetById(Guid id)
        {
            return _dbSet
                .Include(ch => ch.Cheques)
                .FirstOrDefault(c => c.Id == id);
        }

        public ClienteRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }
    }
}
