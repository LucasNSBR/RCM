using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoReferenciaAuxiliarSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _referenciaAuxiliar;

        public ProdutoReferenciaAuxiliarSpecification(string referenciaAuxiliar)
        {
            _referenciaAuxiliar = referenciaAuxiliar;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_referenciaAuxiliar != null)
                return p => p.ReferenciaAuxiliar.ToLower() == _referenciaAuxiliar.ToLower();

            return p => true;
        }
    }
}
