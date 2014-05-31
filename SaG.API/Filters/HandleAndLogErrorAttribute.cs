using System;
using System.Web;
using System.Web.Mvc;
using Glimpse.Core.Extensibility;
using SaG.Core;

namespace SaG.API.Filters
{
    public class HandleAndLogErrorAttribute : HandleErrorAttribute
    {
        private readonly IContainer container;

        public HandleAndLogErrorAttribute(IContainer container)
        {
            this.container = container;
        }

        public override void OnException(ExceptionContext filterContext)
        {   
            Exception exception = filterContext.Exception;   
            var httpException = exception as HttpException;
            if (httpException == null)
            {    
                base.OnException(filterContext);
                return;
            }

            int httpCode = httpException.GetHttpCode();
            if (httpCode != 500)
            {    
                base.OnException(filterContext);
                return;
            }    
            var logger = this.container.GetInstance<ILogger>();
            logger.Fatal(string.Format("{0} - Unhandled Error", DateTime.Now), exception);
            logger.Fatal(string.Format("{0} - Unhandled Error - InnerException", DateTime.Now), exception.InnerException);
            base.OnException(filterContext);
        }
    }
}