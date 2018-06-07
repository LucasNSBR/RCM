using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;
using RCM.Infra.Data.Context;
using System;
using System.Linq;

namespace RCM.Infra.Data.Repositories
{
    public class AplicacaoRepository : IAplicacaoRepository
    {
        private DbSet<Aplicacao> _dbSet;

        public AplicacaoRepository(RCMDbContext dbContext) 
        {
            _dbSet = dbContext.Aplicacoes;
        }

        public IQueryable<Aplicacao> Get()
        {
            return _dbSet
                .AsNoTracking()
                .OrderBy(a => a.Carro.Marca)
                .ThenBy(a => a.Carro.Modelo)
                .ThenBy(a => a.Carro.Ano)
                .ThenBy(a => a.Carro.Observacao);
        }

        public Aplicacao GetById(Guid id)
        {
            return _dbSet
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
