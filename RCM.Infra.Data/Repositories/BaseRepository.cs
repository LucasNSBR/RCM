using Microsoft.EntityFrameworkCore;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Infra.Data.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected readonly RCMDbContext _dbContext;
        protected readonly DbSet<TModel> _dbSet;

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

        public IQueryable<TModel> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> expression)
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

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(_dbContext);
        }
    }
}
