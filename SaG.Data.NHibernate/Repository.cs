using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace SaG.Data.NHibernate
{
    public abstract class Repository<TEntity> : RepositoryBase<TEntity>
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

        protected Repository(IDataProvider provider)
            : base(provider)
        {
            if (!(provider is DataProvider))
                throw new ArgumentException("Constructor parameter is not of type SaG.Data.NHibernate.DataProvider");
            NHibernateDataProvider = provider as DataProvider;
        }

        public override void Save(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public override void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }

        public override TEntity GetById(int id)
        {
            return Session.Get<TEntity>(id);
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return Session.Query<TEntity>().ToList();
        }

        protected IQueryable<TEntity> Query
        {
            get { return Session.Query<TEntity>(); }
        }
    }
}
