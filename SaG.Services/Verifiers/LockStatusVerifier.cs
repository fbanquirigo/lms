using SaG.Services.Contracts.Verifiers;

namespace SaG.Services.Verifiers
{
    public class LockStatusVerifier : ILockStatusVerifier
    {
        public bool Verify(int lockStatus, int command)
        {
            if (command == 16 && (lockStatus > 7 || lockStatus < 4))   
                return false;     
            return !(lockStatus > 3);
        }
    }
}
