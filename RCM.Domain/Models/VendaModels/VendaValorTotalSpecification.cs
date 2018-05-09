using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.VendaModels
{
    public class VendaValorTotalSpecification : BaseSpecification<Venda>, ISpecification<Venda>
    {
        private readonly decimal? _minValor;
        private readonly decimal? _maxValor;

        public VendaValorTotalSpecification(decimal? minValor, decimal? maxValor)
        {
            _minValor = minValor;
            _maxValor = maxValor;
        }

        public override Expression<Func<Venda, bool>> ToExpression()
        {
            if (_minValor != null && _maxValor != null)
                return v => v.TotalVenda >= _minValor.Value && v.TotalVenda <= _maxValor.Value;

            if (_minValor != null)
                return v => v.TotalVenda >= _minValor.Value;
            if (_maxValor != null)
                return v => v.TotalVenda <= _maxValor.Value;

            return v => true;
        }
    }
}
