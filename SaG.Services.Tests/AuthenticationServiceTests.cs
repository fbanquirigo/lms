using System;
using Moq;
using NUnit.Framework;
using SaG.Business.Models;
using SaG.Core;
using SaG.Data.Repositories;
using SaG.Data;
using SaG.Services.Contracts;

namespace SaG.Services.Tests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IAPIAuthCodeRepository> apiAuthCodeRepository;
        private Mock<IRandomGenerator> randomGenerator;
        private Mock<IDateHelper> dateHelper;
        private Mock<IAPIClientRepository> apiClientRepository;
        private Mock<IAPIAccessTokenRepository> accessTokenRepository;
        private AuthenticationService target;
        private Mock<IAuditTrailService> auditTrail;
        private Mock<IRepository<Accessor>> accessorRepository;

        [SetUp]
        public void Setup()
        {
            this.apiAuthCodeRepository = new Mock<IAPIAuthCodeRepository>();    
            this.randomGenerator = new Mock<IRandomGenerator>();
            this.dateHelper = new Mock<IDateHelper>();
            this.apiClientRepository = new Mock<IAPIClientRepository>();
            this.accessTokenRepository = new Mock<IAPIAccessTokenRepository>();
            this.auditTrail = new Mock<IAuditTrailService>();
            this.accessorRepository = new Mock<IRepository<Accessor>>();
            this.target = new AuthenticationService(this.apiAuthCodeRepository.Object, this.randomGenerator.Object,
                this.dateHelper.Object, this.apiClientRepository.Object, this.accessTokenRepository.Object, 
                this.auditTrail.Object, accessorRepository.Object);
        }

        [Test]
        public void TestGenerateAuthCodeNoClient()
        {
            Assert.Throws(typeof (ArgumentNullException), () => this.target.GenerateAuthCode(null, null));
        }

        [Test]
        public void TestGenerateAuthCodeNoUser()
        {
            Assert.Throws(typeof(ArgumentNullException), () => this.target.GenerateAuthCode(new APIClient(), null));
        }
    }
}
