using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.ExpressionTreeNodes.NumericOperations
{
    public class AdditionTreeNode : IExpressionTreeNode<double>
    {
        private readonly IExpressionTreeNode<double> _leftExpression;
        private readonly IExpressionTreeNode<double> _rightExpression;

        public AdditionTreeNode(IExpressionTreeNode<double> leftExpression, IExpressionTreeNode<double> rightExpression)
        {
            _leftExpression = leftExpression;
            _rightExpression = rightExpression;
        }

        public double Evaluate() => _leftExpression.Evaluate() + _rightExpression.Evaluate();
    }
}
