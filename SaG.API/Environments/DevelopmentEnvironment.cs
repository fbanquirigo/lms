using System;
using SaG.Data;
using SaG.Data.Environments;
using SaG.Encrypt;

namespace SaG.API.Environments
{
    public class DevelopmentEnvironment : IApplicationEnvironment
    {
        private readonly IDbEnvironment dbEnvironment;

        public string Name
        {
            get { return "Development"; }
        }

        public IDbEnvironment DbEnvironment
        {
            get { return this.dbEnvironment; }
        }

        public DevelopmentEnvironment(DevelopmentDbEnvironment dbEnvironment)
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