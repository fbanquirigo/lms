using SaG.Encrypt;
using SaG.Services.Contracts;

namespace SaG.Services
{  
    public class LockCryptoService : ILockCryptoService
    {
        private readonly ICryptoProvider crypto;

        public LockCryptoService(ICryptoProvider crypto)
        {
            this.crypto = crypto;
        }

        public string DecryptDataDotNet(string sKey, string sVal)
        {
            return this.crypto.DecryptDataDotNet(sKey, sVal);
        }

        public string DecryptDataStrDotNet(string sKey, string sVal)
        {
            return this.crypto.DecryptDataStrDotNet(sKey, sVal);
        }

        public string DecryptDBValue(string value, CryptoType type)
        {
            return this.crypto.DecryptDBValue(value, (short) type);
        }

        public string EncryptDataDotNet(string sKey, string sVal)
        {
            return this.crypto.EncryptDataDotNet(sKey, sVal);
        }

        public string EncryptDataStrDotNet(string sKey, string sVal)
        {
            return this.crypto.EncryptDataStrDotNet(sKey, sVal);
        }

        public string EncryptDBValue(string value, CryptoType type)
        {
            return this.crypto.EncryptDBValue(value, (short) type);
        }

        public string GenDispBlock(string sDispatcherID, System.DateTime dtStartDate, System.DateTime dtEndDate, string sFlags)
        {
            return this.crypto.GenDispBlock(sDispatcherID, dtStartDate, dtEndDate, sFlags);
        }

        public string GenDispKeys(string sDispBlock, string sOwnerKey)
        {
            return this.crypto.GenDispKeys(sDispBlock, sOwnerKey);
        }  

        public string GenerateOpCode(int mlCommand, string msOperDate, string msOperHour, string msOperHourLimit, string msLockStat, string msPIN, string msTkID, int mlPosition, string msParm, string msKeyDispatcher0, string msKeyDispatcher1)
        {
            return this.crypto.GenerateOpCode(mlCommand, msOperDate, msOperHour, msOperHourLimit, msLockStat, msPIN, msTkID,
                mlPosition, msParm, msKeyDispatcher0, msKeyDispatcher1);
        }

        public string GenLockOwnerKeys(string sLockID, string sOwnerKeys)
        {
            return this.crypto.GenLockOwnerKeys(sLockID, sOwnerKeys);
        }
    }
}
