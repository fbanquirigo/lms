using SaG.Business;

namespace SaG.API
{
    public class ConsumerContext : IConsumerContext
    {
        public IConsumer Consumer { get; set; }
    }
}