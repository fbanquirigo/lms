using FluentMigrator;

namespace SaG.Data.Migrations.Version1001
{
    [Migration(100104)]
    public class CreateAPIAccessTokensTable : BaseMigration
    { 
        public override void Up()
        {
            Create.Table("APIAccessTokens")
                .WithIdColumn()
                .WithColumn("ClientId").AsInt32().NotNullable().ForeignKey("APIClients", "Id")
                .WithColumn("AuthCodeId").AsInt32().NotNullable().ForeignKey("APIAuthCodes", "Id")
                .WithColumn("AccessorID").AsInt32().NotNullable().ForeignKey("tblOperators", "AccessorID")
                .WithColumn("AccessToken").AsString(64).NotNullable().Unique("ix_APIAccessTokens_AccessToken")
                .WithColumn("IssuedOn").AsDateTime().NotNullable()
                .WithColumn("ExpiresOn").AsDateTime().NotNullable()
                .WithColumn("LastUsedOn").AsDateTime().Nullable()
                .WithColumn("IsExpired").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithAuditColumns();
        }

        public override void Down()
        {                                          
            Delete.Table("APIAccessTokens");
        }
    }
}
