namespace ExpressionInterpreter.Interfaces
{
    public interface IOperationToken : IToken
    {
        uint Priority { get; }
    }
}
