using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.Tokens.Operations
{
    public class OpeningParenthesisToken : IOperationToken
    {
        public uint Priority => 0;
    }
}
