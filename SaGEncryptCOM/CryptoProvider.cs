using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.EnterpriseServices;

namespace SaGEncryptCOM
{
    [Transaction(TransactionOption.RequiresNew)]
    public class CryptoProvider : ServicedComponent
    {

        public string MakeOwnerKeys(ref string sLockID, ref string sKey)
        {
            return CryptoProviderWrapper.MakeOwnerKeys(ref sLockID, ref sKey);
        }

        public string MakeDispKeys(ref string sDispBlock, ref string sKey)
        {
            return CryptoProviderWrapper.MakeDispKeys(ref sDispBlock, ref sKey);
        }

        public string MakeDispBlock(ref string sDispID, ref string sStartDate, 
            ref string sEndDate, ref string sFlags, ref string sDispBlock)
        {
            return CryptoProviderWrapper.MakeDispBlock(ref sDispID, ref sStartDate, ref sEndDate, ref sFlags, ref sDispBlock);
        }

        public string MakeReqBlock(int nCommand, ref string sStartDate, ref string sLockStatus,
            ref string sOpCode, ref string sTouchKeyID, ref string sPIN, ref string sParm,
            ref string sReqBlock)
        {
            return CryptoProviderWrapper.MakeReqBlock(nCommand, ref sStartDate, ref sLockStatus,
                ref sOpCode, ref sTouchKeyID, ref sPIN, ref sParm, ref sReqBlock);
        }

        public string AccessOpCode(ref string sReqBlock, ref string sKey, 
            ref string sOpCode, ref string sAccessOpCode)
        {
            return CryptoProviderWrapper.AccessOpCode(ref sReqBlock, ref sKey, ref sOpCode, ref sAccessOpCode);
        }

        public string DecryptDataStr(ref string sKey, ref string sData)
        {
            return CryptoProviderWrapper.DecryptDataStr(ref sKey, ref sData);
        }

        public string EncryptDataStr(ref string sKey, ref string sData)
        {
            return CryptoProviderWrapper.EncryptDataStr(ref sKey, ref sData);
        }

        public string DecryptData(ref string sKey, ref string sData)
        {
            return CryptoProviderWrapper.DecryptData(ref sKey, ref sData);
        }

        public string EncryptData(ref string sKey, ref string sData)
        {
            return CryptoProviderWrapper.EncryptData(ref sKey, ref sData);
        }
    }
}
