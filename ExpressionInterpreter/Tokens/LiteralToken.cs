using ExpressionInterpreter.ExpressionTreeNodes;
using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.Tokens
{
    public class LiteralToken<T> : IToken
    {
        public T Value { get; }

        public LiteralToken(T value)
        {
            Value = value;
        }

        public IExpressionTreeNode<T> GetExpressionTreeNode() => new LiteralTreeNode<T>(Value);
    }
}
