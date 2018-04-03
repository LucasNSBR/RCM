using System;
using System.Linq.Expressions;
using RCM.Domain.Specifications;

namespace RCM.Domain.Models.DuplicataModels
{
    public class DuplicataVencidaSpecification : BaseSpecification<Duplicata>, ISpecification<Duplicata>
    {
        private readonly bool? _vencida;

        public DuplicataVencidaSpecification(bool? vencida)
        {
            _vencida = vencida;
        }

        public override Expression<Func<Duplicata, bool>> ToExpression()
        {
            if (_vencida != null)
                if (_vencida == true)
                    return d => d.Vencida();
                else
                    return d => !d.Vencida();

            return d => true;
        }
    }
}
