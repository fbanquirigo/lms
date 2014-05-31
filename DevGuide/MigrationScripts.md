### Database Migration

#### FluentMigrator
The library **FluentMigrator** is used to handle the database migration functionality. See [https://github.com/schambers/fluentmigrator/wiki](https://github.com/schambers/fluentmigrator/wiki) for more info.

#### Database Migration Module
The **SaG.Data.Migrations** project contains all the database migration scripts and classes.  These scripts will be executed when a databse upgrade id executed upon application start.

#### Version Folder Structure
In the **SaG.Data.Migrations** project the migration scripts/classes are grouped into versions.  A migration script should be under a folder which identifies the product version the script is to be applied.

A folder is used to represent a product version.  The folder name is based on the product version number in the format of **Version-{VersionNumber**.  For example **Version-1.0.0.1** for version 1.0.0.1.  All database migration scripts for this version should be under this folder.


#### Creating a Migration Class / Script
1. In **SaG.Data.Migrations** go to the folder of the version where we want to place our migration script.  Usually we put our script on the latest version.
2. Create a class file.  The filename should be in this format **{Version}{SequenceNo}-{NameOfTheScript}.cs**.  For example **100102-CreateAPIClientsTable.cs**.  The first four digit of the filename identifies the version the script belongs.  In this case the script should belong to version 1.0.0.1 or under the folder **Version-1.0.0.1**.  The following 2 digits represents the scripts execution sequence.  Our example would be executed second on version 1.0.0.1.
3. Inside the newly created cs file create the migration class.  See example below.

```C#
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

```

The migration class should inherit from SaG.Data.Migrations.BaseMigration and should be accessorized by a MigrationAttribute which asks for execution sequence number.  This execution sequence number is the same format of the migration cs file filename.  The **Up** method is executed during database upgrade while the **Down** method is executed upon rollback incase database upgrade fails. See [https://github.com/schambers/fluentmigrator/wiki](https://github.com/schambers/fluentmigrator/wiki) for migration script sytanx.
