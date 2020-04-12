using ExpressionInterpreter.ExpressionTreeNodes.NumericOperations;
using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.Tokens.Operations
{
    public class AdditionToken : IBinaryOperationToken<double>
    {
        public IExpressionTreeNode<double> GetExpressionTreeNode(IExpressionTreeNode<double> leftOperand,
                                                                 IExpressionTreeNode<double> rightOperand)
        {
            return new AdditionTreeNode(leftOperand, rightOperand);
        }

        public uint Priority => 1;
    }
}