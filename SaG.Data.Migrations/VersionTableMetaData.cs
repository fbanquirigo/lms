using FluentMigrator.VersionTableInfo;

namespace SaG.Data.Migrations
{
    [VersionTableMetaData]
    public class VersionTableMetaData : IVersionTableMetaData
    {
        public string ColumnName
        {
            get { return "Version"; }
        }

        public string SchemaName
        {
            get { return string.Empty; }
        }

        public string TableName
        {
            get { return "DatabaseVersion"; }
        }

        public string UniqueIndexName
        {
            get { return "ix_DatabaseVersion_Version"; }
        }


        public string DescriptionColumnName
        {
            get { return "Description"; }
        }
    }
}
