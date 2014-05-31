using System.Configuration;

namespace SaG.Data.Environments
{
    public class StagingDbEnvironment : IDbEnvironment
    {
        private readonly string connectionString = ProductionDbEnvironment.DefaultConnectionString;

        public string ConnectionString
        {
            get { return this.connectionString; }
        }

        public bool UpgradeDatabaseOnStart
        {
            get { return true; }
        }

        public StagingDbEnvironment()
        {
            var conStringEntry = ConfigurationManager.ConnectionStrings["Staging.DbConnection"];

            if (conStringEntry == null)
                return;

            if (string.IsNullOrEmpty(conStringEntry.ConnectionString))
                return;

            this.connectionString = conStringEntry.ConnectionString;    
        }
    }
}
