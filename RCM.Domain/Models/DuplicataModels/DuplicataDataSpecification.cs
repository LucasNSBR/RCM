using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.DuplicataModels
{
    public class DuplicataDataSpecification : BaseSpecification<Duplicata>, ISpecification<Duplicata>
    {
        private readonly DateTime? _dataEmissao;
        private readonly DateTime? _dataVencimento;

        public DuplicataDataSpecification(DateTime? dataEmissao, DateTime? dataVencimento)
        {
            _dataEmissao = dataEmissao;
            _dataVencimento = dataVencimento;
        }

        public override Expression<Func<Duplicata, bool>> ToExpression()
        {
            if (_dataEmissao != null && _dataVencimento != null)
                return d => d.DataEmissao >= _dataEmissao && d.DataVencimento <= _dataVencimento;

            if (_dataEmissao != null)
                return d => d.DataEmissao >= _dataEmissao;
            if (_dataVencimento != null)
                return d => d.DataVencimento <= _dataVencimento;

            return d => true;
        }
    }
}
