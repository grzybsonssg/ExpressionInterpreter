using System.Collections.Generic;
using ExpressionInterpreter.ExpressionTreeNodes;
using ExpressionInterpreter.Interfaces;
using ExpressionInterpreter.Tokens;
using ExpressionInterpreter.Tokens.Operations;

namespace ExpressionInterpreter
{
    public static class ExpressionTreeBuilder
    {
        public static IExpressionTreeNode<T> BuildTree<T>(IEnumerable<IToken> tokenizedExpression,
            IVariableProvider<T> variableProvider)
        {
            var operationsStack = new Stack<IOperationToken>();
            var resultStack = new Stack<IExpressionTreeNode<T>>();

            foreach (var token in tokenizedExpression)
                switch (token)
                {
                    case LiteralToken<T> literalToken:
                        resultStack.Push(literalToken.GetExpressionTreeNode());
                        break;
                    case VariableToken variableToken:
                        resultStack.Push(variableToken.GetExpressionTreeNode(variableProvider));
                        break;
                    case OpeningParenthesisToken openingParenthesisToken:
                        operationsStack.Push(openingParenthesisToken);
                        break;
                    case ClosingParenthesisToken _:
                        HandleClosingParenthesisToken(operationsStack, resultStack);
                        break;
                    case IOperationToken operationToken:
                        HandleOperationToken(operationsStack, operationToken, resultStack);
                        break;
                }

            AppendRemainingOperationsToResult(operationsStack, resultStack);

            return resultStack.Pop();
        }

        private static void HandleClosingParenthesisToken<T>(Stack<IOperationToken> operationsStack,
                                                             Stack<IExpressionTreeNode<T>> resultStack)
        {
            while (operationsStack.Count > 0 && !(operationsStack.Peek() is OpeningParenthesisToken))
                AppendOperationToResult(operationsStack, resultStack);

            operationsStack.Pop();
        }

        private static void HandleOperationToken<T>(Stack<IOperationToken> operationsStack,
                                                    IOperationToken operationToken, 
                                                    Stack<IExpressionTreeNode<T>> resultStack)
        {
            while (operationsStack.Count > 0 &&
                   operationsStack.Peek().Priority >= operationToken.Priority)
            {
                AppendOperationToResult(operationsStack, resultStack);
            }

            operationsStack.Push(operationToken);
        }

        private static void AppendRemainingOperationsToResult<T>(Stack<IOperationToken> operationsStack, 
                                                                 Stack<IExpressionTreeNode<T>> resultStack)
        {
            while (operationsStack.Count > 0)
            {
                AppendOperationToResult(operationsStack, resultStack);
            }
        }

        private static void AppendOperationToResult<T>(Stack<IOperationToken> operationsStack,
                                                       Stack<IExpressionTreeNode<T>> resultStack)
        {
            var lastOperation = operationsStack.Pop();
            if (lastOperation is IBinaryOperationToken<T> lastBinaryOperation)
            {
                AppendBinaryOperationToResult(resultStack, lastBinaryOperation);
            }
        }

        private static void AppendBinaryOperationToResult<T>(Stack<IExpressionTreeNode<T>> resultStack,
                                                             IBinaryOperationToken<T> lastBinaryOperation)
        {
            var rightOperand = resultStack.Pop();
            var leftOperand = resultStack.Pop();
            var operationTreeNode = lastBinaryOperation.GetExpressionTreeNode(leftOperand, rightOperand);

            resultStack.Push(operationTreeNode);
        }
    }
}