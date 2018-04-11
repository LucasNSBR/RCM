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

        Task<CommandResult> Add(TViewModel viewModel);
        Task<CommandResult> Update(TViewModel viewModel);
        Task<CommandResult> Remove(TViewModel viewModel);
    }
}
