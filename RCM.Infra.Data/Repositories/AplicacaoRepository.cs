using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class AplicacaoRepository : IAplicacaoRepository
    {
        private DbSet<Aplicacao> _dbSet;

        public AplicacaoRepository(RCMDbContext dbContext) 
        {
            _dbSet = dbContext.Aplicacoes;
        }

        public IQueryable<Aplicacao> Get()
        {
            return _dbSet;
        }

        public Aplicacao GetById(Guid id)
        {
            return _dbSet.Find(id);
        }
    }
}
