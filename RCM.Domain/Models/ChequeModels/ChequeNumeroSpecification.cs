using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeNumeroSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly string _numeroCheque;

        public ChequeNumeroSpecification(string numeroCheque)
        {
            _numeroCheque = numeroCheque;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_numeroCheque != null)
                return c => c.NumeroCheque.ToLower().Contains(_numeroCheque.ToLower());

            return c => true;
        }
    }
}

