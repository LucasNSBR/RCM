using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeValorSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly decimal? _valor;

        public ChequeValorSpecification(decimal? valor)
        {
            _valor = valor;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_valor != null)
                return c => (_valor > c.Valor - 1) && (_valor < c.Valor + 1);

            return c => true;
        }
    }
}
