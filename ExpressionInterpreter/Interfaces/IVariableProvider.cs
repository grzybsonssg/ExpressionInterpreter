namespace ExpressionInterpreter.Interfaces
{
    public interface IVariableProvider<T>
    {
        T GetValue(string variableName);

        IVariableProvider<T> SetValue(string variableName, T value);
    }
}