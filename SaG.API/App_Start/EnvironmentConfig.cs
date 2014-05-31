using System.Configuration;
using SaG.API.Environments;
using SaG.Core;
using SaG.Data;
using SaG.Encrypt;

namespace SaG.API
{
    public class EnvironmentConfig : IContainerConfigurator
    {   
        private readonly IContainer container;

        public EnvironmentConfig(IContainer container)
        {
            this.container = container;
        }

        public void Configure(IContainerConfigurationExpression config)
        {
            var environment = "development";
            if (ConfigurationManager.AppSettings["ApplicationEnvironment"] != null)
                environment = ConfigurationManager.AppSettings["ApplicationEnvironment"].ToLower();

            switch (environment)
            {
                case "development":
                    config.ForSingleton<IApplicationEnvironment>().Use<DevelopmentEnvironment>();
                    break;
                case "staging":
                    config.ForSingleton<IApplicationEnvironment>().Use<StagingEnvironment>();
                    break;
                case "production":
                    config.ForSingleton<IApplicationEnvironment>().Use<ProductionEnvironment>();
                    break;
            }

            var applicationEnvironment = this.container.GetInstance<IApplicationEnvironment>();
            config.ForSingleton<IDbEnvironment>().Use(applicationEnvironment.DbEnvironment);
            config.For<ICryptoProvider>().Use(applicationEnvironment.CryptoProviderType);
        }
    }
}