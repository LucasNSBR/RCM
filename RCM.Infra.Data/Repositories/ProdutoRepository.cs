using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(RCMDbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Produto> Get(Expression<Func<Produto, bool>> expression)
        {
            return base.Get(expression)
                .OrderBy(p => p.Nome);
        }

        public override Produto GetById(Guid id, bool includeRelatedData = true)
        {
            if (includeRelatedData)
            {
                return _dbSet
                    .Include(p => p.Marca)
                    .Include(ap => ap.Aplicacoes)
                    .ThenInclude((ProdutoAplicacao a) => a.Aplicacao)
                    .Include(pf => pf.Fornecedores)
                    .ThenInclude((ProdutoFornecedor f) => f.Fornecedor)
                    .FirstOrDefault(p => p.Id == id);
            }
            else
                return base.GetById(id, false);
        }
    }
}