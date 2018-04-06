using RCM.Domain.Core.Commands;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IBaseApplicationService<TModel, TViewModel> : IDisposable 
                                                                 where TModel : class
                                                                 where TViewModel : class
    {
        IQueryable<TViewModel> Get();
        IQueryable<TViewModel> Get(Expression<Func<TModel, bool>> expression);
        TViewModel GetById(Guid id);

        Task<RequestResponse> Add(TViewModel viewModel);
        Task<RequestResponse> Update(TViewModel viewModel);
        Task<RequestResponse> Remove(TViewModel viewModel);
    }
}
