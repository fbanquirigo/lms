using System.Collections.Generic;
using FluentMigrator;

namespace SaG.Data.Migrations.Version1001
{
     [Migration(100106)]
    public class AddAuditColumnsToTables : BaseMigration
    {
        private readonly List<string> tables;

        public AddAuditColumnsToTables()
        {
            this.tables = TableManager.TABLES;
        }

        public override void Up()
        {
            this.tables.ForEach(x => Alter.Table(x).AddAuditColumns());
        }

        public override void Down()
        {
            this.tables.ForEach(x => Delete.AuditColumns(x));
        }
    }
}
