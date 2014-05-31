using Moq;
using NUnit.Framework;
using SaG.API.Controllers;
using SaG.API.Models;
using SaG.API.Models.Responses;
using SaG.Core.Logging;
using SaG.Services.Contracts;

namespace SaG.API.Tests.Controllers
{
    [TestFixture]
    public class SystemInfoControllerTests
    {
        private Mock<ILogger> logger;
        private Mock<ISystemInformationService> informationService;
        private Mock<IResponseHelper> helper;
        private SystemInfoController target;

        [SetUp]
        public void Setup()
        {
            this.logger = new Mock<ILogger>();        
            this.informationService = new Mock<ISystemInformationService>();
            this.helper = new Mock<IResponseHelper>();
            this.target = new SystemInfoController(this.logger.Object, 
                this.informationService.Object, this.helper.Object);
        }

        [Test]
        public void TestGet()
        {
            this.target.Get();
            this.logger.Verify(x => x.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>()));
            this.helper.Verify(x => x.CreateResponse<SystemInfoResponse, SystemInfoResponseBody>(It.IsAny<SystemInfoResponseBody>()));
            this.informationService.VerifyAll();
        }
    }
}
