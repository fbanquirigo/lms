using FluentMigrator;

namespace SaG.Data.Migrations.Version1001
{
    [Migration(100101)]
    public class VersionInit : VersionInitializer
    {
        public VersionInit()
            : base(new Version1001())
        { }
    }
}
