using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoMarcaIdSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly Guid? _marcaId;

        public ProdutoMarcaIdSpecification(Guid? marcaId)
        {
            _marcaId = marcaId;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_marcaId != null)
                return p => p.MarcaId == _marcaId.Value;

            return p => true;
        }
    }
}
