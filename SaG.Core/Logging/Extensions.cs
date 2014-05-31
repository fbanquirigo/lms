using System;

namespace SaG.Core.Logging
{
    public static class Extensions
    {
        public static void DebugIf(this ILogger logger, bool condition, object message)
        {
            if(condition)
                logger.Debug(message);
        }

        public static void InfoIf(this ILogger logger, bool condition, object message)
        {
            if(condition)
                logger.Info(message);
        }

        public static void WarnIf(this ILogger logger, bool condition, object message)
        {
            if (condition)
                logger.Warn(message);
        }

        public static void ErrorIf(this ILogger logger, bool condition, object message)
        {
            if (condition)
                logger.Error(message);
        }

        public static void FatalIf(this ILogger logger, bool condition, object message)
        {
            if (condition)
                logger.Fatal(message);
        }

        public static void DebugIf(this ILogger logger, bool condition, object message, Exception exception)
        {
            if(condition)
                logger.Debug(message, exception);
        }

        public static void InfoIf(this ILogger logger, bool condition, object message, Exception exception)
        {
            if (condition)
                logger.Info(message, exception);
        }

        public static void WarnIf(this ILogger logger, bool condition, object message, Exception exception)
        {
            if (condition)
                logger.Warn(message, exception);
        }

        public static void ErrorIf(this ILogger logger, bool condition, object message, Exception exception)
        {
            if (condition)
                logger.Error(message, exception);
        }

        public static void FatalIf(this ILogger logger, bool condition, object message, Exception exception)
        {
            if (condition)
                logger.Fatal(message, exception);
        }

        public static void DebugFormatIf(this ILogger logger, bool condition, string format, params object[] args)
        {
            if(condition)
                logger.DebugFormat(format, args);
        }

        public static void InfoFormatIf(this ILogger logger, bool condition, string format, params object[] args)
        {
            if (condition)
                logger.InfoFormat(format, args);
        }

        public static void WarnFormatIf(this ILogger logger, bool condition, string format, params object[] args)
        {
            if (condition)
                logger.WarnFormat(format, args);
        }

        public static void ErrorFormatIf(this ILogger logger, bool condition, string format, params object[] args)
        {
            if (condition)
                logger.ErrorFormat(format, args);
        }

        public static void FatalFormatIf(this ILogger logger, bool condition, string format, params object[] args)
        {
            if (condition)
                logger.FatalFormat(format, args);
        }
    }
}
