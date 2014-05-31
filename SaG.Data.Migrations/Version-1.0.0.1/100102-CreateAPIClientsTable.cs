using FluentMigrator;

namespace SaG.Data.Migrations.Version1001
{
    [Migration(100102)]
    public class CreateAPIClientsTable : BaseMigration
    {  
        public override void Up()
        {
            Create.Table("APIClients")
                .WithIdColumn()
                .WithColumn("ApplicationName").AsString(32).NotNullable()
                .WithColumn("ConsumerKey").AsString(64).Unique("ix_APIClients_ConsumerKey").NotNullable()
                .WithColumn("ConsumerSecret").AsString(64).NotNullable()
                .WithColumn("Domain").AsString(64).Nullable()
                .WithColumn("Suspended").AsBoolean().WithDefaultValue(false).NotNullable()
                .WithAuditColumns();

            Insert.IntoTable("APIClients").Row(new
            {
                ApplicationName = "SaG API Test Client",
                ConsumerKey = "2k34nsr234danwerl02po1yzvmeiucg",
                ConsumerSecret = "MmttbHFibnNyOW9ydGRhbndlcmwwMnBvMXl6dg==",
                Suspended = false
            });
        }

        public override void Down()
        {
            Delete.Table("APIClients");
        }
    }
}
