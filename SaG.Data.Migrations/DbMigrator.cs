using System;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;

namespace SaG.Data.Migrations
{
    public class DbMigrator : IDbMigrator
    {
        private readonly IDbEnvironment dbEnvironment;
        private readonly MigrationProcessorFactory migrationProcessorFactory;
        private readonly IMigrationLogger logger;

        public DbMigrator(IDbEnvironment dbEnvironment, MigrationProcessorFactory migrationProcessorFactory,
            IMigrationLogger logger)
        {
            this.dbEnvironment = dbEnvironment;
            this.migrationProcessorFactory = migrationProcessorFactory;
            this.logger = logger;
        }

        public void Migrate()
        {
            this.logger.Info("Database Upgrade Started.");
            RunMigrations(runner => runner.MigrateUp());
            this.logger.Info("Database Upgrade Ended.");
        }

        public void RunMigrations(Action<IMigrationRunner> runnerAction)
        {
            var options = new MigrationOptions { PreviewOnly = false, Timeout = 0 };
            Assembly assembly = Assembly.GetExecutingAssembly();
            var announcer = new TextWriterAnnouncer(s => this.logger.Info(s));
            var migrationContext = new RunnerContext(announcer);
            IMigrationProcessor processor = this.migrationProcessorFactory.Create(this.dbEnvironment.ConnectionString, announcer, options);
            var runner = new MigrationRunner(assembly, migrationContext, processor);
            runnerAction(runner);
        }

        public void MigrateUp(int dbVersion)
        {
            this.logger.Info(string.Format("Upgrade to version {0} started.", dbVersion));
            RunMigrations(runner => runner.MigrateUp(dbVersion));
            this.logger.Info(string.Format("Upgrade to version {0} ended.", dbVersion));
        }

        public void MigrateDown(int dbVersion)
        {
            this.logger.Info(string.Format("Rollback to version {0} started.", dbVersion));
            RunMigrations(runner => runner.MigrateDown(dbVersion));
            this.logger.Info(string.Format("Rollback to version {0} ended.", dbVersion));
        }
    }

    class MigrationOptions : IMigrationProcessorOptions
    {
        public bool PreviewOnly { get; set; }

        public int Timeout { get; set; }

        public string ProviderSwitches
        {
            get { throw new NotImplementedException(); }
        }
    }
}
