using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoEstoqueSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly decimal? _minEstoque;
        private readonly decimal? _maxEstoque;

        public ProdutoEstoqueSpecification(decimal? minEstoque, decimal? maxEstoque)
        {
            _minEstoque = minEstoque;
            _maxEstoque = maxEstoque;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_minEstoque != null && _maxEstoque != null)
                return p => p.Estoque >= _minEstoque.Value & p.Estoque <= _maxEstoque.Value;

            if (_minEstoque != null)
                return p => p.Estoque >= _minEstoque.Value;
            if (_maxEstoque != null)
                return p => p.Estoque <= _maxEstoque.Value;

            return p => true;
        }
    }
}
