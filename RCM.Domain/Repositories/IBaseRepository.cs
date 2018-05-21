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

        /// <summary>
        /// Get Entity by Id and optionally load their navigation properties
        /// </summary>
        /// <param name="id">Id of the Entity</param>
        /// <param name="loadRelatedData">Load Navigation properties from the Entity</param>
        /// <returns></returns>
        TModel GetById(Guid id, bool loadRelatedData = true);

        void Add(TModel model);
        void Update(TModel model);
        void Remove(TModel model);
    }
}
