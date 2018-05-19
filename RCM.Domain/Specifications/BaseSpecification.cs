using RCM.Domain.Core.Models;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T> where T : Entity<T>
    {
        public ISpecification<T> AndNot(ISpecification<T> other)
        {
            return new AndNotSpecification<T>(this, other);
        }

        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T obj)
        {
            return ToExpression().Compile().Invoke(obj);
        }
    }
}
