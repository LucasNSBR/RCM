using RCM.Domain.Models.ProdutoModels;
using System;
using System.Linq;

namespace RCM.Domain.Repositories
{
    public interface IAplicacaoRepository 
    {
        IQueryable<Aplicacao> Get();
        Aplicacao GetById(Guid id);
    }
}
