using System.Collections.Generic;
using SaG.Core;

namespace SaG.API
{
    public class BootStrapper : IBootStrapper
    {
        private readonly IContainer container;

        public BootStrapper(IContainer container)
        {
            this.container = container;
        }

        public void BootStrap()
        {
            IEnumerable<IContainerInitializer> initializers = this.container.GetAllInstances<IContainerInitializer>();
            foreach (IContainerInitializer containerInitializer in initializers)
            {
                this.container.Initialize(containerInitializer.Initialize);
            }

            IEnumerable<IContainerConfigurator> configurators = this.container.GetAllInstances<IContainerConfigurator>();
            foreach (IContainerConfigurator containerConfigurator in configurators)
            {
                container.Configure(containerConfigurator.Configure);
            }

            IEnumerable<IInitializer> tasks = this.container.GetAllInstances<IInitializer>();
            foreach (IInitializer startUpTask in tasks)
            {
                startUpTask.Initialize();
            }
        }
    }
}