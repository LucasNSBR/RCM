using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IBaseApplicationService<TModel, TViewModel> : IDisposable 
                                                                 where TModel : class
                                                                 where TViewModel : class
    {
        IQueryable<TViewModel> Get();
        IQueryable<TViewModel> Get(Expression<Func<TModel, bool>> expression);
        TViewModel GetById(Guid id);

        void Add(TViewModel viewModel);
        void Update(TViewModel viewModel);
        void Remove(TViewModel viewModel);
    }
}
