namespace SaG.Data.Migrations
{
    public interface IDbMigrator
    {
        void Migrate();

        void MigrateUp(int dbVersion);

        void MigrateDown(int dbVersion);
    }
}