using RCM.Domain.Models;
using System;
using System.Linq;

namespace RCM.Domain.Repositories
{
    public interface IEnderecoRepository 
    {
        IQueryable<Endereco> GetEnderecosById(Guid id);
    }
}