using Moq;
using NUnit.Framework;
using SaG.Business;
using SaG.Business.Models;
using SaG.Business.Models.Views;
using SaG.Data.Repositories;
using SaG.Services.Contracts;
using SaG.Services.Contracts.Verifiers;
using SaG.Services.Exceptions;

namespace SaG.Services.Tests
{
    [TestFixture]
    public class OperationCodeServiceTests
    {
        private OperationCodeService target;
        private Mock<IAtmService> atmService;
        private Mock<IEmployeeService> employeeService;
        private Mock<ITouchKeyService> touchKeyService;
        private Mock<ICommandContext> commandContext;
        private Mock<ILockCryptoService> lockCryptoService;
        private Mock<IOperationCodeRepository> operationCodeRepository;
        private Mock<ISystemContext> systemContext;
        private Mock<IClientContext> clientContext;
        private Mock<IOperationCodeRecorder> operationCodeRecorder;
        private Mock<IOperationDateVerifier> operationDateVerifier;
        private Mock<IOperationHourVerifier> operationHourVerifier;
        private Mock<IUserLevelVerifier> userLevelVerifier;
        private Mock<ITimeBlockVerifier> timeBlockVerifier;
        private Mock<ILockStatusVerifier> lockStatusVerifier;
        private Mock<IAuditTrailService> auditTrail;

        [SetUp]
        public void Setup()
        {
            this.atmService = new Mock<IAtmService>();
            this.employeeService = new Mock<IEmployeeService>();
            this.touchKeyService = new Mock<ITouchKeyService>();
            this.commandContext = new Mock<ICommandContext>();
            this.lockCryptoService = new Mock<ILockCryptoService>();
            this.operationCodeRepository = new Mock<IOperationCodeRepository>();
            this.systemContext = new Mock<ISystemContext>();
            this.clientContext = new Mock<IClientContext>();
            this.operationCodeRecorder = new Mock<IOperationCodeRecorder>();
            this.operationDateVerifier = new Mock<IOperationDateVerifier>();
            this.operationHourVerifier = new Mock<IOperationHourVerifier>();
            this.userLevelVerifier = new Mock<IUserLevelVerifier>();
            this.timeBlockVerifier = new Mock<ITimeBlockVerifier>();
            this.lockStatusVerifier = new Mock<ILockStatusVerifier>();
            this.auditTrail = new Mock<IAuditTrailService>();
            this.target = new OperationCodeService(this.atmService.Object,
                this.employeeService.Object, this.touchKeyService.Object, this.commandContext.Object,
                this.lockCryptoService.Object, this.operationCodeRepository.Object, this.systemContext.Object,
                this.clientContext.Object, this.operationCodeRecorder.Object, this.operationDateVerifier.Object,
                this.operationHourVerifier.Object, this.userLevelVerifier.Object, this.timeBlockVerifier.Object,
                this.lockStatusVerifier.Object, this.auditTrail.Object);
        }

        [Test]
        public void TestGenerateOpenLockACodeInvalidAtmId()
        {
            const string atmId = "ATM001";
            AtmView output;
            this.atmService.Setup(x => x.VerifyAtm(atmId, out output)).Returns(false);

            Assert.Throws<MethodArgumentException>(() =>
                this.target.GenerateOpenLockACode(atmId, string.Empty,
                string.Empty, string.Empty, 0, 0, 0));
        }

        [Test]
        public void TestGenerateOpenLockACodeInvalidUser()
        {
            AtmView output;
            this.atmService.Setup(x => x.VerifyAtm(It.IsAny<string>(), out output)).Returns(true);
            const string userId = "1234";
            UserEmployeeView user;
            this.employeeService.Setup(x => x.VerifyUser(userId, out user)).Returns(false);

            Assert.Throws<MethodArgumentException>(() =>
                this.target.GenerateOpenLockACode(string.Empty, userId,
                string.Empty, string.Empty, 0, 0, 0));
        }

        [Test]
        public void TestGenerateOpenLockAInvalidTouchKey()
        {
            AtmView output;
            this.atmService.Setup(x => x.VerifyAtm(It.IsAny<string>(), out output)).Returns(true);
            var user = new UserEmployeeView { AccessorId = 2 };
            this.employeeService.Setup(x => x.VerifyUser(It.IsAny<string>(), out user)).Returns(true);
            const string touchKeyId = "TK001";
            TouchKey touchKey;
            this.touchKeyService.Setup(x => x.VerifyTouchKey(touchKeyId, user.AccessorId, out touchKey)).Returns(false);

            Assert.Throws<MethodArgumentException>(() =>
                this.target.GenerateOpenLockACode(string.Empty, string.Empty,
                touchKeyId, string.Empty, 0, 0, 0));
        }

        [Test]
        public void TestGenerateOpenLockAInvalidUserLevel()
        {
            AtmView output;
            this.atmService.Setup(x => x.VerifyAtm(It.IsAny<string>(), out output)).Returns(true);
            var user = new UserEmployeeView { AccessorId = 2 };
            this.employeeService.Setup(x => x.VerifyUser(It.IsAny<string>(), out user)).Returns(true);
            var touchKey = new TouchKey {TypeKey = "typeKey", Status = true};
            this.touchKeyService.Setup(x => x.VerifyTouchKey(It.IsAny<string>(), user.AccessorId, out touchKey))
                .Returns(true);
            this.userLevelVerifier.Setup(x => x.Verify(touchKey.TypeKey, user.UserType, touchKey.Status)).Returns(false);

            Assert.Throws<UserLevelException>(() => this.target.GenerateOpenLockACode(string.Empty, string.Empty,
                "typeKey", string.Empty, 0, 0, 0));
        }     
    }
}
