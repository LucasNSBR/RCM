using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.NotaFiscalModels
{
    public class NotaFiscalValorSpecification : BaseSpecification<NotaFiscal>, ISpecification<NotaFiscal>
    {
        private readonly decimal? _minValor;
        private readonly decimal? _maxValor;

        public NotaFiscalValorSpecification(decimal? minValor, decimal? maxValor)
        {
            _minValor = minValor;
            _maxValor = maxValor;
        }

        public override Expression<Func<NotaFiscal, bool>> ToExpression()
        {
            if (_minValor != null)
                return nf => nf.Valor >= _minValor;

            if (_maxValor != null)
                return nf => nf.Valor <= _maxValor;

            if (_minValor != null && _maxValor != null)
                return nf => nf.Valor >= _minValor && nf.Valor <= _maxValor;

            return nf => true;
        }
    }
}
