using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoReferenciaFabricanteSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _referenciaFabricante;

        public ProdutoReferenciaFabricanteSpecification(string referenciaFabricante)
        {
            _referenciaFabricante = referenciaFabricante;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_referenciaFabricante != null)
                return p => p.ReferenciaFabricante.ToLower().Contains(_referenciaFabricante.ToLower());

            return p => true;
        }
    }
}
