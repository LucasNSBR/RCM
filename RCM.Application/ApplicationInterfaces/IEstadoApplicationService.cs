using RCM.Application.ViewModels;
using System;
using System.Linq;

namespace RCM.Application.ApplicationInterfaces
{
    public interface IEstadoApplicationService
    {
        IQueryable<EstadoViewModel> Get();
        EstadoViewModel GetById(Guid id);
    }
}
