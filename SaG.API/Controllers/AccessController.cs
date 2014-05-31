using System.Web.Compilation;
using System.Web.Http;
using SaG.API.Helpers;
using SaG.API.Models;
using SaG.API.Models.Requests;
using SaG.API.Models.Responses;
using SaG.API.Security;
using SaG.Services.Contracts;

namespace SaG.API.Controllers
{
    /// <summary>
    /// API user access methods
    /// </summary>
    public class AccessController : ApiControllerBase, IAPIAccessController
    {
        private readonly IResponseHelper helper;
        private readonly IAuthenticationService authenticationService;
        private readonly IAPIClientService apiClientService;
        private readonly IResourceProvider resourceProvider;
        private readonly IAccessTokenContext accessTokenContext;

        /// <summary>
        /// Creates a new instance of AccessController
        /// </summary>
        public AccessController(IResponseHelper helper, IAuthenticationService authenticationService,
            IAPIClientService apiClientService, IResourceProvider resourceProvider, IAccessTokenContext accessTokenContext)
        {
            this.helper = helper;
            this.authenticationService = authenticationService;
            this.apiClientService = apiClientService;
            this.resourceProvider = resourceProvider;
            this.accessTokenContext = accessTokenContext;
        }

        /// <summary>
        /// Access token request endpoint. Returns a usable access token that can be used to access the API.
        /// </summary>
        /// <param name="request">AccessTokenRequest</param>
        /// <returns>AccessTokenResponse</returns>
        [SkipTokenCheck]
        [Route("login/oauth/access_token")]  
        [HttpPost]
        public AccessTokenResponse GetAccessToken(AccessTokenRequest request)
        {
            if (request == null)
            {
                string errorMessage = this.resourceProvider.ResourceString("API.InvalidCredentials");
                return this.helper.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(errorMessage,
                    ResponseStatus.UnAuthorized, null);
            }

            if (!this.apiClientService.ValidateClient(request.ClientId, request.ClientSecret))
            {
                string errorMessage = this.resourceProvider.ResourceString("API.InvalidCredentials");
                return this.helper.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(errorMessage,
                    ResponseStatus.InvalidCredentials, null);
            }

            if (!this.authenticationService.ValidateAuthCode(request.AuthCode, request.ClientId))
            {
                string errorMessage = this.resourceProvider.ResourceString("API.InvalidAuthCode");
                return this.helper.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(errorMessage,
                    ResponseStatus.UnAuthorized, null);
            }

            string accessToken = this.authenticationService.GenerateAccessToken(request.AuthCode, request.ClientId);  
            var responseBody = new AccessTokenResponseBody { AccessToken = accessToken };
            return this.helper.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);
        }

        /// <summary>
        /// Kills the client access token.  Making it unusable.
        /// </summary>
        /// <returns>AccessTokenExpiresResponse</returns>
        [Route("logout/access_token")]
        public AccessTokenExpiresResponse KillAccessToken()
        {
            bool tokenKilled = this.authenticationService.KillAccessToken(this.accessTokenContext.AccessToken);
            return new AccessTokenExpiresResponse { Body = new AccessTokenExpiresResponseBody { TokenExpired = tokenKilled } };    
        }
    }
}