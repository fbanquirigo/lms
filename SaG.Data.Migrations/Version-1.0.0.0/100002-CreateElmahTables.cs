using FluentMigrator;

namespace SaG.Data.Migrations.Version1000
{
    [Migration(100002)]
    public class CreateElmahTables : BaseMigration
    {  
        public override void Up()
        {
            Execute.EmbeddedScript("Elmah.sql");
        }

        public override void Down()
        {
            Execute.EmbeddedScript("Drop-Elmah.sql");
        }
    }
}
