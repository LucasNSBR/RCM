using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ClienteModels
{
    public class ClienteTipoSpecification : BaseSpecification<Cliente>, ISpecification<Cliente>
    {
        private readonly int? _tipo;

        public ClienteTipoSpecification(int? tipo)
        {
            _tipo = tipo;
        }

        public override Expression<Func<Cliente, bool>> ToExpression()
        {
            if (_tipo != null)
                return f => _tipo == (int)f.Tipo;

            return f => true;
        }
    }
}
