using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.ExpressionTreeNodes
{
    public class LiteralTreeNode<T> : IExpressionTreeNode<T>
    {
        private readonly T _value;

        public LiteralTreeNode(T value)
        {
            this._value = value;
        }

        public T Evaluate() => this._value;
    }
}
