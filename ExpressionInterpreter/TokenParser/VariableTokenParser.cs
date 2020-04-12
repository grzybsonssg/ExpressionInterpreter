using System.Text.RegularExpressions;
using ExpressionInterpreter.Interfaces;
using ExpressionInterpreter.Tokens;

namespace ExpressionInterpreter.TokenParser
{
    public class VariableTokenParser : AbstractTokenParser
    {
        private char _variableOpeningSymbol = '{';
        private char _variableClosingSymbol = '}';

        public VariableTokenParser(AbstractTokenParser nextParser) : base(nextParser)
        { }

        public override IToken ParseToken(string expression, ref int currentPosition)
        {
            if (expression[currentPosition] != _variableOpeningSymbol)
            {
                return base.ParseToken(expression, ref currentPosition);
            }
            
            ++currentPosition;
            var variableNameStartPosition = currentPosition;
            while (currentPosition < expression.Length && expression[currentPosition] != _variableClosingSymbol)
            {
                ++currentPosition;
            }

            var variableName = expression.Substring(variableNameStartPosition, currentPosition - variableNameStartPosition);
            var token = new VariableToken(variableName);

            ++currentPosition;

            return token;
        }
    }
}
