using SaG.Business.Models;

namespace SaG.Services.Contracts.Verifiers
{
    public interface ISealVerifier
    {
        bool Verify(string operationResult, out Seal seal);
    }
}