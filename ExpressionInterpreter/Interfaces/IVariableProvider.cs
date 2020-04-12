namespace ExpressionInterpreter.Interfaces
{
    public interface IVariableProvider<T>
    {
        T GetValue(string variableName);
    }
}