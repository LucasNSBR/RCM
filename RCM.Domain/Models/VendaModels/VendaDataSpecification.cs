using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.VendaModels
{
    public class VendaDataSpecification : BaseSpecification<Venda>, ISpecification<Venda>
    {
        private readonly DateTime? _minData;
        private readonly DateTime? _maxData;

        public VendaDataSpecification(DateTime? minData, DateTime? maxData)
        {
            _minData = minData;
            _maxData = maxData;
        }

        public override Expression<Func<Venda, bool>> ToExpression()
        {
            if (_minData != null && _maxData != null)
                return v => v.DataVenda >= _minData.Value && v.DataVenda <= _maxData.Value;
            if (_minData != null)
                return v => v.DataVenda >= _minData.Value;
            if (_maxData != null)
                return v => v.DataVenda <= _maxData.Value;

            return v => true;
        }
    }
}
