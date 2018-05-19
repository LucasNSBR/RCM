using RCM.Application.ViewModels.ProdutoViewModels;
using System;
using System.Linq;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IAplicacaoApplicationService
    {
        IQueryable<AplicacaoViewModel> Get();
        AplicacaoViewModel GetById(Guid id);
    }
}
