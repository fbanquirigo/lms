namespace SaG.Data
{
    public interface IRepository<TEntity> : 
        IPersistanceRepository<TEntity>, 
        IIdentityRepository<TEntity, int>
    {    
    }
}