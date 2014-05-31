using SaG.Business;

namespace SaG.API
{
    public class OperatorContext : IOperatorContext
    {
        public IOperator Operator { get; set; }
    }
}