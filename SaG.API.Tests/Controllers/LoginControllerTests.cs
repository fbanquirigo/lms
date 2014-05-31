using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SaG.API.Controllers;
using SaG.API.Models;
using SaG.Business;
using SaG.Business.Models;
using SaG.Services.Contracts;

namespace SaG.API.Tests.Controllers
{
    [TestFixture]
    public class LoginControllerTests
    {
        private LoginController target;
        private const string SomeClientId = "someClientId";
        private const string SomeUri = "http://uri.com/";
        private const string SomeState = "state";
        private const string SomeUsername = "username";
        private const string SomePassword = "password";
        private const string SomeAuthCode = "code";
        private Mock<IAPIClientService> apiClientService;
        private Mock<IOperatorService> operatorService;
        private Mock<IAuthenticationService> authenticationService;
        private Mock<IConsumerContext> consumerContext;
        private Mock<IOperatorContext> operatorContext;
        private Mock<IAuditTrailService> auditTrail;
        private Mock<IAccessorService> accessorService;
        private Mock<ISessionStateProvider> session;
        [SetUp]
        public void Setup()
        {
            this.apiClientService = new Mock<IAPIClientService>();
            this.operatorService = new Mock<IOperatorService>();
            this.authenticationService = new Mock<IAuthenticationService>();
            this.consumerContext = new Mock<IConsumerContext>();
            this.operatorContext = new Mock<IOperatorContext>();
            this.auditTrail = new Mock<IAuditTrailService>();
            this.accessorService = new Mock<IAccessorService>();
            this.session = new Mock<ISessionStateProvider>();
            this.target = new LoginController(this.apiClientService.Object, this.operatorService.Object,
                this.authenticationService.Object, this.consumerContext.Object, this.operatorContext.Object, 
                this.auditTrail.Object, this.accessorService.Object,this.session.Object);
            this.target.ModelState.Clear();
        }

        [Test]
        public void TestOAuthLoginRequiresClientId()
        {
            ActionResult result = this.target.OAuthLogin(null, SomeUri, SomeState);
            Assert.That(result, Is.TypeOf(typeof(HttpNotFoundResult)));
        }

        [Test]
        public void TestOAuthLoginRequiresRedirectUri()
        {
            ActionResult result = this.target.OAuthLogin(SomeClientId, null, SomeState);
            Assert.That(result, Is.TypeOf(typeof(HttpNotFoundResult)));
        }

        [Test]
        public void TestOAuthLoginInvalidClient()
        {
            this.apiClientService.Setup(x => x.ValidClient(It.IsAny<string>())).Returns(false);
            ActionResult result = this.target.OAuthLogin(SomeClientId, SomeUri, SomeState);
            Assert.That(result, Is.TypeOf(typeof(HttpNotFoundResult)));
        }

        [Test]
        public void TestOAuthLoginView()
        {
            this.apiClientService.Setup(x => x.ValidClient(It.IsAny<string>())).Returns(true);
            ActionResult result = this.target.OAuthLogin(SomeClientId, SomeUri, SomeState);
            var viewResult = result as ViewResult;
            if (viewResult == null)
                Assert.Fail();

            Assert.That(viewResult.ViewName, Is.EqualTo("OAuthLogin"));
        }

        [Test]
        public void TestOAuthLoginModel()
        {
            this.apiClientService.Setup(x => x.ValidClient(It.IsAny<string>())).Returns(true);
            ActionResult result = this.target.OAuthLogin(SomeClientId, SomeUri, SomeState);
            var viewResult = result as ViewResult;
            if (viewResult == null)
                Assert.Fail();
            var model = viewResult.Model as OAuthLoginClient;
            if (model == null)
                Assert.Fail();

            Assert.That(model.CallbackUri == SomeUri
                && model.ClientId == SomeClientId && model.State == SomeState, Is.True);
        }

        [Test]
        public void TestAuthenticateInvalidClient()
        {
            this.apiClientService.Setup(x => x.ValidClient(It.IsAny<string>())).Returns(false);
            var model = new OAuthLoginClient
            {
                Username = SomeUsername,
                Password = SomePassword,
                ClientId = SomeClientId,
                State = SomeState
            };
            ActionResult result = this.target.Authenticate(model);
            Assert.That(result is HttpNotFoundResult, Is.True);
        }

        [Test]
        public void TestAuthenticateInvalidUri()
        {
            this.apiClientService.Setup(x => x.ValidClient(It.IsAny<string>())).Returns(true);
            var model = new OAuthLoginClient
            {
                Username = SomeUsername,
                Password = SomePassword,
                ClientId = SomeClientId,
                State = SomeState
            };
            ActionResult result = this.target.Authenticate(model);
            Assert.That(result, Is.TypeOf(typeof(HttpNotFoundResult)));
        }

        [Test]
        public void TestAuthenticateInvalidModel()
        {
            this.apiClientService.Setup(x => x.ValidClient(It.IsAny<string>())).Returns(true);
            this.operatorService.Setup(x => x.ValidOperatorLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            this.target.ModelState.AddModelError("Username", "Enter username.");
            var model = new OAuthLoginClient
            {
                Username = null,
                Password = null,
                ClientId = SomeClientId,
                State = SomeState,
                CallbackUri = SomeUri
            };
            ActionResult result = this.target.Authenticate(model);
            var redirectRouteResult = result as RedirectToRouteResult;
            if (redirectRouteResult == null)
                Assert.Fail();

            Assert.That(this.target.TempData["ErrorString"], Is.Not.Null);
        }

        [Test]
        public void TestAuthenticateInvalidUser()
        {
            this.apiClientService.Setup(x => x.ValidClient(It.IsAny<string>())).Returns(true);
            this.operatorService.Setup(x => x.ValidOperatorLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var model = new OAuthLoginClient
            {
                Username = SomeUsername,
                Password = SomePassword,
                ClientId = SomeClientId,
                State = SomeState,
                CallbackUri = SomeUri
            };
            ActionResult result = this.target.Authenticate(model);
            var redirectRouteResult = result as RedirectToRouteResult;
            if (redirectRouteResult == null)
                Assert.Fail();

            Assert.That(this.target.TempData["ErrorString"], Is.Not.Null);

        }

        [Test]
        public void TestAuthenticateSuccessful()
        {
            var apiClient = new APIClient();
            var user = new Operator {Login = "jdoe"};
            this.apiClientService.Setup(x => x.ValidClient(It.IsAny<string>())).Returns(true);
            this.operatorService.Setup(x => x.ValidOperatorLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            this.apiClientService.Setup(x => x.GetClient(It.IsAny<string>())).Returns(apiClient);
            this.operatorService.Setup(x => x.GetOperator(It.IsAny<string>())).Returns(user);
            this.authenticationService.Setup(x => x.GenerateAuthCode(apiClient, user)).Returns(SomeAuthCode);
            var accessor = new Accessor {FirstName = "John", LastName = "Doe"};
            this.accessorService.Setup(x => x.GetAccessor(It.IsAny<int>())).Returns(accessor);
            var model = new OAuthLoginClient
            {
                Username = SomeUsername,
                Password = SomePassword,
                ClientId = SomeClientId,
                State = SomeState,
                CallbackUri = SomeUri
            };
            ActionResult result = this.target.Authenticate(model);
            var redirectResult = result as RedirectResult;
            if (redirectResult == null)
                Assert.Fail();
            this.accessorService.VerifyAll();
            this.auditTrail.VerifyAll();
            this.operatorService.VerifyAll();
            this.apiClientService.VerifyAll();
            this.authenticationService.VerifyAll();
        }
    }
}
