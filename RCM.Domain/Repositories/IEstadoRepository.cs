using RCM.Domain.Models.EstadoModels;
using System;
using System.Linq;

namespace RCM.Domain.Repositories
{
    public interface IEstadoRepository 
    {
        IQueryable<Estado> Get();
        Estado GetById(Guid id);
    }
}
