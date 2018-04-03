using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeValorSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly decimal? _minValor;
        private readonly decimal? _maxValor;

        public ChequeValorSpecification(decimal? minValor, decimal? maxValor)
        {
            _minValor = minValor;
            _maxValor = maxValor;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_minValor != null && _maxValor != null)
                return c => c.Valor >= _minValor & c.Valor <= _maxValor;

            if (_minValor != null)
                return c => c.Valor >= _minValor;
            if (_maxValor != null)
                return c => c.Valor <= _maxValor;

            return c => true;
        }
    }
}
