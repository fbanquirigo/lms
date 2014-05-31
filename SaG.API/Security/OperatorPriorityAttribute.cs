using System.Net;
using System.Net.Http;
using System.Web.Compilation;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SaG.API.Helpers;
using SaG.Business;
using SaG.Business.Models;

namespace SaG.API.Security
{
    public class OperatorPriorityAttribute : ActionFilterAttribute
    {
        private readonly OperatorPriorityLevel priority;

        public OperatorPriorityAttribute(OperatorPriorityLevel priority)
        {
            this.priority = priority;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments["accessToken"] == null)
            {
                NotAllowed(actionContext); 
                return;
            }

            var tokenObject = actionContext.ActionArguments["accessToken"];
            if (!(tokenObject is APIAccessToken))
            {
                NotAllowed(actionContext);
                return;
            }

            var token = tokenObject as APIAccessToken;
            if (token.Operator.PriorityLevel < (int) this.priority)   
                NotAllowed(actionContext);   
        }

        private static void NotAllowed(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);

            if (!(actionContext.ControllerContext.Controller is ApiControllerBase))
            {
                actionContext.Response.ReasonPhrase = "Operator is not allowed to access this resource.";
                return;
            }

            IResourceProvider resourceProvider =
                (actionContext.ControllerContext.Controller as ApiControllerBase).ResourceProvider;
            actionContext.Response.ReasonPhrase = resourceProvider.ResourceString("Error.OperatorPriorityAccess");     
        }
    }
}