using System;
using System.Linq.Expressions;
using RCM.Domain.Specifications;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoNomeSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _nome;

        public ProdutoNomeSpecification(string nome)
        {
            _nome = nome;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_nome != null)
                return p => p.Nome.ToLower().Contains(_nome.ToLower());

            return p => true;
        }
    }
}
