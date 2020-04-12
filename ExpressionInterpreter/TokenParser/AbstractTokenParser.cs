using System;
using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.TokenParser
{
    public class AbstractTokenParser
    {
        private AbstractTokenParser _nextParser;

        public AbstractTokenParser(AbstractTokenParser nextParser)
        {
            _nextParser = nextParser;
        }

        public virtual IToken ParseToken(string expression, ref int currentPosition)
        {
            if (_nextParser == null)
            {
                throw new ArgumentException($"Unrecognized token at {currentPosition}");
            }
            return _nextParser.ParseToken(expression, ref currentPosition);
        }

        public static AbstractTokenParser DefaultTokenParserChain 
            => new SingleSymbolOperationTokenParser(
                new VariableTokenParser(
                    new LiteralTokenParser(null)));
    }
}
