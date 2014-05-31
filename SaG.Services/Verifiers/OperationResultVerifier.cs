using SaG.Services.Contracts.Verifiers;

namespace SaG.Services.Verifiers
{
    public class OperationResultVerifier : IOperationResultVerifier
    {
        public bool Verify(string operationResult)
        {
            return operationResult == "0" || operationResult == "F" || operationResult == "Z";
        }
    }
}
