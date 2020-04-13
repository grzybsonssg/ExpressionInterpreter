using System.Collections.Generic;
using ExpressionInterpreter.Interfaces;

namespace ExpressionInterpreter
{
    public class DictionaryVariableProvider : IVariableProvider<double>
    {
        private readonly Dictionary<string, double> _numericVariables = new Dictionary<string, double>();

        public IVariableProvider<double> SetValue(string name, double value)
        {
            _numericVariables[name] = value;
            return this;
        }

        public double GetValue(string variableName) => _numericVariables[variableName];
    }
}
