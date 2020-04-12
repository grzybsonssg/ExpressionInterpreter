using System;
using ExpressionInterpreter.Interfaces;
using ExpressionInterpreter.Tokens;

namespace ExpressionInterpreter.TokenParser
{
    internal class LiteralTokenParser : AbstractTokenParser
    {
        private readonly char _decimalSeparator;

        public LiteralTokenParser(AbstractTokenParser nextTokenParser) : this(',', nextTokenParser)
        { }

        public LiteralTokenParser(char decimalSeparator, AbstractTokenParser nextTokenParser) : base(nextTokenParser)
        {
            this._decimalSeparator = decimalSeparator;
        }

        public override IToken ParseToken(string expression, ref int currentPosition)
        {
            if (!char.IsDigit(expression[currentPosition]))
            {
                return base.ParseToken(expression, ref currentPosition);
            }

            var tokenStartPosition = currentPosition;
            do
            {
                ++currentPosition;
            } while (currentPosition < expression.Length && (char.IsDigit(expression[currentPosition]) || expression[currentPosition] == _decimalSeparator));

            var literalText = expression.Substring(tokenStartPosition, currentPosition - tokenStartPosition);

            if (!double.TryParse(literalText, out var numericValue))
            {
                throw new ArgumentException(
                    $"Invalid literal between {tokenStartPosition} and {currentPosition}");
            }

            var token = new LiteralToken<double>(numericValue);

            return token;
        }
    }
}