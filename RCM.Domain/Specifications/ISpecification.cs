using RCM.Domain.Core.Models;
using System;
using System.Linq.Expressions;

namespace RCM.Domain.Specifications
{
    public interface ISpecification<T> where T : Entity<T>
    {
        bool IsSatisfiedBy(T obj);
        Expression<Func<T, bool>> ToExpression();
        ISpecification<T> Not();
        ISpecification<T> Or(ISpecification<T> other);
        ISpecification<T> And(ISpecification<T> other);
        ISpecification<T> AndNot(ISpecification<T> other);
    }
}
