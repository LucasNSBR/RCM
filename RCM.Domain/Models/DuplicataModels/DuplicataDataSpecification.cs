using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.DuplicataModels
{
    public class DuplicataDataSpecification : BaseSpecification<Duplicata>, ISpecification<Duplicata>
    {
        private readonly DateTime? _dataInicial;
        private readonly DateTime? _dataFinal;

        public DuplicataDataSpecification(DateTime? dataInicial, DateTime? dataFinal)
        {
            _dataInicial = dataInicial;
            _dataFinal = dataFinal;
        }

        public override Expression<Func<Duplicata, bool>> ToExpression()
        {
            if (_dataInicial != null && _dataFinal != null)
                return d => d.DataVencimento >= _dataInicial.Value && d.DataVencimento <= _dataFinal.Value;

            if (_dataInicial != null)
                return d => d.DataVencimento >= _dataInicial.Value;
            if (_dataFinal != null)
                return d => d.DataVencimento <= _dataFinal.Value;

            return d => true;
        }
    }
}
