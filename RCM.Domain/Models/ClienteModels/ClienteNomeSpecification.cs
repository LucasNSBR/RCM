using System;
using System.Linq.Expressions;
using RCM.Domain.Specifications;

namespace RCM.Domain.Models.ClienteModels
{
    public class ClienteNomeSpecification : BaseSpecification<Cliente>, ISpecification<Cliente>
    {
        private readonly string _nome;

        public ClienteNomeSpecification(string nome)
        {
            _nome = nome;
        }

        public override Expression<Func<Cliente, bool>> ToExpression()
        {
            if (_nome != null)
                return c => c.Nome.ToLower().Contains(_nome.ToLower());

            return c => true;
        }
    }
}
