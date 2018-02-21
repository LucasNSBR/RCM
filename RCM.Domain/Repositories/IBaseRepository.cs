using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RCM.Domain.Repositories
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        IEnumerable<TModel> Get();
        IEnumerable<TModel> Get(Expression<Func<TModel, bool>> expression);
        TModel GetById(int id);

        void Add(TModel model);
        void Update(TModel model);
        void Remove(TModel model);
    }
}
