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
    }
}
