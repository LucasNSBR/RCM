using RCM.Domain.Specifications;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Models.ProdutoModels
{
    public class ProdutoIdSpecification : BaseSpecification<Produto>, ISpecification<Produto>
    {
        private readonly string _id;

        public ProdutoIdSpecification(string id)
        {
            _id = id;
        }

        public override Expression<Func<Produto, bool>> ToExpression()
        {
            if (_id != null)
                return p => p.Id.ToString().ToLower().Contains(_id.ToLower());

            return p => true;
        }
    }
}
