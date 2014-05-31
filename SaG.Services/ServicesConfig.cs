using SaG.Core;

namespace SaG.Services
{
    public class ServicesConfig : IContainerConfigurator
    {

        public void Configure(IContainerConfigurationExpression config)
        {
            config.ForSingleton<ICommandContext>().Use<CommandContext>();
            config.ForSingleton<ISystemContext>().Use<SystemContext>();
        }
    }
}
