using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Compilation;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SaG.API.Helpers;
using SaG.API.Security;
using SaG.Business;
using SaG.Business.Models;
using SaG.Core;
using SaG.Services.Contracts;

namespace SaG.API.Filters
{
    public class TokenAuthorizationFilter : AuthorizationFilterAttribute
    {
        private const string AUTHENTICATION_TOKEN_HEADER = "Authentication-Token";
        private readonly IResourceProvider resourceProvider;
        private readonly IContainer container;

        public TokenAuthorizationFilter(IResourceProvider resourceProvider, IContainer container)
        {
            this.resourceProvider = resourceProvider;
            this.container = container;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<SkipTokenCheckAttribute>().Any()) 
                return;

            IEnumerable<string> tokenHeaders;
            if (!actionContext.Request.Headers.TryGetValues(AUTHENTICATION_TOKEN_HEADER, out tokenHeaders))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                actionContext.Response.ReasonPhrase = this.resourceProvider.ResourceString("Error.InvalidTokenHeader");
                return;
            }

            string accessToken = tokenHeaders.FirstOrDefault();
            var authenticationService = this.container.GetInstance<IAuthenticationService>();
            if (authenticationService.ValidAccessToken(accessToken))
            {
                APIAccessToken token = authenticationService.GetAccessToken(accessToken);
                actionContext.ActionArguments.Add("accessToken", token);

                var tokenContext = this.container.GetInstance<IAccessTokenContext>();
                if (tokenContext is AccessTokenContext)    
                    (tokenContext as AccessTokenContext).AccessToken = token.AccessToken;  

                var securityContext = this.container.GetInstance<SecurityContext>();
                if (securityContext != null)
                    securityContext.User = token.Operator;

                var consumerContext = this.container.GetInstance<IConsumerContext>();
                if (consumerContext is ConsumerContext)
                {
                    (consumerContext as ConsumerContext).Consumer = 
                        new Consumer(token.Client.ApplicationName, token.Client.ConsumerKey);
                }

                var operatorContext = this.container.GetInstance<IOperatorContext>();
                if (operatorContext is OperatorContext)
                {
                    (operatorContext as OperatorContext).Operator = 
                        new OperatorUser(token.Operator.AccessorId, token.Operator.Login, (OperatorPriorityLevel) token.Operator.PriorityLevel);
                }
                return;
            }                                                                                                      
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            actionContext.Response.ReasonPhrase = this.resourceProvider.ResourceString("Error.InvalidExpiredToken");
        }
    }
}