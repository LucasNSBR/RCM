using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ClienteModels
{
    public class ClienteCadastroEstadualSpecification : BaseSpecification<Cliente>, ISpecification<Cliente>
    {
        private readonly string _cadastroEstadual;

        public ClienteCadastroEstadualSpecification(string cadastroEstadual)
        {
            _cadastroEstadual = cadastroEstadual;
        }

        public override Expression<Func<Cliente, bool>> ToExpression()
        {
            if (_cadastroEstadual != null)
                return f => f.Documento.CadastroEstadual.ToLower().Contains(_cadastroEstadual.ToLower());

            return f => true;
        }
    }
}

