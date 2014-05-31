using System;
using System.Collections.Generic;
using NDesk.Options;

namespace SaGEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = null;
            var parameters = new List<string>();
            var optionSet = new OptionSet
                {
                    {"c|command=", "Command To Invoke", x => command = x},
                    {"p|param=", "Parameter", x => parameters.Add(x)}
                };

            List<string> extraParams;
            try
            {
                extraParams = optionSet.Parse(args);
                if (command == null)
                {
                    Console.Write("Unknown Command");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Try `SaGEncrypt --help' for more information.");
                return;
            }

            try
            {
                string result = CommandExecutor.ExecuteCryptoCommand(command, parameters);
                Console.Write(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
