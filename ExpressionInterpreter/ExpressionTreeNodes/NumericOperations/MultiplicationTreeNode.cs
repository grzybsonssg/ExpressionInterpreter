using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.ExpressionTreeNodes.NumericOperations
{
    public class MultiplicationTreeNode : IExpressionTreeNode<double>
    {
        private readonly IExpressionTreeNode<double> _leftExpression;
        private readonly IExpressionTreeNode<double> _rightExpression;

        public MultiplicationTreeNode(IExpressionTreeNode<double> leftExpression, IExpressionTreeNode<double> rightExpression)
        {
            _leftExpression = leftExpression;
            _rightExpression = rightExpression;
        }

        public double Evaluate() => _leftExpression.Evaluate() * _rightExpression.Evaluate();
    }
}
