using System.Linq.Expressions;

namespace RCM.Domain.Specifications
{
    public class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _oldValue;
        private readonly ParameterExpression _newValue;

        public ParameterReplacer(ParameterExpression oldValue, ParameterExpression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        public override Expression Visit(Expression node)
        {
            if (node == _oldValue)
                return _newValue;

            return base.Visit(node);
        }
    }
}
