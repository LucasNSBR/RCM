using System;
using System.Linq.Expressions;
using RCM.Domain.Specifications;

namespace RCM.Domain.Models.VendaModels
{
    public class VendaStatusSpecification : BaseSpecification<Venda>, ISpecification<Venda>
    {
        private readonly string _statusVenda;

        public VendaStatusSpecification(string statusVenda)
        {
            _statusVenda = statusVenda;
        }

        public override Expression<Func<Venda, bool>> ToExpression()
        {
            if (_statusVenda != null)
                return v => _statusVenda == v.Status.ToString();

            return v => true;
        }
    }
}
