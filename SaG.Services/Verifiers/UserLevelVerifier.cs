using SaG.Services.Contracts.Verifiers;

namespace SaG.Services.Verifiers
{
    public class UserLevelVerifier : IUserLevelVerifier
    {
        public bool Verify(string typeKey, string userType, bool status)
        {
            if (typeKey.ToLower() != "user")
                return false;
            return !(userType.ToLower() == "single" && status);
        }
    }
}
