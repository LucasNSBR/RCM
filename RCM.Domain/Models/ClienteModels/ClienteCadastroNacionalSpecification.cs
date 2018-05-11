using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ClienteModels
{
    public class ClienteCadastroNacionalSpecification : BaseSpecification<Cliente>, ISpecification<Cliente>
    {
        private readonly string _cadastroNacional;

        public ClienteCadastroNacionalSpecification(string cadastroNacional)
        {
            _cadastroNacional = cadastroNacional;
        }

        public override Expression<Func<Cliente, bool>> ToExpression()
        {
            if (_cadastroNacional != null)
                return f => f.Documento.CadastroNacional.Contains(_cadastroNacional);

            return f => true;
        }
    }
}
