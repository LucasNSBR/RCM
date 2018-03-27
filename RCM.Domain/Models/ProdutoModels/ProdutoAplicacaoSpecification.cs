using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoAplicacaoSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _aplicacao;

        public ProdutoAplicacaoSpecification(string aplicacao)
        {
            _aplicacao = aplicacao;
        }
        
        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_aplicacao != null)
                return p => p.Aplicacao.ToLower().Contains(_aplicacao.ToLower());

            return p => true;
        }
    }
}
