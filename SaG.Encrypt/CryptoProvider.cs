using System;
using EncryptActiveX;

namespace SaG.Encrypt
{
    public class CryptoProvider : ICryptoProvider
    {
        private readonly clsEncrypt crypto;

        public CryptoProvider()
        {
            this.crypto = new clsEncrypt();    
        }

        public string GenerateOpCode(int mlCommand, string msOperDate, string msOperHour, string msOperHourLimit, string msLockStat, string msPIN, string msTkID, int mlPosition, string msParm, string msKeyDispatcher0, string msKeyDispatcher1)
        {
            return this.crypto.GenerateOpCode(mlCommand, msOperDate, msOperHour, msOperHourLimit, msLockStat, msPIN, msTkID,
                mlPosition, msParm, msKeyDispatcher0, msKeyDispatcher1);
        }

        public string EncryptDBValue(string sVal, short lType)
        {
            return this.crypto.EncryptDBValue(sVal, lType);
        }

        public string DecryptDBValue(string sVal, short lType)
        {
            return this.crypto.DecryptDBValue(sVal, lType);
        }

        public string EncryptDataStrDotNet(string sKey, string sVal)
        {
            return this.crypto.EncryptDataStrDotNet(sKey, sVal);
        }

        public string DecryptDataStrDotNet(string sKey, string sVal)
        {
            return this.crypto.DecryptDataStrDotNet(sKey, sVal);
        }

        public string EncryptDataDotNet(string sKey, string sVal)
        {
            return this.crypto.EncryptDataDotNet(sKey, sVal);
        }

        public string DecryptDataDotNet(string sKey, string sVal)
        {
            return this.crypto.DecryptDataDotNet(sKey, sVal);
        }

        public string GenDispBlock(string sDispatcherID, DateTime dtStartDate, DateTime dtEndDate, string sFlags)
        {
            return this.crypto.GenDispBlock(sDispatcherID, dtStartDate, dtEndDate, sFlags);
        }

        public string GenDispKeys(string sDispBlock, string sOwnerKey)
        {
            return this.crypto.GenDispKeys(sDispBlock, sOwnerKey);
        }

        public string GenLockOwnerKeys(string sLockID, string sOwnerKeys)
        {
            return this.crypto.GenLockOwnerKeys(sLockID, sOwnerKeys);
        }
    }
}
