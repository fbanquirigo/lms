using FluentMigrator.Builders;
using FluentMigrator.Builders.Alter.Table;
using FluentMigrator.Builders.Create;
using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Builders.Delete;

namespace SaG.Data.Migrations
{
    public static class Extensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithAuditColumns(
            this ICreateTableColumnOptionOrWithColumnSyntax syntax)
        {
            return syntax.WithColumn("UserCreated").AsInt32().Nullable().ForeignKey("tblOperators", "AccessorID")
                .WithColumn("DateCreated").AsDateTime().Nullable()
                .WithColumn("UserModified").AsInt32().Nullable().ForeignKey("tblOperators", "AccessorID")
                .WithColumn("DateModified").AsDateTime().Nullable();
        }

        public static void AddAuditColumns(
            this IAlterTableAddColumnOrAlterColumnOrSchemaSyntax syntax)
        {
            syntax.AddColumn("UserCreated").AsInt32().Nullable().ForeignKey("tblOperators", "AccessorID")
                .AddColumn("DateCreated").AsDateTime().Nullable()
                .AddColumn("UserModified").AsInt32().Nullable().ForeignKey("tblOperators", "AccessorID")
                .AddColumn("DateModified").AsDateTime().Nullable();
        }

        public static void AuditColumns(this IDeleteExpressionRoot syntax,
            string tableName)
        {
            syntax.ForeignKey("fk_" + tableName + "_UserCreated_tblOperators_AccessorID").OnTable(tableName);
            syntax.Column("UserCreated").FromTable(tableName);
            syntax.Column("DateCreated").FromTable(tableName);
            syntax.ForeignKey("fk_" + tableName + "_UserModified_tblOperators_AccessorID").OnTable(tableName);
            syntax.Column("UserModified").FromTable(tableName);
            syntax.Column("DateModified").FromTable(tableName);
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(
            this ICreateTableWithColumnOrSchemaSyntax syntax)
        {
            return syntax.WithColumn("Id").AsInt32().Identity().PrimaryKey();
        }

        public static IAlterTableAddColumnOrAlterColumnSyntax AddIdColumn(
            this IAlterTableAddColumnOrAlterColumnSyntax syntax)
        {
            return syntax.AddColumn("Id").AsInt32().Identity();
        }

        public static IInSchemaSyntax IdColumn(
            this IDeleteExpressionRoot syntax, string table)
        {
            return syntax.Column("Id").FromTable(table);
        }

        public static void PrimaryKeyId(this ICreateExpressionRoot syntax, string tableName)
        {
            syntax.PrimaryKey("pk_" + tableName).OnTable(tableName).Column("Id");
        }

        public static void DeletePrimaryKeyId(this IDeleteExpressionRoot syntax, string tableName)
        {
            syntax.PrimaryKey("pk_" + tableName).FromTable(tableName);
        }
    }
}
