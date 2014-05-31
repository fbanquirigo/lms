using System;
using SaG.Data;

namespace SaG.API.Environments
{
    public interface IApplicationEnvironment
    {
        string Name { get; } 

        IDbEnvironment DbEnvironment { get; }

        Type CryptoProviderType { get; }
    }
}