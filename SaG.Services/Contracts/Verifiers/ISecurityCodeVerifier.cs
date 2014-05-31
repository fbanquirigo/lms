using SaG.Business.Models;
using SaG.Business.Models.Views;

namespace SaG.Services.Contracts.Verifiers
{
    public interface ISecurityCodeVerifier
    {
        bool Verify(OperationCodeDetailView opCodeDet, Seal seal, out Seal sealResult);
    }
}
