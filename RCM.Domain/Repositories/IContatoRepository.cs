using RCM.Domain.Models;
using System;
using System.Linq;

namespace RCM.Domain.Repositories
{
    public interface IContatoRepository 
    {
        IQueryable<Contato> GetContatosById(Guid id);
    }
}
