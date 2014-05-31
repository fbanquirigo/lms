using System;

namespace SaG.Services.Contracts
{
    public interface ILockCryptoService
    {
        string DecryptDataDotNet(string sKey, string sVal);

        string DecryptDataStrDotNet(string sKey, string sVal);

        string DecryptDBValue(string value, CryptoType type);

        string EncryptDataDotNet(string sKey, string sVal);

        string EncryptDataStrDotNet(string sKey, string sVal);
        
        string EncryptDBValue(string value, CryptoType type);

        string GenDispBlock(string sDispatcherID, DateTime dtStartDate, DateTime dtEndDate, string sFlags);

        string GenDispKeys(string sDispBlock, string sOwnerKey);

        string GenerateOpCode(int mlCommand, string msOperDate, string msOperHour, string msOperHourLimit,
            string msLockStat, string msPIN, string msTkID, int mlPosition, string msParm, string msKeyDispatcher0,
            string msKeyDispatcher1);

        string GenLockOwnerKeys(string sLockID, string sOwnerKeys);
    }
}