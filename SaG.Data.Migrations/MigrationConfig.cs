using SaG.Core;

namespace SaG.Data.Migrations
{
    public class MigrationConfig : IInitializer
    {
        private readonly IDbMigrator migrator;
        private readonly IDbEnvironment dbEnvironment;

        public MigrationConfig(IDbMigrator migrator, IDbEnvironment dbEnvironment)
        {
            this.migrator = migrator;
            this.dbEnvironment = dbEnvironment;
        }

        public void Initialize()
        {
            if (this.dbEnvironment.UpgradeDatabaseOnStart)
                this.migrator.Migrate();

#if DEBUG
            this.migrator.MigrateDown(0);
            this.migrator.Migrate();
#endif
        }
    }
}
