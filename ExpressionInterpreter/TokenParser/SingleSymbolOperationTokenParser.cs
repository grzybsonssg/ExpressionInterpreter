using System;
using System.Collections.Generic;
using ExpressionInterpreter.Interfaces;
using ExpressionInterpreter.Tokens.Operations;

namespace ExpressionInterpreter.TokenParser
{
    public class SingleSymbolOperationTokenParser : AbstractTokenParser
    {
        private readonly Dictionary<char, Func<IToken>> _operationsMapping = new Dictionary<char, Func<IToken>>
        {
            { '(', () => new OpeningParenthesisToken() },
            { ')', () => new ClosingParenthesisToken() },
            { '+', () => new AdditionToken()},
            { '-', () => new SubtractionToken()},
            { '*', () => new MultiplicationToken()},
            { '/', () => new DivisionToken()}
        };

        public SingleSymbolOperationTokenParser(AbstractTokenParser nextParser) : base(nextParser)
        { }

        public override IToken ParseToken(string expression, ref int currentPosition)
        {
            if (!_operationsMapping.ContainsKey(expression[currentPosition]))
            {
                return base.ParseToken(expression, ref currentPosition);
            }

            var token = _operationsMapping[expression[currentPosition]]();
            ++currentPosition;

            return token;
        }
    }
}
