using System;
using System.Configuration;
using System.IO;
using log4net.Config;

namespace SaG.Core.Log4Net
{
    public class LogConfig : IInitializer
    {
        public void Initialize()
        {
            var configFile = ConfigurationManager.AppSettings["log4NetConfig"];
            var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFile);
            var fileInfo = new FileInfo(configFilePath);
            XmlConfigurator.Configure(fileInfo);
        }
    }
}
