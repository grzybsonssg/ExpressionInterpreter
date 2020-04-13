using ExpressionInterpreter.ExpressionTreeNodes;
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

        public VariableTreeNode<T> GetExpressionTreeNode<T>(IVariableProvider<T> variableProvider) =>
            new VariableTreeNode<T>(Name, variableProvider);
    }
}
