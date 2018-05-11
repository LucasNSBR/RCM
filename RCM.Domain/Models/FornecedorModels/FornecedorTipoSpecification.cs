using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.FornecedorModels
{
    public class FornecedorTipoSpecification : BaseSpecification<Fornecedor>, ISpecification<Fornecedor>
    {
        private readonly int? _tipo;

        public FornecedorTipoSpecification(int? tipo)
        {
            _tipo = tipo;
        }

        public override Expression<Func<Fornecedor, bool>> ToExpression()
        {
            if (_tipo != null)
                return f => _tipo == (int)f.Tipo;

            return f => true;
        }
    }
}
