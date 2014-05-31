namespace SaG.Services.Contracts.Verifiers
{
    public interface IOperationResultVerifier
    {
        bool Verify(string operationResult);
    }
}