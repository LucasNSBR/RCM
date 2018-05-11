using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ClienteModels
{
    public class ClienteCadastroEstadualSpecification
    {
        public class ClienteCadastroNacionalSpecification : BaseSpecification<Cliente>, ISpecification<Cliente>
        {
            private readonly string _cadastroEstadual;

            public ClienteCadastroNacionalSpecification(string cadastroEstadual)
            {
                _cadastroEstadual = cadastroEstadual;
            }

            public override Expression<Func<Cliente, bool>> ToExpression()
            {
                if (_cadastroEstadual != null)
                    return f => f.Documento.CadastroNacional.Contains(_cadastroEstadual);

                return f => true;
            }
        }
    }
}
