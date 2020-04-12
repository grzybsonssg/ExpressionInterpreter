using System.Collections.Generic;
using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter
{
    public class DictionaryVariableProvider<T> : IVariableProvider<T>
    {
        private readonly Dictionary<string, T> _variables = new Dictionary<string, T>();

        public DictionaryVariableProvider<T> SetValue(string name, T value)
        {
            _variables[name] = value;
            return this;
        }

        public T GetValue(string variableName) => _variables[variableName];
    }
}
