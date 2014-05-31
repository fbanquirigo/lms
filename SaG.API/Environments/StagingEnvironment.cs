using System;
using SaG.Data;
using SaG.Data.Environments;
using SaG.Encrypt;

namespace SaG.API.Environments
{
    public class StagingEnvironment  : IApplicationEnvironment
    {
        private readonly IDbEnvironment dbEnvironment;

        public string Name
        {
            get { return "Staging"; }
        }

        public IDbEnvironment DbEnvironment
        {
            get { return this.dbEnvironment; }
        }

        public StagingEnvironment(StagingDbEnvironment dbEnvironment)
        {
            this.dbEnvironment = dbEnvironment;
        }

        public Type CryptoProviderType
        {
            get
            {
                return typeof(ConsoleCryptoProvider);
            }
        }
    }
}