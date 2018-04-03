using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ChequeModels
{
    public class ChequeAgenciaSpecification : BaseSpecification<Cheque>, ISpecification<Cheque>
    {
        private readonly string _agencia;

        public ChequeAgenciaSpecification(string agencia)
        {
            _agencia = agencia;
        }

        public override Expression<Func<Cheque, bool>> ToExpression()
        {
            if (_agencia != null)
                return c => c.Agencia.ToLower().Contains(_agencia.ToLower());

            return c => true;
        }
    }
}
