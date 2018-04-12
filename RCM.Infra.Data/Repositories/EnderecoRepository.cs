using System;
using System.Linq;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;

namespace RCM.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly RCMDbContext _dbContext;

        public EnderecoRepository(RCMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Endereco> GetEnderecosById(Guid id)
        {
            return _dbContext.Enderecos.Where(e => e.Id == id);
        }
    }
}
