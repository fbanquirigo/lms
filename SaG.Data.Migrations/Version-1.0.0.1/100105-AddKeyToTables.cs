using FluentMigrator;

namespace SaG.Data.Migrations.Version1001
{
    [Migration(100105)]
    public class AddKeyToTables : BaseMigration
    {   
        public override void Up()
        {
            Alter.Table("tblPendTampResetStatus").AddIdColumn();
            Create.PrimaryKeyId("tblPendTampResetStatus");

            Alter.Table("tblPendBackModeStatus").AddIdColumn();
            Create.PrimaryKeyId("tblPendBackModeStatus");

            Alter.Table("tblPendAuditStatus").AddIdColumn();
            Create.PrimaryKeyId("tblPendAuditStatus");

            Alter.Table("tblTampResetStatus").AddIdColumn();
            Create.PrimaryKeyId("tblTampResetStatus");

            Create.PrimaryKey("pk_tblRptTkUserAudit").OnTable("tblRptTkUserAudit").Column("AuditID");   

            Alter.Table("tblBitActive").AddIdColumn();
            Create.PrimaryKeyId("tblBitActive");

            Alter.Table("tblBankModeStatus").AddIdColumn();
            Create.PrimaryKeyId("tblBankModeStatus");

            Alter.Table("tblAuditStatus").AddIdColumn();
            Create.PrimaryKeyId("tblAuditStatus");

            Create.PrimaryKey("pk_tblOpCodeAudit").OnTable("tblOpCodeAudit").Column("OpCodeEntity");

            Alter.Table("tblDispATMs").AddIdColumn();
            Create.PrimaryKeyId("tblDispATMs");

            Alter.Table("tblBitYesNo").AddIdColumn();
            Create.PrimaryKeyId("tblBitYesNo");
        }

        public override void Down()
        {
            Delete.DeletePrimaryKeyId("tblPendTampResetStatus");
            Delete.IdColumn("tblPendTampResetStatus");

            Delete.DeletePrimaryKeyId("tblPendBackModeStatus");
            Delete.IdColumn("tblPendBackModeStatus");

            Delete.DeletePrimaryKeyId("tblPendAuditStatus");
            Delete.IdColumn("tblPendAuditStatus");

            Delete.DeletePrimaryKeyId("tblTampResetStatus");
            Delete.IdColumn("tblTampResetStatus");

            Delete.PrimaryKey("pk_tblRptTkUserAudit").FromTable("tblRptTkUserAudit");

            Delete.DeletePrimaryKeyId("tblBitActive");
            Delete.IdColumn("tblBitActive");

            Delete.DeletePrimaryKeyId("tblBankModeStatus");
            Delete.IdColumn("tblBankModeStatus");

            Delete.DeletePrimaryKeyId("tblAuditStatus");
            Delete.IdColumn("tblAuditStatus");

            Delete.PrimaryKey("pk_tblOpCodeAudit").FromTable("tblOpCodeAudit");

            Delete.DeletePrimaryKeyId("tblDispATMs");
            Delete.IdColumn("tblDispATMs");

            Delete.DeletePrimaryKeyId("tblBitYesNo");
            Delete.IdColumn("tblBitYesNo");
        }
    }
}
