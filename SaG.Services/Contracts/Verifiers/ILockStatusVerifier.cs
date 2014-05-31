namespace SaG.Services.Contracts.Verifiers
{
    public interface ILockStatusVerifier
    {
        bool Verify(int lockStatus, int command);
    }
}