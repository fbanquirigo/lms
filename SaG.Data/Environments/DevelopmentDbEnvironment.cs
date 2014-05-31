using System.Configuration;

namespace SaG.Data.Environments
{
    public class DevelopmentDbEnvironment : IDbEnvironment
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

        public DevelopmentDbEnvironment()
        {
            var conStringEntry = ConfigurationManager.ConnectionStrings["Dev.DbConnection"];
            
            if (conStringEntry == null)
                return;

            if (string.IsNullOrEmpty(conStringEntry.ConnectionString))
                return;

            this.connectionString = conStringEntry.ConnectionString;    
        } 
    }
}
