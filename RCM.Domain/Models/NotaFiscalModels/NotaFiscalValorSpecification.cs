using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.NotaFiscalModels
{
    public class NotaFiscalValorSpecification : BaseSpecification<NotaFiscal>, ISpecification<NotaFiscal>
    {
        private readonly decimal? _valor;

        public NotaFiscalValorSpecification(decimal valor)
        {
            _valor = valor;
        }

        public override Expression<Func<NotaFiscal, bool>> ToExpression()
        {
            if (_valor != null)
                return nf => (_valor > nf.Valor - 1) && (_valor < nf.Valor + 1);

            return nf => true;
        }
    }
}
