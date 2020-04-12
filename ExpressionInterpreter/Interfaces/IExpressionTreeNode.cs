namespace ExpressionInterpreter.Interfaces
{
    public interface IExpressionTreeNode<T>
    {
        T Evaluate();
    }
}