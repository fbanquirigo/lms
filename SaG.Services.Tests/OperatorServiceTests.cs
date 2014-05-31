using Moq;
using NUnit.Framework;
using SaG.Business.Models;
using SaG.Data.Repositories;
using SaG.Services.Contracts;

namespace SaG.Services.Tests
{
    [TestFixture]
    public class OperatorServiceTests
    {
        private const string SomeUsername = "username";
        private const string SomePassword = "password";
        private Mock<IOperatorRepository> operatorRepository;
        private Mock<ILockCryptoService> lockCryptoService;
        private OperatorService target;

        [SetUp]
        public void Setup()
        {
            this.operatorRepository = new Mock<IOperatorRepository>();        
            this.lockCryptoService = new Mock<ILockCryptoService>();
            this.target = new OperatorService(this.operatorRepository.Object, this.lockCryptoService.Object);
        }

        [Test]
        public void TestInvalidOperatorLogin()
        {
            this.operatorRepository.Setup(x => x.GetOperator(It.IsAny<string>())).Returns(default(Operator));
            bool result = this.target.ValidOperatorLogin(SomeUsername, SomePassword);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestInvalidOperatorPassword()
        {
            var user = new Operator {Login = SomeUsername, Password = "wrongPassword"};
            this.operatorRepository.Setup(x => x.GetOperator(It.IsAny<string>())).Returns(user);
            this.lockCryptoService.Setup(x => x.EncryptDBValue(SomePassword, CryptoType.Password)).Returns(SomePassword);
            bool result = this.target.ValidOperatorLogin(SomeUsername, SomePassword);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestValidOperatorLogin()
        {
            var user = new Operator { Login = SomeUsername, Password = SomePassword };
            this.operatorRepository.Setup(x => x.GetOperator(It.IsAny<string>())).Returns(user);
            this.lockCryptoService.Setup(x => x.DecryptDBValue(user.Password, CryptoType.Password)).Returns(SomePassword);
            bool result = this.target.ValidOperatorLogin(SomeUsername, SomePassword);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestGetOperatorNotExist()
        {
            this.operatorRepository.Setup(x => x.GetOperator(It.IsAny<string>())).Returns(default(Operator));
            Operator result = this.target.GetOperator(SomeUsername);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestGetOperator()
        {
            var expected = new Operator { Login = SomeUsername, Password = SomePassword };
            this.operatorRepository.Setup(x => x.GetOperator(It.IsAny<string>())).Returns(expected);
            Operator result = this.target.GetOperator(SomeUsername);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
