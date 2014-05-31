using SaG.Core;

namespace SaG.Business
{
    public class ClientContext : IClientContext
    {
        private readonly IContainer container;

        public IConsumer Consumer
        {
            get
            {
                return this.container.GetInstance<IConsumerContext>().Consumer;
            }
        }

        public IOperator Operator
        {
            get
            {
                return this.container.GetInstance<IOperatorContext>().Operator;
            }
        }

        public ClientContext(IContainer container)
        {
            this.container = container;
        }
    }
}
