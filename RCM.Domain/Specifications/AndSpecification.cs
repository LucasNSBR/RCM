using RCM.Domain.Core.Models;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Specifications
{
    public class AndSpecification<T> : BaseSpecification<T>, ISpecification<T> where T : Entity<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            ParameterExpression param = Expression.Parameter(typeof(T));

            var leftExpr = _left.ToExpression();
            var left = new ParameterReplacer(leftExpr.Parameters[0], param).Visit(leftExpr.Body);

            var rightExpr = _right.ToExpression();
            var right = new ParameterReplacer(rightExpr.Parameters[0], param).Visit(rightExpr.Body);

            Expression body = Expression.And(left, right);
            Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(body, param);

            return expression;
        }
    }
}
