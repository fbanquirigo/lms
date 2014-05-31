using System;
using System.Diagnostics;
using System.IO;

namespace SaG.Encrypt
{
    sealed class EncryptCommandExecutor
    {  
        public static string GenerateOpCode(int mlCommand, string msOperDate, string msOperHour,
            string msOperHourLimit,
            string msLockStat, string msPIN, string msTkID, int mlPosition, string msParm,
            string msKeyDispatcher0, string msKeyDispatcher1)
        {
            var arguments =
                string.Format("-c {0} -p {1} -p {2} -p {3} -p {4} -p {5} -p {6} -p {7} -p {8} -p {9} -p {10} -p {11}",
                "generateopcode", mlCommand, msOperDate, msOperHour, msOperHourLimit, msLockStat, msPIN, msTkID, mlPosition, msParm, msKeyDispatcher0, msKeyDispatcher1);
            return ExecuteCommand(arguments);
        }

        public static string EncryptDbValue(string value, short type)
        {
            var arguments = string.Format("-c {0} -p {1} -p {2}", "encryptdbvalue", value, type);
            return ExecuteCommand(arguments);
        }  

        public static string DecryptDbValue(string value, short type)
        {
            var arguments = string.Format("-c {0} -p {1} -p {2}", "decryptdbvalue", value, type);
            return ExecuteCommand(arguments);
        }

        public static string EncryptDataStrDotNet(string sKey, string sVal)
        {
            var arguments = string.Format("-c {0} -p {1} -p {2}", "encryptdatastrdotnet", sKey, sVal);
            return ExecuteCommand(arguments);    
        }

        public static string DecryptDataStrDotNet(string sKey, string sVal)
        {
            var arguments = string.Format("-c {0} -p {1} -p {2}", "decryptdatastrdotnet", sKey, sVal);
            return ExecuteCommand(arguments);
        }

        public static string EncryptDataDotNet(string sKey, string sVal)
        {
            var arguments = string.Format("-c {0} -p {1} -p {2}", "encryptdatadotnet", sKey, sVal);
            return ExecuteCommand(arguments); 
        }

        public static string DecryptDataDotNet(string sKey, string sVal)
        {
            var arguments = string.Format("-c {0} -p {1} -p {2}", "decryptdatadotnet", sKey, sVal);
            return ExecuteCommand(arguments);
        }

        public static string GenDispBlock(string sDispatcherID, DateTime dtStartDate, DateTime dtEndDate, string sFlags)
        {
            var arguments = string.Format("-c {0} -p {1} -p {2} -p {3} -p {4}", "gendispblock", sDispatcherID, dtStartDate.ToString("d"),
                dtEndDate.ToString("d"), sFlags);
            return ExecuteCommand(arguments);
        }

        public static string GenDispKeys(string sDispBlock, string sOwnerKey)
        {
            var arguments = string.Format("-c {0} -p {1} -p {2}", "gendispkeys", sDispBlock, sOwnerKey);
            return ExecuteCommand(arguments);     
        }

        public static string GenLockOwnerKeys(string sLockID, string sOwnerKeys)
        {
            var arguments = string.Format("-c {0} -p {1} -p {2}", "genlockownerkeys", sLockID, sOwnerKeys);
            return ExecuteCommand(arguments);  
        }

        private static string ExecuteCommand(string arguments)
        {
            var process = new Process();
            var exeLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaGEncrypt.exe");
            if(!File.Exists(exeLocation))
                exeLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin\\SaGEncrypt.exe");
            process.StartInfo.FileName = exeLocation;
            process.StartInfo.Arguments = arguments;    
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;  
            process.Start();    
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
    }
}
