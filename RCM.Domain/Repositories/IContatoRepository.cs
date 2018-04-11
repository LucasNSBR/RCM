using RCM.Domain.Models;
using System;
using System.Linq;

namespace RCM.Domain.Repositories
{
    public interface IContatoRepository : IBaseRepository<Contato>
    {
        IQueryable<Endereco> GetContatosById(Guid id);
    }
}
