using System.Configuration;

namespace SaG.Data.Environments
{
    public class LocalDbEnvironment : IDbEnvironment
    {
        private readonly string connectionString = ProductionDbEnvironment.DefaultConnectionString;

        public string ConnectionString
        {
            get { return this.connectionString; }
        }

        public bool UpgradeDatabaseOnStart
        {
            get { return false; }
        }

        public LocalDbEnvironment()
        {
            var conStringEntry = ConfigurationManager.ConnectionStrings["Local.DbConnection"];

            if (conStringEntry == null)
                return;

            if (string.IsNullOrEmpty(conStringEntry.ConnectionString))
                return;

            this.connectionString = conStringEntry.ConnectionString;    
        }
    }
}
