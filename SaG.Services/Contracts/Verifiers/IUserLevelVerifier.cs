namespace SaG.Services.Contracts.Verifiers
{
    public interface IUserLevelVerifier
    {
        bool Verify(string typeKey, string userType, bool status);
    }
}