using System.Web.Compilation;
using Moq;
using NUnit.Framework;
using SaG.API.Controllers;
using SaG.API.Models;
using SaG.API.Models.Requests;
using SaG.API.Models.Responses;
using SaG.Services.Contracts;

namespace SaG.API.Tests.Controllers
{
    [TestFixture]
    public class AccessControllerTests
    {
        private Mock<IAuthenticationService> authenticationService;
        private Mock<IAPIClientService> apiClientService;
        private Mock<IResponseHelper> responseHelper;
        private Mock<IResourceProvider> resourceProvider;
        private Mock<IAccessTokenContext> accessTokenContext;
        private AccessController target;
        private const string SomeClientId = "clientId";
        private const string SomeClientSecret = "clientSecret";
        private const string SomeAuthCode = "authCode";
        private const string SomeAccessToken = "accessToken";

        [SetUp]
        public void Setup()
        {
            this.authenticationService = new Mock<IAuthenticationService>();                    
            this.apiClientService = new Mock<IAPIClientService>();
            this.responseHelper = new Mock<IResponseHelper>();
            this.resourceProvider = new Mock<IResourceProvider>();
            this.accessTokenContext = new Mock<IAccessTokenContext>();
            this.target = new AccessController(this.responseHelper.Object, this.authenticationService.Object, 
                this.apiClientService.Object, this.resourceProvider.Object, this.accessTokenContext.Object);
        }

        [Test]
        public void TestGetAccessTokenInvalidClient()
        {
            this.apiClientService.Setup(x => x.ValidateClient(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var expected = new AccessTokenResponse
                {
                    Header = new ResponseHeader
                        {
                            Message = "Invalid API credentials.",
                            StatusCode = ResponseStatus.InvalidCredentials
                        }
                };
            this.responseHelper.Setup(x => x.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(
                It.IsAny<string>(), ResponseStatus.InvalidCredentials, null)).Returns(expected);

            var request = new AccessTokenRequest
                {
                    ClientId = SomeClientId,
                    ClientSecret = SomeClientSecret,
                    AuthCode = SomeAuthCode
                };
            AccessTokenResponse result = this.target.GetAccessToken(request);
            
            Assert.That(result, Is.EqualTo(expected));
            this.apiClientService.VerifyAll();
            this.responseHelper.Verify(x => x.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(
                It.IsAny<string>(), ResponseStatus.InvalidCredentials, null));
        }

        [Test]
        public void TestGetAccessTokenInvalidAuthCode()
        {
            this.apiClientService.Setup(x => x.ValidateClient(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            this.authenticationService.Setup(x => x.ValidateAuthCode(It.IsAny<string>(), SomeClientId)).Returns(false);
            var expected = new AccessTokenResponse
            {
                Header = new ResponseHeader
                {
                    Message = "Invalid auth code.",
                    StatusCode = ResponseStatus.UnAuthorized
                }
            };
            this.responseHelper.Setup(x => x.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(
                It.IsAny<string>(), ResponseStatus.UnAuthorized, null)).Returns(expected);

            var request = new AccessTokenRequest
            {
                ClientId = SomeClientId,
                ClientSecret = SomeClientSecret,
                AuthCode = SomeAuthCode
            };
            AccessTokenResponse result = this.target.GetAccessToken(request);
            
            Assert.That(result, Is.EqualTo(expected));
            this.apiClientService.VerifyAll();
            this.authenticationService.VerifyAll();
            this.responseHelper.Verify(x => x.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(
                It.IsAny<string>(), ResponseStatus.UnAuthorized, null));
        }

        [Test]
        public void TestGetAccessToken()
        {
            this.apiClientService.Setup(x => x.ValidateClient(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            this.authenticationService.Setup(x => x.ValidateAuthCode(It.IsAny<string>(), SomeClientId)).Returns(true);
            this.authenticationService.Setup(x => x.GenerateAccessToken(SomeAuthCode, SomeClientId))
                .Returns(SomeAccessToken);
            var expectedBody = new AccessTokenResponseBody {AccessToken = SomeAccessToken};
            var expected = new AccessTokenResponse
            {
                Header = new ResponseHeader
                {
                    Message = string.Empty,
                    StatusCode = ResponseStatus.Ok,
                    Status = ResponseStatus.Ok.ToString()
                },
                Body = expectedBody
            };

            this.responseHelper.Setup(x => x.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(
                string.Empty, ResponseStatus.Ok, It.IsAny<AccessTokenResponseBody>())).Returns(expected);

            var request = new AccessTokenRequest
            {
                ClientId = SomeClientId,
                ClientSecret = SomeClientSecret,
                AuthCode = SomeAuthCode
            };
            AccessTokenResponse result = this.target.GetAccessToken(request);
            
            Assert.That(result, Is.EqualTo(expected));
            this.apiClientService.VerifyAll();
            this.authenticationService.VerifyAll();
            this.responseHelper.Verify(x => x.CreateResponse<AccessTokenResponse, AccessTokenResponseBody>(
                It.IsAny<string>(), ResponseStatus.Ok, It.IsAny<AccessTokenResponseBody>()));
        }
    }
}
