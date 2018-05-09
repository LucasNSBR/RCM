using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.VendaModels
{
    public class VendaClienteIdSpecification : BaseSpecification<Venda>, ISpecification<Venda>
    {
        private readonly Guid? _clienteId;

        public VendaClienteIdSpecification(Guid? clienteId)
        {
            _clienteId = clienteId;
        }

        public override Expression<Func<Venda, bool>> ToExpression()
        {
            if (_clienteId != null)
                return v => v.ClienteId == _clienteId.Value;

            return v => true;
        }
    }
}
