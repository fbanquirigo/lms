using System.Configuration;

namespace SaG.Data.Environments
{
    public class ProductionDbEnvironment : IDbEnvironment
    {
        public const string DefaultConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ATM_LOCK;Integrated Security=True";
        private readonly string connectionString = DefaultConnectionString;
        
        public string ConnectionString
        {
            get { return this.connectionString; }
        }

        public bool UpgradeDatabaseOnStart
        {
            get { return true; }
        }

        public ProductionDbEnvironment()
        {
            var conStringEntry = ConfigurationManager.ConnectionStrings["Production.DbConnection"];

            if (conStringEntry == null)
                return;

            if (string.IsNullOrEmpty(conStringEntry.ConnectionString))
                return;

            this.connectionString = conStringEntry.ConnectionString;  
        }

    }
}
