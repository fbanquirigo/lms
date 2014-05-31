using System;
using System.Globalization;
using System.Web.Compilation;
using Moq;
using NUnit.Framework;
using SaG.API.Controllers;
using SaG.API.Models;
using SaG.API.Models.Requests.ASeries;
using SaG.API.Models.Responses;
using SaG.Business;
using SaG.Services.Contracts;
using SaG.Services.Exceptions;

namespace SaG.API.Tests.Controllers
{
    [TestFixture]
    public class ASeriesControllerTests
    {
        private ASeriesController target;
        private Mock<IResponseHelper> responseHelper;
        private Mock<IOperationCodeService> operationCodeService;
        private Mock<ICloseCodeService> closeCodeService;
        private Mock<IResourceProvider> resourceProvider;
        private Mock<IEventLogService> eventLogService;
        private Mock<IConsumer> consumer;
        private Mock<IOperator> user;

        [SetUp]
        public void Setup()
        {
            this.responseHelper = new Mock<IResponseHelper>();
            this.operationCodeService = new Mock<IOperationCodeService>();
            this.closeCodeService = new Mock<ICloseCodeService>();
            this.resourceProvider = new Mock<IResourceProvider>();
            this.eventLogService = new Mock<IEventLogService>();
            this.target = new ASeriesController(this.responseHelper.Object, this.operationCodeService.Object,
                this.closeCodeService.Object, this.resourceProvider.Object, this.eventLogService.Object);
            this.consumer = new Mock<IConsumer>();
            this.user = new Mock<IOperator>();
        }

        #region OpenLockA
        [Test]
        public void TestOpenLockAInvalidModel()
        {
            var request = CreateOpenLockARequest();
            const string message = "Some Error Message.";
            const string errorKey = "Error";            
            SetInvalidModel(errorKey, message);
            this.resourceProvider.Setup(x => x.GetObject(It.IsAny<string>(), It.IsAny<CultureInfo>())).Returns(message);
            var expected = new OperationCodeResponse {Header = new ResponseHeader {StatusCode = ResponseStatus.Error}};
            this.responseHelper.Setup(
                x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestOpenLockA()
        {
            var request = CreateOpenLockARequest();
            const int expectedOpCode = 123456789;
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Returns(expectedOpCode);

            var expectedResponseBody = new OperationCodeResponseBody {OperationCode = expectedOpCode};
            var expected = new OperationCodeResponse
                           {
                               Header = new ResponseHeader { StatusCode = ResponseStatus.Ok },
                               Body =  expectedResponseBody
                           };

            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse, OperationCodeResponseBody>(string.Empty,
                ResponseStatus.Ok, It.Is<OperationCodeResponseBody>(a => a.OperationCode == expectedOpCode))).Returns(expected);


            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));     
        }

        [Test]
        public void TestUnhandledExceptionResponse()
        {
            var request = CreateOpenLockARequest();
            var expectedException = new Exception("Some Exception.");
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);
            const string consumerId = "consumer";
            const string operatorLoginName = "operator";
            this.consumer.SetupGet(x => x.ConsumerId).Returns(consumerId);
            this.user.SetupGet(x => x.LoginName).Returns(operatorLoginName);
            const string errorId = "errorId";
            this.eventLogService.Setup(x => x.LogUnhandledException(request, expectedException)).Returns(errorId);

            var expected = CreateUnhandledErrorResponse(errorId);
            this.responseHelper.Setup(x => x.CreateUnhandledResponse<OperationCodeResponse>(errorId)).Returns(expected);
            
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestOpenLockAMethodArgument()
        {
            var request = CreateOpenLockARequest();    
            var expectedException = new MethodArgumentException("SomeArgument");
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);

            const string messageFormat = "Invalid argument {0}.";
            string message = string.Format(messageFormat, "SomeArgument");
            this.resourceProvider.Setup(x => x.GetObject("ArgumentException.Error",
                CultureInfo.CurrentCulture)).Returns(messageFormat);
            var expected = new OperationCodeResponse
                {
                    Header = new ResponseHeader
                            {
                                StatusCode = ResponseStatus.Error,
                                Message = message
                            }
                };
            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestOpenLockAUserLevel()
        {
            var request = CreateOpenLockARequest();      
            const string userId = "userId";
            var expectedException = new UserLevelException(userId);
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);

            const string message = "Invalid user level.";
            this.resourceProvider.Setup(x => x.GetObject("UserLevelException.Error",
                CultureInfo.CurrentCulture)).Returns(message);
            var expected = new OperationCodeResponse
            {
                Header = new ResponseHeader
                {
                    StatusCode = ResponseStatus.Error,
                    Message = message
                }
            };
            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestOpenLockAInvalidTouchKey()
        {
            var request = CreateOpenLockARequest();   
            const string touchKeyId = "touchKeyId";
            var expectedException = new InvalidTouchKeyPositionException(touchKeyId);
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);

            const string message = "Invalid touch key position.";
            this.resourceProvider.Setup(x => x.GetObject("InvalidTouchKeyPositionException.Error",
                CultureInfo.CurrentCulture)).Returns(message);
            var expected = new OperationCodeResponse
            {
                Header = new ResponseHeader
                {
                    StatusCode = ResponseStatus.Error,
                    Message = message
                }
            };
            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestOpenLockAInvalidOperationDate()
        {
            var request = CreateOpenLockARequest();
            var expectedException = new InvalidOperationDateException(request.Date);
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);

            const string message = "Invalid operation date.";
            this.resourceProvider.Setup(x => x.GetObject("InvalidOperationDateException.Error",
                CultureInfo.CurrentCulture)).Returns(message);
            var expected = new OperationCodeResponse
            {
                Header = new ResponseHeader
                {
                    StatusCode = ResponseStatus.Error,
                    Message = message
                }
            };
            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));  
        }

        [Test]
        public void TestOpenLockAInvalidOperationDateRange()
        {
            var request = CreateOpenLockARequest();
            var expectedException = new InvalidOperationDateRangeException(DateTime.Now, request.AtmId);
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);

            const string message = "Invalid operation date range.";
            this.resourceProvider.Setup(x => x.GetObject("InvalidOperationDateRangeException.Error",
                CultureInfo.CurrentCulture)).Returns(message);
            var expected = new OperationCodeResponse
            {
                Header = new ResponseHeader
                {
                    StatusCode = ResponseStatus.Error,
                    Message = message
                }
            };
            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));  
        }

        [Test]
        public void TestOpenLockAInvalidOperationHour()
        {
            var request = CreateOpenLockARequest();
            const int hour = 2;
            var expectedException = new InvalidOperationHourException(hour);
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);

            const string message = "Invalid operation hour.";
            this.resourceProvider.Setup(x => x.GetObject("InvalidOperationHourException.Error",
                CultureInfo.CurrentCulture)).Returns(message);
            var expected = new OperationCodeResponse
            {
                Header = new ResponseHeader
                {
                    StatusCode = ResponseStatus.Error,
                    Message = message
                }
            };
            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));  
        }

        [Test]
        public void TestOpenLockAInvalidOperationHourLimit()
        {
            var request = CreateOpenLockARequest();           
            const int timeBlock = 2;
            var expectedException = new InvalidOperationHourLimitException(timeBlock);
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);

            const string message = "Invalid operation hour limit (timeblock).";
            this.resourceProvider.Setup(x => x.GetObject("InvalidOperationHourLimitException.Error",
                CultureInfo.CurrentCulture)).Returns(message);
            var expected = new OperationCodeResponse
            {
                Header = new ResponseHeader
                {
                    StatusCode = ResponseStatus.Error,
                    Message = message
                }
            };
            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));  
        }

        [Test]
        public void TestOpenLockAInvalidLockStat()
        {
            var request = CreateOpenLockARequest();
            const int lockStat = 2;
            var expectedException = new InvalidLockStatException(lockStat);
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);

            const string message = "Invalid lock stat.";
            this.resourceProvider.Setup(x => x.GetObject("InvalidLockStatException.Error",
                CultureInfo.CurrentCulture)).Returns(message);
            var expected = new OperationCodeResponse
            {
                Header = new ResponseHeader
                {
                    StatusCode = ResponseStatus.Error,
                    Message = message
                }
            };
            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));   
        }

        [Test]
        public void TestOpenLockADuplicateOperationCode()
        {
            var request = CreateOpenLockARequest();
            var expectedException = new DuplicateOperationCodeException();
            this.operationCodeService.Setup(x => x.GenerateOpenLockACode(request.AtmId, request.UserId,
                request.TouchKeyId, request.Date, request.Hour, request.TimeBlock, request.LockStatus)).Throws(expectedException);

            const string message = "Duplicate Operation Code.";
            this.resourceProvider.Setup(x => x.GetObject("DuplicateOperationCodeException.Error",
                CultureInfo.CurrentCulture)).Returns(message);
            var expected = new OperationCodeResponse
            {
                Header = new ResponseHeader
                {
                    StatusCode = ResponseStatus.Error,
                    Message = message
                }
            };
            this.responseHelper.Setup(x => x.CreateResponse<OperationCodeResponse>(message, ResponseStatus.Error))
                .Returns(expected);
            OperationCodeResponse result = this.target.OpenLockA(request);
            Assert.That(result, Is.EqualTo(expected));   
        }    
        #endregion OpenLockA      

        private void SetInvalidModel(string key, string message)
        {
            this.target.ModelState.AddModelError(key, message);
        }

        private OperationCodeResponse CreateUnhandledErrorResponse(string errorId)
        {
            return new OperationCodeResponse
            {
                Header = new ResponseHeader
                {
                    Message = "Unhandled Error Message.",
                    StatusCode = ResponseStatus.UnhandledException,
                    Status = ResponseStatus.UnhandledException.ToString(),
                    ErrorId = errorId
                }
            };    
        }

        private OpenLockARequest CreateOpenLockARequest()
        {
            return new OpenLockARequest
            {
                AtmId = "ATM001",
                Date = "20140421",
                Hour = 15,
                LockStatus = 0,
                TimeBlock = 4,
                TouchKeyId = "1234",
                UserId = "1234"
            };
        }
    }
}
