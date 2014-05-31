using System;
using Newtonsoft.Json;
using SaG.Business;
using SaG.Business.Models;
using SaG.Data;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class EventLogService : IEventLogService
    {
        private readonly IRepository<ErrorLog> errorLogRepository;
        private readonly IClientContext clientContext;

        public EventLogService(IRepository<ErrorLog> errorLogRepository, IClientContext clientContext)
        {
            this.clientContext = clientContext;
            this.errorLogRepository = errorLogRepository;
        }

        public string LogUnhandledException(object request, Exception exception)
        {
            var exceptionXml = new ExceptionXElement(exception);
            var errorLog = new ErrorLog
            {
                ErrorId = Guid.NewGuid().ToString(),
                ConsumerKey = this.clientContext.Consumer.ConsumerId,
                Request = JsonConvert.SerializeObject(request),
                Exception = exceptionXml.ToString(),
                DateOccured = DateTime.UtcNow,
                User = this.clientContext.Operator.LoginName
            };
            this.errorLogRepository.Save(errorLog);
            return errorLog.ErrorId;
        }    
    }
}
