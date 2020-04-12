using ExpressionInterpreter.ExpressionTreeNodes.NumericOperations;
using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.Tokens.Operations
{
    public class DivisionToken : IBinaryOperationToken<double>
    {
        public IExpressionTreeNode<double> GetExpressionTreeNode(IExpressionTreeNode<double> leftOperand,
                                                                 IExpressionTreeNode<double> rightOperand)
        {
            return new DivisionTreeNode(leftOperand, rightOperand);
        }

        public uint Priority => 2;
    }
}