namespace SaG.Data.Migrations
{
    public abstract class VersionInitializer : BaseMigration
    {
        private readonly IProductVersion version;

        private IProductVersion Version { get { return this.version; } }

        public override void Up()
        {
            WriteVersion(Version);
        }

        public override void Down()
        {
            RemoveVersion(Version);
        }

        protected VersionInitializer(IProductVersion version)
        {
            this.version = version;
        }
    }
}
