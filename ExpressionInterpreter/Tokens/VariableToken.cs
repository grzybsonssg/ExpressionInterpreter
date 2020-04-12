using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.Tokens
{
    public class VariableToken : IToken
    {
        public string Name { get; }
        public VariableToken(string name)
        {
            Name = name;
        }
    }
}
