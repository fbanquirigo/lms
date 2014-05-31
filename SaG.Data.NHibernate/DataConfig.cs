using NHibernate;
using NHibernate.Event;
using SaG.Core;

namespace SaG.Data.NHibernate
{
    public class DataConfig : IContainerConfigurator
    {
        private readonly IContainer container;

        public DataConfig(IContainer container)
        {
            this.container = container;
        }

        public void Configure(IContainerConfigurationExpression config)
        {
            config.For<IPreUpdateEventListener>().Use<AuditableEventListener>();
            config.For<IPreInsertEventListener>().Use<AuditableEventListener>();
            config.ForSingleton<ISessionManager>().Use<SessionManager>();
            var sessionManager = container.GetInstance<ISessionManager>();
            config.ForSingleton<ISessionFactory>().Use(sessionManager.CreateSessionFactory());
            config.ForHybridHttpOrThreadLocalScoped<IDataProvider>().Use<DataProvider>();
            config.For(typeof(IRepository<>)).Use(typeof(GenericRepository<>));
        }
    }
}
