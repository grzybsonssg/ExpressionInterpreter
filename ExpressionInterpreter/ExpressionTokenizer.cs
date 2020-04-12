using System.Collections.Generic;
using ExpressionInterpreter.Interfaces;
using ExpressionInterpreter.TokenParser;

namespace ExpressionInterpreter
{
    public class ExpressionTokenizer
    {
        private readonly AbstractTokenParser tokenParserChain;

        public ExpressionTokenizer(AbstractTokenParser tokenParserChain)
        {
            this.tokenParserChain = tokenParserChain;
        }

        public IEnumerable<IToken> Tokenize(string expression)
        {
            var result = new List<IToken>();
            var currentPosition = 0;

            while (currentPosition < expression.Length)
            {
                if (char.IsWhiteSpace(expression[currentPosition]))
                {
                    ++currentPosition;
                }
                else
                {
                    var token = tokenParserChain.ParseToken(expression, ref currentPosition);
                    result.Add(token);
                }
            }

            return result;
        }
    }
}
