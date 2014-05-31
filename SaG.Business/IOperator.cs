namespace SaG.Business
{
    public interface IOperator
    {
        int Id { get; }

        string LoginName { get; }

        OperatorPriorityLevel PriorityLevel { get; } 
    }
}