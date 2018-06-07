using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ClienteModels
{
    public class ClienteTipoSpecification : BaseSpecification<Cliente>, ISpecification<Cliente>
    {
        private readonly string _tipo;

        public ClienteTipoSpecification(string tipo)
        {
            _tipo = tipo;
        }

        public override Expression<Func<Cliente, bool>> ToExpression()
        {
            if (_tipo != null)
                return f => _tipo == f.Tipo.ToString();

            return f => true;
        }
    }
}
