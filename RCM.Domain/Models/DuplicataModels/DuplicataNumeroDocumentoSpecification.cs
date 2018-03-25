using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.DuplicataModels
{
    public class DuplicataNumeroDocumentoSpecification : BaseSpecification<Duplicata>, ISpecification<Duplicata>
    {
        private readonly string _numeroDocumento;

        public DuplicataNumeroDocumentoSpecification(string numeroDocumento)
        {
            _numeroDocumento = numeroDocumento;
        }

        public override Expression<Func<Duplicata, bool>> ToExpression()
        {
            if (_numeroDocumento != null)
                return d => d.NumeroDocumento.ToLower().Contains(_numeroDocumento.ToLower());

            return d => true;
        }
    }
}
