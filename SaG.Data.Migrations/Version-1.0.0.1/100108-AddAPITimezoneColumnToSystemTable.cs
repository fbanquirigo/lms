using FluentMigrator;

namespace SaG.Data.Migrations.Version1001
{
    [Migration(100108)]
    public class AddAPITimezoneColumnToSystemTable : BaseMigration
    {        
        public override void Up()
        {
            Alter.Table("tblSystem").AddColumn("APITimeZone").AsString(64).Nullable();
            Update.Table("tblSystem").Set(new { APITimeZone = "Eastern Standard Time" }).AllRows();
        }

        public override void Down()
        {
            Delete.Column("APITimeZone").FromTable("tblSystem");
        }
    }
}
