namespace SaG.Services.Contracts
{
    public interface IOperationCodeService
    {
        int GenerateOpenLockACode(string atmId, string userId,
            string touchkeyId, string date, int hour, int timeBlock, int lockStatus);

        int GenerateOpenLockBCode(string lockId, string userId,
            string touchkeyId, string date, int hour, int timeBlock, int lockStatus);

        int GenerateOpenLockCCode(string atmId, string middleName,
            string touchkeyId, string date, int hour, int timeBlock, int lockStatus);

        int GenerateOpenLockNoTouchKeyA(string atmId, string userId,
            string date, int hour, int timeBlock);

        int GenerateOpenLockNow1A(string atmId, string userId);

        int GenerateOpenLockNow2A(string atmId, string userId);

        int GenerateOpenLockNow1B(string lockId, string userId);
    }
}