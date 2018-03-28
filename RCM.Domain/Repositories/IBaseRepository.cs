using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Domain.Repositories
{
    public interface IBaseRepository<TModel> : IDisposable
                                               where TModel : class
    {
        IQueryable<TModel> Get();
        IQueryable<TModel> Get(Expression<Func<TModel, bool>> expression);
        TModel GetById(Guid id);

        void Add(TModel model);
        void Update(TModel model);
        void Remove(TModel model);
    }
}
