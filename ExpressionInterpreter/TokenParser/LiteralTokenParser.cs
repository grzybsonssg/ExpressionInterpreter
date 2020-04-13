using System;
using ExpressionInterpreter.Interfaces;
using ExpressionInterpreter.Tokens;

namespace ExpressionInterpreter.TokenParser
{
    internal class LiteralTokenParser : AbstractTokenParser
    {
        private readonly char _decimalSeparator;
        private readonly char _negativeSymbol;

        public LiteralTokenParser(AbstractTokenParser nextTokenParser) : this(',', '-', nextTokenParser)
        { }

        public LiteralTokenParser(char decimalSeparator, char negativeSymbol, AbstractTokenParser nextTokenParser) : base(nextTokenParser)
        {
            this._decimalSeparator = decimalSeparator;
            this._negativeSymbol = negativeSymbol;
        }

        public override IToken ParseToken(string expression, ref int currentPosition)
        {
            var isPositiveLiteral = char.IsDigit(expression[currentPosition]);
            var isNegativeLiteral = expression[currentPosition] == _negativeSymbol && char.IsDigit(expression[currentPosition+1]);
            if (!isPositiveLiteral && !isNegativeLiteral)
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