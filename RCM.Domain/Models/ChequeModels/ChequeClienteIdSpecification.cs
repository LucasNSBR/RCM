using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeClienteIdSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly Guid? _clienteId;

        public ChequeClienteIdSpecification(Guid? clienteId)
        {
            _clienteId = clienteId;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_clienteId != null)
                return c => c.ClienteId == _clienteId.Value;

            return c => true;
        }
    }
}
