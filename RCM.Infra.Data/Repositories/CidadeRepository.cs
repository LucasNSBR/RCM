using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Infra.Data.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly DbSet<Cidade> _dbSet;

        public CidadeRepository(RCMDbContext dbContext) 
        {
            _dbSet = dbContext.Cidades;
        }

        public IQueryable<Cidade> Get()
        {
            return _dbSet
                .AsNoTracking();
        }

        public IQueryable<Cidade> Get(Expression<Func<Cidade, bool>> expression = null)
        {
            return _dbSet
                .Where(expression)
                .AsNoTracking();
        }

        public Cidade GetById(Guid id)
        {
            return _dbSet
                .Include(e => e.Estado)
                .FirstOrDefault(e => e.Id == id);
        }
        
        public void Add(Cidade cidade)
        {
            _dbSet.Add(cidade);
        }

        public void Remove(Cidade cidade)
        {
            _dbSet.Remove(cidade);
        }
    }
}
