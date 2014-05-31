using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace SaG.Data.NHibernate
{
    public abstract class BaseRepository<TEntity> 
    {
        protected DataProvider NHibernateDataProvider
        {
            get;
            private set;
        }

        protected ISession Session
        {
            get
            {
                return NHibernateDataProvider.Session;
            }
        }

        protected BaseRepository(IDataProvider provider)
        {
            if (!(provider is DataProvider))
                throw new ArgumentException("Constructor parameter is not of type SaG.Data.NHibernate.DataProvider");
            NHibernateDataProvider = provider as DataProvider;
        }

        protected IQueryable<TEntity> Query
        {
            get { return Session.Query<TEntity>(); }
        }
    }
}
