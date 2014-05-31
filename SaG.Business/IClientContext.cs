namespace SaG.Business
{
    public interface IClientContext
    {
        IConsumer Consumer { get; }    
 
        IOperator Operator { get; }
    }
}