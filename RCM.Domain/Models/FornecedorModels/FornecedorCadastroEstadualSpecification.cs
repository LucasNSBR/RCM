using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.FornecedorModels
{
    public class FornecedorCadastroEstadualSpecification : BaseSpecification<Fornecedor>, ISpecification<Fornecedor>
    {
        private readonly string _cadastroEstadual; 

        public FornecedorCadastroEstadualSpecification(string cadastroEstadual)
        {
            _cadastroEstadual = cadastroEstadual;
        }

        public override Expression<Func<Fornecedor, bool>> ToExpression()
        {
            if (_cadastroEstadual != null)
                return f => f.Documento.CadastroEstadual.Contains(_cadastroEstadual);

            return f => true;
        }
    }
}
