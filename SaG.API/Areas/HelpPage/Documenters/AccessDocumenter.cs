using SaG.API.Models;
using SaG.API.Models.Requests;
using SaG.API.Models.Responses;

namespace SaG.API.Areas.HelpPage.Documenters
{
    /// <summary>
    /// Access sample documentation
    /// </summary>
    public class AccessDocumenter : APIDocumenter
    {
        private readonly IResponseHelper responseHelper;

        /// <summary>
        /// Controller Nam
        /// </summary>
        protected override string ControllerName
        {
            get { return "Access"; }
        }

        /// <summary>
        /// Creates a new instance of AccessDocumenter
        /// </summary>
        /// <param name="responseHelper"></param>
        public AccessDocumenter(IResponseHelper responseHelper)
        {
            this.responseHelper = responseHelper;
        }

        /// <summary>
        /// Document
        /// </summary>
        public override void Document()
        {
            SetGetAccessTokenSamples();
            SetKillAccessTokenSamples();
        }

        private void SetGetAccessTokenSamples()
        {
            var sampleRequest = new AccessTokenRequest
            {
                ClientId = "your-client-id",
                ClientSecret = "your-client-secret",
                AuthCode = "xys2sadf34ksaf12"
            };

            SetSampleRequest(sampleRequest, "GetAccessToken");
            SetSampleRequest("ClientId=your-client-id&ClientSecret=your-client-secret&AuthCode=xys2sadf34ksaf12", "GetAccessToken");

            var responseBody = new AccessTokenResponseBody { AccessToken = "2j4ksda234kjsafdsaf14sfsdag1==" };
            var response = this.responseHelper.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "GetAccessToken");
        }

        private void SetKillAccessTokenSamples()
        {
            var responseBody = new AccessTokenExpiresResponseBody { TokenExpired = true };
            var response = this.responseHelper.CreateResponse<AccessTokenExpiresResponse, AccessTokenExpiresResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);     
            SetSampleResponse(response, "KillAccessToken");
        }
    }
}