using System;
using System.Collections.Generic;
using EncryptActiveX;

namespace SaGEncrypt
{
    sealed class CommandExecutor
    {
        public static string ExecuteCryptoCommand(string command, IList<string> parameters)
        {
            switch (command.ToLower())
            {   
                case "generateopcode":
                    return ExecuteGenerateOpCode(parameters);
                case "encryptdbvalue":
                    return ExecuteEncryptDbValue(parameters);
                case "decryptdbvalue":
                    return ExecuteDecryptDbValue(parameters);
                case "encryptdatastrdotnet":
                    return ExecuteEncryptDataStrDotNet(parameters);
                case "decryptdatastrdotnet":
                    return ExecuteDecryptDataStrDotNet(parameters);
                case "encryptdatadotnet":
                    return ExecuteEncryptDataDotNet(parameters);
                case "decryptdatadotnet":
                    return ExecuteDecryptDataDotNet(parameters);
                case "gendispblock":
                    return ExecuteGenDispBlock(parameters);
                case "gendispkeys":
                    return ExecuteGenDispKeys(parameters);
                case "genlockownerkeys":
                    return ExecuteGenLockOwnerKeys(parameters);
            }
            throw new Exception("Unknown Command.");
        }

        private static string ExecuteGenerateOpCode(IList<string> parameters)
        {
            string param1 = parameters[0];
            string param2 = parameters[1];
            string param3 = parameters[2];
            string param4 = parameters[3];
            string param5 = parameters[4];
            string param6 = parameters[5];
            string param7 = parameters[6];
            string param8 = parameters[7];
            string param9 = parameters[8];
            string param10 = parameters[9];
            string param11 = parameters[10];

            int nlCommand = 0;
            int.TryParse(param1, out nlCommand);

            int mlPosition = 0;
            int.TryParse(param8, out mlPosition);

            var encrypt = new clsEncrypt();
            return encrypt.GenerateOpCode(
                nlCommand,
                param2,
                param3,
                param4,
                param5,
                param6,
                param7,
                mlPosition,
                param9,
                param10,
                param11);
        }

        private static string ExecuteDecryptDbValue(IList<string> parameters)
        {
            string param1 = parameters[0];
            string param2 = parameters[1];
            short type = short.Parse(param2);
            var encrypt = new clsEncrypt();
            return encrypt.DecryptDBValue(param1, type);
        }

        private static string ExecuteEncryptDbValue(IList<string> parameters)
        {
            string param1 = parameters[0];
            string param2 = parameters[1];
            short type = short.Parse(param2);
            var encrypt = new clsEncrypt();
            return encrypt.EncryptDBValue(param1, type);
        }

        private static string ExecuteEncryptDataStrDotNet(IList<string> parameters)
        {  
            string param1 = parameters[0];
            string param2 = parameters[1];
            var encrypt = new clsEncrypt();
            return encrypt.EncryptDataStrDotNet(param1, param2);
        }

        private static string ExecuteDecryptDataStrDotNet(IList<string> parameters)
        {
            string param1 = parameters[0];
            string param2 = parameters[1];
            var encrypt = new clsEncrypt();
            return encrypt.DecryptDataStrDotNet(param1, param2);
        }

        private static string ExecuteEncryptDataDotNet(IList<string> parameters)
        {
            string param1 = parameters[0];
            string param2 = parameters[1];
            var encrypt = new clsEncrypt();
            return encrypt.EncryptDataDotNet(param1, param2);
        }

        private static string ExecuteDecryptDataDotNet(IList<string> parameters)
        {
            string param1 = parameters[0];
            string param2 = parameters[1];
            var encrypt = new clsEncrypt();
            return encrypt.DecryptDataDotNet(param1, param2);
        }

        private static string ExecuteGenDispBlock(IList<string> parameters)
        {
            string param1 = parameters[0];
            string param2 = parameters[1];
            string param3 = parameters[2];
            string param4 = parameters[3];

            DateTime startDate = DateTime.Parse(param2);
            DateTime endDate = DateTime.Parse(param3);

            var encrypt = new clsEncrypt();
            return encrypt.GenDispBlock(param1, startDate, endDate, param4);
        }

        private static string ExecuteGenDispKeys(IList<string> parameters)
        {
            string param1 = parameters[0];
            string param2 = parameters[1];
            var encrypt = new clsEncrypt();
            return encrypt.GenDispKeys(param1, param2);
        }

        private static string ExecuteGenLockOwnerKeys(IList<string> parameters)
        {
            string param1 = parameters[0];
            string param2 = parameters[1];
            var encrypt = new clsEncrypt();
            return encrypt.GenLockOwnerKeys(param1, param2);
        }   
    }
}
