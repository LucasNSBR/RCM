using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.FornecedorModels
{
    public class FornecedorNomeSpecification : BaseSpecification<Fornecedor>, ISpecification<Fornecedor>
    {
        private readonly string _nome;

        public FornecedorNomeSpecification(string nome)
        {
            _nome = nome;
        }

        public override Expression<Func<Fornecedor, bool>> ToExpression()
        {
            if (_nome != null)
                return f => f.Nome.ToLower().Contains(_nome.ToLower());

            return f => true;
        }
    }
}
