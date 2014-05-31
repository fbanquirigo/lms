namespace SaG.Services.Contracts.Verifiers
{
    public interface ITimeBlockVerifier
    {
        bool Verify(int hour);
    }
}