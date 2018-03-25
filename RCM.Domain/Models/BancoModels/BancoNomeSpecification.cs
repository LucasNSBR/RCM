using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.BancoModels
{
    public class BancoNomeSpecification : BaseSpecification<Banco>, ISpecification<Banco>
    {
        private readonly string _nome;

        public BancoNomeSpecification(string nome)
        {
            _nome = nome;
        }

        public override Expression<Func<Banco, bool>> ToExpression()
        {
            if(_nome != null)
                return b => b.Nome.ToLower().Contains(_nome.ToLower());

            return b => true;
        }
    }
}
