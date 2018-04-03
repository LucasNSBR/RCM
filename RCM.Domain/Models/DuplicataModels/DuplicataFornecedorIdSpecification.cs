using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.DuplicataModels
{
    public class DuplicataFornecedorIdSpecification : BaseSpecification<Duplicata>, ISpecification<Duplicata>
    {
        private readonly Guid? _fornecedorId;

        public DuplicataFornecedorIdSpecification(Guid? fornecedorId)
        {
            _fornecedorId = fornecedorId;
        }

        public override Expression<Func<Duplicata, bool>> ToExpression()
        {
            if (_fornecedorId != null)
                return d => d.FornecedorId == _fornecedorId;

            return d => true;
        }
    }
}
