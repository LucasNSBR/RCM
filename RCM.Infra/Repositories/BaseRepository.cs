using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RCM.Domain.Repositories;
using RCM.Infra.Models;

namespace RCM.Infra.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected RCMDbContext _dbContext;
        protected DbSet<TModel> _dbSet;

        public BaseRepository(RCMDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TModel>();
        }

        public void Add(TModel model)
        {
            _dbSet.Add(model);
        }

        public void Remove(TModel model)
        {
            _dbSet.Remove(model);
        }

        public IEnumerable<TModel> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public IEnumerable<TModel> Get(Expression<Func<TModel, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        public TModel GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TModel model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
