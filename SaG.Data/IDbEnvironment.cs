namespace SaG.Data
{
    public interface IDbEnvironment
    {
        string ConnectionString { get; }

        bool UpgradeDatabaseOnStart { get; }
    }
}