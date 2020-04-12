namespace ExpressionInterpreter.Interfaces
{
    public interface IBinaryOperationToken<T> : IOperationToken
    {
        IExpressionTreeNode<T> GetExpressionTreeNode(IExpressionTreeNode<T> leftOperand,
                                             IExpressionTreeNode<T> rightOperand);
    }
}