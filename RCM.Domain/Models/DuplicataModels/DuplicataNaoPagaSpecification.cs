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
                if (_naoPaga == true)
                    return d => d.Pagamento.IsEmpty();
                else
                    return d => !d.Pagamento.IsEmpty();

            return d => true;
        }
    }
}
