using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;
using SaG.Core;

namespace SaG.Data.Migrations
{
    public class MigrationDependencyConfig : IContainerConfigurator
    {  
        public void Configure(IContainerConfigurationExpression config)
        {
            config.For<MigrationProcessorFactory>().Use<SqlServer2012ProcessorFactory>();
            config.ForSingleton<IMigrationLogger>().Use(MigrationLogger.GetLogger());
            config.ForSingleton<IDbMigrator>().Use<DbMigrator>();
        }
    }
}
