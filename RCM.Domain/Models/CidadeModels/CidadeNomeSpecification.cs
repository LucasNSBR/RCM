using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.CidadeModels
{
    public class CidadeNomeSpecification : BaseSpecification<Cidade>, ISpecification<Cidade>
    {
        private readonly string _nome;

        public CidadeNomeSpecification(string nome)
        {
            _nome = nome;
        }

        public override Expression<Func<Cidade, bool>> ToExpression()
        {
            if (_nome != null)
                return c => c.Nome.ToLower().Contains(_nome.ToLower());

            return c => true;
        }
    }
}
