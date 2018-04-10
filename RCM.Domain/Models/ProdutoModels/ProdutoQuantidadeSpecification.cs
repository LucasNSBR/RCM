using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoQuantidadeSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly decimal? _minQuantidade;
        private readonly decimal? _maxQuantidade;

        public ProdutoQuantidadeSpecification(decimal? minQuantidade, decimal? maxQuantidade)
        {
            _minQuantidade = minQuantidade;
            _maxQuantidade = maxQuantidade;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_minQuantidade != null && _maxQuantidade != null)
                return p => p.Quantidade >= _minQuantidade.Value & p.Quantidade <= _maxQuantidade.Value;

            if (_minQuantidade != null)
                return p => p.Quantidade >= _minQuantidade.Value;
            if (_maxQuantidade != null)
                return p => p.Quantidade <= _maxQuantidade.Value;

            return p => true;
        }
    }
}
