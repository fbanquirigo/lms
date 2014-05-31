namespace SaG.Data.NHibernate
{
    public class GenericRepository<TEntity> : Repository<TEntity>
    {
        public GenericRepository(IDataProvider provider)
            : base(provider)
        {   
        }
    }
}
