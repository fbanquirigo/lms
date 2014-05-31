using FluentMigrator;

namespace SaG.Data.Migrations.Version1001
{
    [Migration(100103)]
    public class CreateAPIAuthCodesTable : BaseMigration
    {
        public override void Up()
        {
            Create.Table("APIAuthCodes")
                .WithIdColumn()
                .WithColumn("ClientId").AsInt32().NotNullable().ForeignKey("APIClients", "Id")
                .WithColumn("AuthCode").AsString(64).NotNullable().Unique("ix_APIAuthCodes_AuthCode")
                .WithColumn("AccessorID").AsInt32().NotNullable().ForeignKey("tblOperators", "AccessorID")
                .WithColumn("IssuedOn").AsDateTime().NotNullable()
                .WithColumn("ExpiresOn").AsDateTime().NotNullable()
                .WithColumn("IsTokenized").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IsExpired").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithAuditColumns();
        }

        public override void Down()
        {
            Delete.Table("APIAuthCodes");
        }
    }
}
