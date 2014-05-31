using System;

namespace SaG.Encrypt
{
    public interface ICryptoProvider
    {
        string GenerateOpCode(int mlCommand, string msOperDate, string msOperHour, string msOperHourLimit,
            string msLockStat, string msPIN, string msTkID, int mlPosition, string msParm,
            string msKeyDispatcher0, string msKeyDispatcher1);

        string EncryptDBValue(string sVal, short lType);

        string DecryptDBValue(string sVal, short lType);

        string EncryptDataStrDotNet(string sKey, string sVal);

        string DecryptDataStrDotNet(string sKey, string sVal);

        string EncryptDataDotNet(string sKey, string sVal);

        string DecryptDataDotNet(string sKey, string sVal);

        string GenDispBlock(string sDispatcherID, DateTime dtStartDate, DateTime dtEndDate, string sFlags);

        string GenDispKeys(string sDispBlock, string sOwnerKey);

        string GenLockOwnerKeys(string sLockID, string sOwnerKeys);
    }
}