namespace SaG.Data
{
    public interface IDataProvider
    {
        void Commit();

        void Rollback(); 
    }
}