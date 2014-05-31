using System.Resources;
using SaG.API.Controllers;
using SaG.API.Properties;
using SaG.Core;
using SaG.Core.Events;

namespace SaG.API
{
    public class DependencyConfig : IContainerConfigurator
    {     
        public void Configure(IContainerConfigurationExpression config)
        {
            config.ForSingleton<IEventDispatcher>().Use<EventDispatcher>();
            config.For<ResourceManager>().Use(Resources.ResourceManager);
            config.For<IAPIAccessController>().Use<AccessController>();
        }
    }
}