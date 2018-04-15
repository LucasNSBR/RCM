using System;
using System.Linq.Expressions;
using RCM.Domain.Specifications;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeEstadoSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly string _estadoCheque; 

        public ChequeEstadoSpecification(string estadoCheque)
        {
            _estadoCheque = estadoCheque;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if(_estadoCheque != null)
                return c => c.EstadoCheque.Estado == _estadoCheque;

            return c => true;
        }
    }
}
