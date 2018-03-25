using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeContaCorrenteSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly string _contaCorrente;

        public ChequeContaCorrenteSpecification(string contaCorrente)
        {
            _contaCorrente = contaCorrente;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_contaCorrente != null)
                return c => c.NumeroCheque.ToLower().Contains(_contaCorrente.ToLower());

            return c => true;
        }
    }
}
