using System;

namespace SaG.Services.Contracts
{
    public interface IEventLogService
    {
        string LogUnhandledException(object request, Exception exception);
    }
}