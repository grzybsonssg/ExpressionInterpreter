using System;
using ExpressionInterpreter.Interfaces;
using ExpressionInterpreter.TokenParser;

namespace ExpressionInterpreter.Demo
{
    static class Program
    {
        static void Main()
        {
            var expression = "{factor}*(3+4)+5*6";
            var variableProvider = new DictionaryVariableProvider<double>().SetValue("factor", 2);
            var expressionTree = BuildExpressionTree(expression, variableProvider);
            
            Console.WriteLine(expressionTree.Evaluate());
            variableProvider.SetValue("factor", 3);
            Console.WriteLine(expressionTree.Evaluate());
        }

        static IExpressionTreeNode<double> BuildExpressionTree(string expression, IVariableProvider<double> variableProvider)
        {
            var tokenizer = new ExpressionTokenizer(AbstractTokenParser.DefaultTokenParserChain);
            var tokenizedExpression = tokenizer.Tokenize(expression);
            var expressionTree = ExpressionTreeBuilder.BuildTree(tokenizedExpression, variableProvider);
            return expressionTree;
        }
    }
}
