using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.DuplicataModels
{
    public class DuplicataValorSpecification : BaseSpecification<Duplicata>, ISpecification<Duplicata>
    {
        private readonly decimal? _minValor;
        private readonly decimal? _maxValor;

        public DuplicataValorSpecification(decimal? minValor, decimal? maxValor)
        {
            _minValor = minValor;
            _maxValor = maxValor;
        }

        public override Expression<Func<Duplicata, bool>> ToExpression()
        {
            if (_minValor != null && _maxValor != null)
                return d => d.Valor >= _minValor && d.Valor <= _maxValor;

            if (_minValor != null)
                return d => d.Valor >= _minValor;
            if (_maxValor != null)
                return d => d.Valor <= _maxValor;

            return d => true;
        }
    }
}
