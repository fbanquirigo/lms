using SaG.Business;
using SaG.Business.Models;
using SaG.Business.Models.Views;

namespace SaG.Services.Contracts.Verifiers
{
    public interface IOperationCodeVerifier
    {
        bool Verify(int opCode, int atmEntity, out OperationCode operationCode);

        bool VerifySealA(int accessorId, string locationId, out OperationCodeDetailView operationCode);

        bool VerifyClose(OperationCode operationCode, UserType userType);
    }
}