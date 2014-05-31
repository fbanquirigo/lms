using System.Web.Mvc;
using SaG.API.Areas.APIClient.Models;
using SaG.API.Controllers;
using SaG.API.Models.Requests;
using SaG.API.Models.Responses;
using SaG.Core;
using SaG.Business;
using SaG.Business.Models;
using SaG.Services.Contracts;

namespace SaG.API.Areas.APIClient.Controllers
{
    [RouteArea("APIClient", AreaPrefix = "client")]
    public class ClientController : ControllerBase
    {
        private const string ClientId = "2k34nsr234danwerl02po1yzvmeiucg";
        private const string ClientSecret = "MmttbHFibnNyOW9ydGRhbndlcmwwMnBvMXl6dg==";

        private readonly IRandomGenerator randomGenerator;
        private readonly IAPIAccessController accessController;
        private readonly ISessionStateProvider session;
        private readonly IConsumerContext consumerContext;
        private readonly IOperatorContext operatorContext;
        private readonly IAccessTokenContext accessTokenContext;
        private readonly IAuthenticationService authenticationService;

        public ClientController(IRandomGenerator randomGenerator, IAPIAccessController accessController,
            ISessionStateProvider session, IConsumerContext consumerContext, IOperatorContext operatorContext,
            IAccessTokenContext accessTokenContext, IAuthenticationService authenticationService)
        {
            this.randomGenerator = randomGenerator;
            this.accessController = accessController;
            this.session = session;
            this.consumerContext = consumerContext;
            this.operatorContext = operatorContext;
            this.accessTokenContext = accessTokenContext;
            this.authenticationService = authenticationService;
        }

        [Route("login")]
        public ActionResult Login()
        {
            string clientId = ClientId;
            string redirectUri = Url.Content("~/client/authorize");
            string stateVariable = GenerateStateVariable();      

            return RedirectToAction("OAuthLogin", "Login", 
                new {
                        client_id = clientId,
                        redirect_uri = redirectUri,
                        state = stateVariable,
                        area = string.Empty
                    });
        }

        [Route("authorize")]
        public ActionResult Authorize(string auth_code, string state)
        {
            if(!ValidRequest(state))
                return new HttpUnauthorizedResult();

            const string clientId = ClientId;
            const string clientSecret = ClientSecret;

            var request = new AccessTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    AuthCode = auth_code
                };

            AccessTokenResponse response = this.accessController.GetAccessToken(request);

            if(response.Header.StatusCode != ResponseStatus.Ok)
                return new HttpUnauthorizedResult();

            this.session["accessToken"] = response.Body.AccessToken;
            return RedirectToAction("Dashboard");
        }

        [Route("dashboard")]
        [Route("dashboard/{debug}")]
        public ActionResult Dashboard(string debug)
        {
            if (this.session["accessToken"] == null)
                return RedirectToAction("Login");

            string accessToken = this.session["accessToken"].ToString();
            bool isDebug = false;
            if(!string.IsNullOrEmpty(debug))
                isDebug = debug.ToLower() == "debug";
            var model = new ClientDetail { AccessToken = accessToken, ClientId = ClientId, Debug = isDebug };
            return View("Index", model);    
        }

        [Route("logout")]
        public ActionResult Logout()
        {
             if (this.session["accessToken"] == null)
                return RedirectToAction("Login");
            this.session.Remove("accessToken");
            return RedirectToAction("Login");
        }

        private string GenerateStateVariable()
        {
            string state = this.randomGenerator.String(8, "abcdefghijklmnopqrstuvwxyz");
            this.session["loginState"] = state;
            return state;
        }

        private bool ValidState(string state)
        {
            return (this.session["loginState"] ?? string.Empty).ToString() == state;
        }                                               

        private bool ValidRequest(string state)
        {
            return ValidState(state);
        }
    }
}