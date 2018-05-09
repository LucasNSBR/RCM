using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoPrecoVendaSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly decimal? _minValor;
        private readonly decimal? _maxValor;

        public ProdutoPrecoVendaSpecification(decimal? minValor, decimal? maxValor)
        {
            _minValor = minValor;
            _maxValor = maxValor;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_minValor != null && _maxValor != null)
                return p => p.PrecoVenda >= _minValor.Value && p.PrecoVenda <= _maxValor.Value;

            if (_minValor != null)
                return p => p.PrecoVenda >= _minValor.Value;
            if (_maxValor != null)
                return p => p.PrecoVenda <= _maxValor.Value;

            return p => true;
        }
    }
}