using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IBaseApplicationService<TModel, TViewModel> where TModel : class
                                                                 where TViewModel : class
    {
        IEnumerable<TViewModel> Get();
        IEnumerable<TViewModel> Get(Expression<Func<TModel, bool>> expression);
        TViewModel GetById(int id);

        void Add(TViewModel viewModel);
        void Update(TViewModel viewModel);
        void Remove(TViewModel viewModel);
    }
}
