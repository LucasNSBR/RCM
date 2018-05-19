using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;

namespace RCM.Infra.Data.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override Fornecedor GetById(Guid id)
        {
            return _dbSet
                .Include(d => d.Duplicatas)
                .Include(d => d.Endereco.Cidade)
                .FirstOrDefault(f => f.Id == id);
        }
    }
}
