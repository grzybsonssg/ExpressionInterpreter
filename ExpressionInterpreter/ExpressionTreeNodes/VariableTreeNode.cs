using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter.ExpressionTreeNodes
{
    public class VariableTreeNode<T> : IExpressionTreeNode<T>
    {
        private readonly string _variableName;
        private readonly IVariableProvider<T> _variableProvider;

        public VariableTreeNode(string variableName, IVariableProvider<T> variableProvider)
        {
            _variableName = variableName;
            _variableProvider = variableProvider;
        }

        public T Evaluate() => _variableProvider.GetValue(_variableName);
    }
}
