using SaG.Core.Logging;

namespace SaG.Core.Log4Net
{
    public class LoggingConfig : IContainerConfigurator
    {
        public void Configure(IContainerConfigurationExpression config)
        {
            ILogger logger = Logger.GetLogger("defaultLogger");
            if(logger != null)
                config.ForSingleton<ILogger>().Use(logger);
        }
    }
}
