using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace SaG.Data.NHibernate
{
    public class SessionManager : ISessionManager
    {
        private readonly MappingConfig mappingConfig;
        private readonly IDbEnvironment dbConnectionSetting;
        private readonly ListenersConfig listenersConfig;

        public SessionManager(IDbEnvironment dbConnectionSetting, MappingConfig mappingConfig,
            ListenersConfig listenersConfig)
        {
            this.dbConnectionSetting = dbConnectionSetting;
            this.mappingConfig = mappingConfig;
            this.listenersConfig = listenersConfig;
        }

        public ISessionFactory CreateSessionFactory()
        {
            IPersistenceConfigurer config = MsSqlConfiguration.MsSql2012.ConnectionString(this.dbConnectionSetting.ConnectionString);

            return Fluently
                .Configure()
                .Database(config)
                .Mappings(this.mappingConfig.Configure)
                .ExposeConfiguration(this.listenersConfig.Configure)
                .BuildSessionFactory();
        }
    }
}
