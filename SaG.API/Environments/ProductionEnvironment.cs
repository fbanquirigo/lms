using System;
using SaG.Data;
using SaG.Data.Environments;
using SaG.Encrypt;

namespace SaG.API.Environments
{
    public class ProductionEnvironment  : IApplicationEnvironment
    {
        private readonly IDbEnvironment dbEnvironment;

        public string Name
        {
            get { return "Production"; }
        }

        public IDbEnvironment DbEnvironment
        {
            get { return this.dbEnvironment; }
        }

        public ProductionEnvironment(ProductionDbEnvironment dbEnvironment)
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