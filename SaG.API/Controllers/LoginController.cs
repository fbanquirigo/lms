using System.Web.Mvc;
using SaG.API.Models;
using SaG.API.Security;
using SaG.Business;
using SaG.Business.Models;
using SaG.Services.Contracts;

namespace SaG.API.Controllers
{
    /// <summary>
    /// LoginController
    /// </summary>
    public class LoginController : ControllerBase
    {
        private readonly IAPIClientService apiClientService;
        private readonly IOperatorService operatorService;
        private readonly IAuthenticationService authenticationService;
        private readonly IConsumerContext consumerContext;
        private readonly IOperatorContext operatorContext;
        private readonly IAuditTrailService auditTrail;
        private readonly IAccessorService accessorService;
        private readonly ISessionStateProvider session;

        /// <summary>
        /// Creates a new instance of LoginController
        /// </summary>
        public LoginController(IAPIClientService apiClientService, IOperatorService operatorService,
            IAuthenticationService authenticationService, IConsumerContext consumerContext,
            IOperatorContext operatorContext, IAuditTrailService auditTrail, IAccessorService accessorService, ISessionStateProvider session)
        {
            this.apiClientService = apiClientService;
            this.operatorService = operatorService;
            this.authenticationService = authenticationService;
            this.consumerContext = consumerContext;
            this.operatorContext = operatorContext;
            this.auditTrail = auditTrail;
            this.accessorService = accessorService;
            this.session = session;
        }

        /// <summary>
        /// Open auth login route
        /// </summary>
        [Route("login/oauth/authorize")]
        [RequireHttpsInProduction]
        public ActionResult OAuthLogin(string client_id, string redirect_uri, string state)
        {
            if (string.IsNullOrEmpty(client_id))
                return new HttpNotFoundResult();

            if (string.IsNullOrEmpty(redirect_uri))
                return new HttpNotFoundResult();

            if (!this.apiClientService.ValidClient(client_id))
                return new HttpNotFoundResult();

            var oauthLoginClient = new OAuthLoginClient
            {
                ClientId = client_id,
                CallbackUri = redirect_uri,
                State = state
            };
            return View("OAuthLogin", oauthLoginClient);
        }

        /// <summary>
        /// Login authentication route
        /// </summary>
        [Route("login/oauth/authenticate")]
        [RequireHttpsInProduction]
        [ValidateAntiForgeryToken]
        public ActionResult Authenticate(OAuthLoginClient model)
        {
            if (!this.apiClientService.ValidClient(model.ClientId))
                return new HttpNotFoundResult();

            if (string.IsNullOrEmpty(model.CallbackUri))
                return new HttpNotFoundResult();

            if (!ModelState.IsValid)
            {
                TempData["ErrorString"] = "Login.InvalidUsernameOrPassword";
                return RedirectToAction("OAuthLogin",
                     new { client_id = model.ClientId, redirect_uri = model.CallbackUri, state = model.State });
            }

            bool validLogin = this.operatorService.ValidOperatorLogin(model.Username, model.Password);
            if (!validLogin)
            {
                TempData["ErrorString"] = "Login.InvalidUsernameOrPassword";
                return RedirectToAction("OAuthLogin",
                    new { client_id = model.ClientId, redirect_uri = model.CallbackUri, state = model.State });
            }

            APIClient client = this.apiClientService.GetClient(model.ClientId);
            Operator user = this.operatorService.GetOperator(model.Username);
            this.session["client"] = client;
            this.session["user"] = user;
            SetContextValues(client, user);
            Accessor accessor = this.accessorService.GetAccessor(user.AccessorId);
            this.auditTrail.Audit(AuditType.SignOn, "Operation Code", user.Login, 
                string.Format("{0}, {1}", accessor.LastName, accessor.FirstName));

            var redirectUri = string.Format("{0}?auth_code={1}&state={2}", model.CallbackUri,
                this.authenticationService.GenerateAuthCode(client, user), model.State);
            return Redirect(redirectUri);
        }

        private void SetContextValues(APIClient client, Operator user)
        {
            if (this.consumerContext is ConsumerContext)
                (this.consumerContext as ConsumerContext).Consumer = new Consumer(client.ApplicationName, client.ConsumerKey);

            if (this.operatorContext is OperatorContext)
                (this.operatorContext as OperatorContext).Operator = new OperatorUser(user.AccessorId, user.Login, (OperatorPriorityLevel)user.PriorityLevel);
        }
    }
}