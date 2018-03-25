using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.DuplicataModels
{
    public class DuplicataValorSpecification : BaseSpecification<Duplicata>, ISpecification<Duplicata>
    {
        private readonly decimal? _valor;

        public DuplicataValorSpecification(decimal? valor)
        {
            _valor = valor;
        }

        public override Expression<Func<Duplicata, bool>> ToExpression()
        {
            if (_valor != null)
                return d => (_valor < (d.Valor + 1)) && (_valor > (d.Valor - 1));

            return d => true;
        }
    }
}
