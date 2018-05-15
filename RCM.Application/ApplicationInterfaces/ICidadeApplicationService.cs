using RCM.Application.ViewModels;
using RCM.Domain.Core.Commands;
using RCM.Domain.Models.CidadeModels;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationInterfaces
{
    public interface ICidadeApplicationService
    {
        IQueryable<CidadeViewModel> Get();
        IQueryable<CidadeViewModel> Get(Expression<Func<Cidade, bool>> expression);
        CidadeViewModel GetById(Guid id);
        Task<CommandResult> Add(CidadeViewModel viewModel);
        Task<CommandResult> Remove(Guid id);
    }
}
