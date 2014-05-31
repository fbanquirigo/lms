### Initialization Class / Module

An initialization class could be in any project or assembly of the application.  The **Initialize()** method of these classes will be executed on application start.  The typical use of the initializer class is configuration functionality upon application start.  See example below.

```C#
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
```

An initializer class should implement the interface **SaG.Core.Initializer**, the **Initialize()** method is required to be implemented.  The example above is taken from the project **SaG.Core.Log4Net**, on application start it will be executed and will configure the logging function and log4net.
