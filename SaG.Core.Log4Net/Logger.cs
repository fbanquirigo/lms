using System;
using System.Configuration;
using System.IO;
using log4net;
using log4net.Config;
using SaG.Core.Logging;

namespace SaG.Core.Log4Net
{
    public class Logger : ILogger
    {
        private readonly ILog log;

        public Logger(ILog log)
        {
            this.log = log;
        }

        public void Debug(object message)
        {
            this.log.Debug(message);
        }

        public void Info(object message)
        {
            this.log.Info(message);
        }

        public void Warn(object message)
        {
            this.log.Warn(message);
        }

        public void Error(object message)
        {
            this.log.Error(message);
        }

        public void Fatal(object message)
        {
            this.log.Fatal(message);
        }

        public void Debug(object message, Exception exception)
        {
            this.log.Debug(message, exception);
        }

        public void Info(object message, Exception exception)
        {
            this.log.Info(message, exception);
        }

        public void Warn(object message, Exception exception)
        {
            this.log.Warn(message, exception);
        }

        public void Error(object message, Exception exception)
        {
            this.log.Error(message, exception);
        }

        public void Fatal(object message, Exception exception)
        {
            this.log.Fatal(message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            this.log.DebugFormat(format, args);
        }

        public void InfoFormat(string format, params object[] args)
        {
            this.log.InfoFormat(format, args);
        }

        public void WarnFormat(string format, params object[] args)
        {
            this.log.WarnFormat(format, args);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            this.log.ErrorFormat(format, args);
        }

        public void FatalFormat(string format, params object[] args)
        {
            this.log.FatalFormat(format, args);
        }

        public static ILogger GetLogger(string loggerType)
        {
            return new Logger(GetLog(loggerType));
        }

        public static ILog GetLog(string loggerType)
        {
            return LogManager.GetLogger(loggerType);
        }
    }
}