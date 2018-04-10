using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeBancoIdSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly Guid? _bancoId;

        public ChequeBancoIdSpecification(Guid bancoId)
        {
            _bancoId = bancoId; 
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_bancoId != null)
                return c => c.BancoId == _bancoId.Value;

            return c => true;
        }
    }
}
