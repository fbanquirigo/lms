using FluentMigrator;

namespace SaG.Data.Migrations.Version1003
{
    [Migration(100301)]
    public class VersionInit : VersionInitializer
    {
        public VersionInit()
            : base(new Version1003())
        { }
    }
}
