using System;
using System.Linq;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly RCMDbContext _dbContext;
        
        public ContatoRepository(RCMDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IQueryable<Contato> GetContatosById(Guid id)
        {
            return _dbContext.Contatos.Where(e => e.Id == id);
        }
    }
}
