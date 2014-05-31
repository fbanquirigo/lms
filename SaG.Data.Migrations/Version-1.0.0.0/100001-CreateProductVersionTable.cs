using FluentMigrator;

namespace SaG.Data.Migrations.Version1000
{
    [Migration(100001)]
    public class CreateProductVersionTable : BaseMigration
    {    
        public override void Up()
        {
            Create.Table("ProductVersion")
                .WithColumn("Version").AsString(11).Unique("ix_ProductVersion_Version").PrimaryKey("pk_ProductVersion")
                .WithColumn("Name").AsString(32).Unique("ix_ProductVersion_Name")
                .WithColumn("AppliedOn").AsDateTime();
            WriteVersion(new Version1000());
        }

        public override void Down()
        {
            RemoveVersion(new Version1000());
            Delete.Table("ProductVersion");  
        }
    }
}
