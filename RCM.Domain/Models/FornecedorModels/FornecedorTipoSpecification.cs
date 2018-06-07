using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.FornecedorModels
{
    public class FornecedorTipoSpecification : BaseSpecification<Fornecedor>, ISpecification<Fornecedor>
    {
        private readonly string _tipo;

        public FornecedorTipoSpecification(string tipo)
        {
            _tipo = tipo;
        }

        public override Expression<Func<Fornecedor, bool>> ToExpression()
        {
            if (_tipo != null)
                return f => _tipo == f.Tipo.ToString();

            return f => true;
        }
    }
}
