using System.Collections.Generic;

namespace SaG.Data
{
    public abstract class RepositoryBase<TEntity> : 
        IRepository<TEntity>
    {
        private readonly IDataProvider provider;

        protected virtual IDataProvider DataProvider
        {
            get
            {
                return this.provider;
            }
        }

        protected RepositoryBase(IDataProvider provider)
        {
            this.provider = provider;
        }

        public abstract void Save(TEntity entity);

        public abstract void Delete(TEntity entity);

        public abstract TEntity GetById(int id);

        public abstract IEnumerable<TEntity> GetAll();
    }
}
