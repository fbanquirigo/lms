namespace SaG.Data
{
    public interface IKeyedRepository<out TEntity, in TKey>
    {
        TEntity Get(TKey key);
    }
}