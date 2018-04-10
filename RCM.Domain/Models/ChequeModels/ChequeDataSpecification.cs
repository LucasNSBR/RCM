using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeDataSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly DateTime? _dataEmissao;
        private readonly DateTime? _dataVencimento;

        public ChequeDataSpecification(DateTime? dataEmissao, DateTime? dataVencimento)
        {
            _dataEmissao = dataEmissao;
            _dataVencimento = dataVencimento;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_dataEmissao != null && _dataVencimento != null)
                return c => c.DataEmissao >= _dataEmissao.Value && c.DataVencimento <= _dataVencimento.Value;

            if (_dataEmissao != null)
                return c => c.DataEmissao >= _dataEmissao.Value;
            if (_dataVencimento != null)
                return c => c.DataVencimento <= _dataVencimento.Value;

            return c => true;
        }
    }
}
