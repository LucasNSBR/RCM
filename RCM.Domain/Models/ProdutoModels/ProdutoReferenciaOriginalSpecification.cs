using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoReferenciaOriginalSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _referenciaOriginal;

        public ProdutoReferenciaOriginalSpecification(string referenciaOriginal)
        {
            _referenciaOriginal = referenciaOriginal;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_referenciaOriginal != null)
                return p => p.ReferenciaOriginal.ToLower().Contains(_referenciaOriginal.ToLower());

            return p => true;
        }
    }
}
