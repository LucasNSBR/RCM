using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.DuplicataModels
{
    public class DuplicataNaoPagaSpecification : BaseSpecification<Duplicata>, ISpecification<Duplicata>
    {
        private readonly bool? _naoPaga;

        public DuplicataNaoPagaSpecification(bool? naoPaga)
        {
            _naoPaga = naoPaga;
        }

        public override Expression<Func<Duplicata, bool>> ToExpression()
        {
            if (_naoPaga != null)
                return d => !d.Pagamento.Pago;

            return d => true;
        }
    }
}
