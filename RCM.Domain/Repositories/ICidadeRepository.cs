using RCM.Domain.Models.CidadeModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Domain.Repositories
{
    public interface ICidadeRepository
    {
        IQueryable<Cidade> Get();
        IQueryable<Cidade> Get(Expression<Func<Cidade, bool>> expression);
        Cidade GetById(Guid id, bool loadRelatedData = true);
        void Add(Cidade cidade);
        void Remove(Cidade cidade);
    }
}
