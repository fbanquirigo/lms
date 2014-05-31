using FluentMigrator;

namespace SaG.Data.Migrations.Version1010
{
    [Migration(101001)]
    public class VersionInit : VersionInitializer
    {
        public VersionInit()
            : base(new Version1010())
        { }
    }
}
