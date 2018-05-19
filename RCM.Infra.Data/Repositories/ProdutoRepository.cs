using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;

namespace RCM.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override Produto GetById(Guid id)
        {
            return _dbSet
                .Include(p => p.Marca)
                .Include(ap => ap.Aplicacoes)
                .ThenInclude((ProdutoAplicacao a) => a.Aplicacao)
                .Include(pf => pf.Fornecedores)
                .ThenInclude((ProdutoFornecedor f) => f.Fornecedor)
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }
    }
}