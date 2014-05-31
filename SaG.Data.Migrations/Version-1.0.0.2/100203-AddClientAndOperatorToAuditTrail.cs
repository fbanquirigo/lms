using FluentMigrator;

namespace SaG.Data.Migrations.Version1002
{
    [Migration(100203)]
    public class AddClientAndOperatorToAuditTrail : BaseMigration
    {         
        public override void Up()
        {
            Alter.Table("tblOperAudit").AddColumn("APIClientId").AsInt32().Nullable().ForeignKey("APIClients", "Id");
            Alter.Table("tblOperAudit").AddColumn("AccessorID").AsInt32().Nullable().ForeignKey("tblOperators", "AccessorId");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_tblOperAudit_AccessorID_tblOperators_AccessorId").OnTable("tblOperAudit");
            Delete.ForeignKey("FK_tblOperAudit_APIClientId_APIClients_Id").OnTable("tblOperAudit");
            Delete.Column("AccessorID").FromTable("tblOperAudit");
            Delete.Column("APIClientId").FromTable("tblOperAudit");
        }
    }
}
