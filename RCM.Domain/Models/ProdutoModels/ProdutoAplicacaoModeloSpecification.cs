using RCM.Domain.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoAplicacaoModeloSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _modelo;

        public ProdutoAplicacaoModeloSpecification(string modelo)
        {
            _modelo = modelo;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_modelo != null)
                return p => p.Aplicacoes.Any(a => a.Aplicacao.Carro.Modelo.ToLower().Contains(_modelo.ToLower()));

            return p => true;
        }
    }
}
