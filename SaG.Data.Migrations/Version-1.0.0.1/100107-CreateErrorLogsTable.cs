using FluentMigrator;

namespace SaG.Data.Migrations.Version1001
{
    [Migration(100107)]
    public class CreateErrorLogsTable : BaseMigration
    { 
        public override void Up()
        {
            Create.Table("ErrorLogs")
                .WithIdColumn()
                .WithColumn("ErrorId").AsString(64).Unique().NotNullable()
                .WithColumn("DateOccured").AsDateTime().NotNullable()
                .WithColumn("ConsumerKey").AsString(64).Nullable()
                .WithColumn("UserAccount").AsString(64).Nullable()
                .WithColumn("Request").AsCustom("nvarchar(max)").Nullable()
                .WithColumn("Exception").AsCustom("nvarchar(max)").Nullable()
                .WithAuditColumns();
            
        }

        public override void Down()
        {
            Delete.Table("ErrorLogs");
        }
    }
}
