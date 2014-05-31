using FluentMigrator;

namespace SaG.Data.Migrations.Version1002
{
    [Migration(100202)]
    public class AddSystemSettingsLocationId : BaseMigration
    {     
        public override void Up()
        {
            Alter.Table("tblSystem").AddColumn("LocationId").AsString(32).Nullable();
        }

        public override void Down()
        {
            Delete.Column("LocationId").FromTable("tblSystem");
        }
    }
}
