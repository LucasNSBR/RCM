using RCM.Application.ViewModels;
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
