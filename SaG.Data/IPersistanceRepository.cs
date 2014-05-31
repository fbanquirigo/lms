namespace SaG.Data
{
    public interface IPersistanceRepository<in TEntity>
    {
        void Save(TEntity entity);

        void Delete(TEntity entity);    
    }
}