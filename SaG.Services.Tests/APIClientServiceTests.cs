using Moq;
using NUnit.Framework;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Services.Tests
{
    [TestFixture]
    public class APIClientServiceTests
    {
        private const string SomeApplicationName = "applicationName";
        private const string SomeConsumerKey = "consumerKey";
        private const string SomeConsumerSecret = "consumerSecret";
        private const string SomeDoman = "domain";
        private Mock<IAPIClientRepository> repository;
        private APIClientService target;

        [SetUp]
        public void Setup()
        {
            this.repository = new Mock<IAPIClientRepository>();    
            this.target = new APIClientService(this.repository.Object);
        }

        [Test]
        public void TestGetClient()
        {
            var expected = new APIClient
            {
                ApplicationName = SomeApplicationName,
                ConsumerKey = SomeConsumerKey,
                ConsumerSecret = SomeConsumerSecret,
                Domain = SomeDoman,
                Suspended = false
            };
            this.repository.Setup(x => x.GetApiClient(It.IsAny<string>())).Returns(expected);
            APIClient result = this.target.GetClient(SomeConsumerKey);
            Assert.That(result, Is.EqualTo(expected)); 
        }

        [Test]
        public void TestInvalidClient()
        {
            this.repository.Setup(x => x.ClientExists(It.IsAny<string>())).Returns(false);
            bool result = this.target.ValidClient(SomeConsumerKey);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestValidClient()
        {
            this.repository.Setup(x => x.ClientExists(It.IsAny<string>())).Returns(true);
            bool result = this.target.ValidClient(SomeConsumerKey);
            Assert.That(result, Is.True); 
        }

        [Test]
        public void TestValidateClientNotExist()
        {
            this.repository.Setup(x => x.GetApiClient(It.IsAny<string>())).Returns(default(APIClient));
            bool result = this.target.ValidateClient(SomeConsumerKey, SomeConsumerSecret);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestValidateClientWrongSecret()
        {
            var expected = new APIClient
            {
                ApplicationName = SomeApplicationName,
                ConsumerKey = SomeConsumerKey,
                ConsumerSecret = SomeConsumerSecret,
                Domain = SomeDoman,
                Suspended = false
            };
            this.repository.Setup(x => x.GetApiClient(It.IsAny<string>())).Returns(expected);
            bool result = this.target.ValidateClient(SomeConsumerKey, "wrong-secret");
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestValidateClient()
        {
            var expected = new APIClient
            {
                ApplicationName = SomeApplicationName,
                ConsumerKey = SomeConsumerKey,
                ConsumerSecret = SomeConsumerSecret,
                Domain = SomeDoman,
                Suspended = false
            };
            this.repository.Setup(x => x.GetApiClient(It.IsAny<string>())).Returns(expected);
            bool result = this.target.ValidateClient(SomeConsumerKey, SomeConsumerSecret);
            Assert.That(result, Is.True);
        }
    }
}
