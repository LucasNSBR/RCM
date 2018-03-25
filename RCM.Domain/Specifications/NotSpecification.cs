using System;
using System.Linq.Expressions;

namespace RCM.Domain.Specifications
{
    public class NotSpecification<T> : BaseSpecification<T>, ISpecification<T> where T : class
    {
        private readonly ISpecification<T> _left;

        public NotSpecification(ISpecification<T> left)
        {
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression leftExpr = _left.ToExpression();
            Expression body = Expression.Not(leftExpr);
            Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(body);

            return expression;
        }
    }
}
