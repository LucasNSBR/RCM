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
                return c => c.Valor >= _minValor.Value & c.Valor <= _maxValor.Value;

            if (_minValor != null)
                return c => c.Valor >= _minValor.Value;
            if (_maxValor != null)
                return c => c.Valor <= _maxValor.Value;

            return c => true;
        }
    }
}
