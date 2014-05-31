using log4net;
using SaG.Core.Log4Net;

namespace SaG.Data.Migrations
{
    public class MigrationLogger : Logger, IMigrationLogger
    {
        public MigrationLogger(ILog log)
            : base(log)
        {
        }

        internal static IMigrationLogger GetLogger()
        {
            return new MigrationLogger(GetLog("migrationLogger"));
        }
    }
}
