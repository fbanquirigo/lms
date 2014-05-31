using System;
using NHibernate;

namespace SaG.Data.NHibernate
{
    public class DataProvider : IDataProvider, IDisposable
    {
        private readonly ITransaction transaction;

        public ISession Session
        {
            get;
            private set;
        }

        public DataProvider(ISessionFactory sessionFactory)
        {
            Session = sessionFactory.OpenSession();
            this.transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            this.transaction.Commit();
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }

        public void Dispose()
        {
            if (!(this.transaction.WasCommitted || this.transaction.WasRolledBack))
                this.transaction.Commit();
            Session.Close();
            Session = null;
        }
    }
}