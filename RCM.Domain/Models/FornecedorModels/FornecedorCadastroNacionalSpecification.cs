using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.FornecedorModels
{
    public class FornecedorCadastroNacionalSpecification : BaseSpecification<Fornecedor>, ISpecification<Fornecedor>
    {
        private readonly string _cadastroNacional;

        public FornecedorCadastroNacionalSpecification(string cadastroNacional)
        {
            _cadastroNacional = cadastroNacional;
        }

        public override Expression<Func<Fornecedor, bool>> ToExpression()
        {
            if (_cadastroNacional != null)
                return f => f.Documento.CadastroNacional.Contains(_cadastroNacional);

            return f => true;
        }
    }
}
