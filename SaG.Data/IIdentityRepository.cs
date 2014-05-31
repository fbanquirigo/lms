namespace SaG.Data
{
    public interface IIdentityRepository<out TEntity, in TId>
    {
        TEntity GetById(TId id);
    }
}