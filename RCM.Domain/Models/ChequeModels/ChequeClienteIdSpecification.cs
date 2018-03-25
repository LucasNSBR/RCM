using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeClienteIdSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly int? _clienteId;

        public ChequeClienteIdSpecification(int? clienteId)
        {
            _clienteId = clienteId;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_clienteId != null)
                return c => c.ClienteId == _clienteId;

            return c => true;
        }
    }
}
