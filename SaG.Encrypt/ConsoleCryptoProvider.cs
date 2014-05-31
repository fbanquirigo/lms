using System;

namespace SaG.Encrypt
{
	public class ConsoleCryptoProvider : ICryptoProvider
	{  
		public string DecryptDBValue(string sVal, short lType)
		{
			return EncryptCommandExecutor.DecryptDbValue(sVal, lType);
		}  

		public string EncryptDBValue(string sVal, short lType)
		{
			return EncryptCommandExecutor.EncryptDbValue(sVal, lType);
		}

		public string GenerateOpCode(int mlCommand, string msOperDate, string msOperHour, string msOperHourLimit, string msLockStat, string msPIN, string msTkID, int mlPosition, string msParm, string msKeyDispatcher0, string msKeyDispatcher1)
		{
			return EncryptCommandExecutor.GenerateOpCode(mlCommand, msOperDate, msOperHour, msOperHourLimit, msLockStat,
				msPIN, msTkID, mlPosition, msParm, msKeyDispatcher0, msKeyDispatcher1);
		}

		public string EncryptDataStrDotNet(string sKey, string sVal)
		{
		    return EncryptCommandExecutor.EncryptDataStrDotNet(sKey, sVal);
		}

		public string DecryptDataStrDotNet(string sKey, string sVal)
		{
            return EncryptCommandExecutor.DecryptDataStrDotNet(sKey, sVal);
		}

		public string EncryptDataDotNet(string sKey, string sVal)
		{
		    return EncryptCommandExecutor.EncryptDataDotNet(sKey, sVal);
		}

		public string DecryptDataDotNet(string sKey, string sVal)
		{
            return EncryptCommandExecutor.DecryptDataDotNet(sKey, sVal);
		}

		public string GenDispBlock(string sDispatcherID, DateTime dtStartDate, DateTime dtEndDate, string sFlags)
		{
		    return EncryptCommandExecutor.GenDispBlock(sDispatcherID, dtStartDate, dtEndDate, sFlags);
		}

		public string GenDispKeys(string sDispBlock, string sOwnerKey)
		{
		    return EncryptCommandExecutor.GenDispKeys(sDispBlock, sOwnerKey);
		}

		public string GenLockOwnerKeys(string sLockID, string sOwnerKeys)
		{
		    return EncryptCommandExecutor.GenLockOwnerKeys(sLockID, sOwnerKeys);
		}
	}
}
