using SaG.Business.Models;

namespace SaG.Services.Contracts.Verifiers
{
    public interface IOperationHourVerifier
    {
        bool Verify(int hour);

        bool VerifySealOpHour(OperationCode operationCode, Seal seal);
    }
}