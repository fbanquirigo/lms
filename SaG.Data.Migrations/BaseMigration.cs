using System;
using FluentMigrator;

namespace SaG.Data.Migrations
{
    public abstract class BaseMigration : Migration
    {
        protected void WriteVersion(IProductVersion version)
        {
            Insert.IntoTable("ProductVersion").Row(new
            {
                version.Version,
                version.Name,
                AppliedOn = DateTime.UtcNow
            });
        }

        public void RemoveVersion(IProductVersion version)
        {
            Delete.FromTable("ProductVersion").Row(new
            {
                version.Version
            });
        }
    }
}
