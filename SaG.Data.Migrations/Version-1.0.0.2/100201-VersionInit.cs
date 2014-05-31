using FluentMigrator;

namespace SaG.Data.Migrations.Version1002
{
    [Migration(100201)]
    public class VersionInit : VersionInitializer
    {
        public VersionInit()
            : base(new Version1002())
        { }
    }
}
