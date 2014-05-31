using System;
using System.Web.Compilation;
using System.Web.Http;
using SaG.API.Helpers;
using SaG.API.Models;
using SaG.API.Models.Requests.BSeries;
using SaG.API.Models.Responses;
using SaG.Services.Contracts;
using SaG.Services.Exceptions;

namespace SaG.API.Controllers
{
    /// <summary>
    /// C series commands API methods.
    /// </summary>
    public class CSeriesController : ApiControllerBase
    {
        private readonly IResponseHelper helper;
        private readonly IOperationCodeService operationCodeService;
        private readonly ICloseCodeService closeCodeService;
        private readonly IResourceProvider resourceProvider;
        private readonly IEventLogService eventLogService;

        /// <summary>
        /// Constructor
        /// </summary>
        public CSeriesController(IResponseHelper helper,
            IOperationCodeService operationCodeService, 
            ICloseCodeService closeCodeService,
            IResourceProvider resourceProvider,
            IEventLogService eventLogService)
        {
            this.helper = helper;
            this.operationCodeService = operationCodeService;
            this.closeCodeService = closeCodeService;
            this.resourceProvider = resourceProvider;
            this.eventLogService = eventLogService;
        }

        /// <summary>
        /// Generates an operation code to open the lock using the inputs ATM ID, USER ID, TOUCH KEY ID, TIME, DATE, TIME BLOCK and LOCK STATUS.
        /// </summary>
        /// <param name="request">OpenLockBRequest</param>
        /// <returns>OperationCodeResponse</returns>
        [Route("OPEN_LOCK_C")]
        public OperationCodeResponse OpenLockC(OpenLockCRequest request)
        {
            if (!ModelState.IsValid)
                return this.helper.CreateResponse<OperationCodeResponse>(this.resourceProvider.ResourceString("RequiredFields.Error"), ResponseStatus.Error);

            try
            {
                int opCode = this.operationCodeService.GenerateOpenLockCCode(request.AtmId, request.MiddleName, request.TouchKeyId,
                    request.Date, request.Hour, request.TimeBlock, request.LockStatus);

                var responseBody = new OperationCodeResponseBody { OperationCode = opCode };
                return this.helper.CreateResponse<OperationCodeResponse, OperationCodeResponseBody>(string.Empty,
                    ResponseStatus.Ok, responseBody);
            }
            catch (BaseException ex)
            {
                return CreateErrorResponse<OperationCodeResponse>(ex);
            }
            catch (Exception ex)
            {
                string errorId = this.eventLogService.LogUnhandledException(request, ex);
                return this.helper.CreateUnhandledResponse<OperationCodeResponse>(errorId);
            }
        }


        private TResponse CreateErrorResponse<TResponse>(BaseException ex)
            where TResponse : IResponseWithHeader<ResponseHeader>, new()
        {
            if (ex is MethodArgumentException)
            {
                var argEx = ex as MethodArgumentException;
                string errorFormat = this.resourceProvider.ResourceString("ArgumentException.Error");
                return this.helper.CreateResponse<TResponse>(
                    string.Format(errorFormat, argEx.Parameter), ResponseStatus.Error);
            }

            if (ex is UserLevelException)
            {
                string error = this.resourceProvider.ResourceString("UserLevelException.Error");
                return this.helper.CreateResponse<TResponse>(
                    error, ResponseStatus.Error);
            }

            if (ex is InvalidTouchKeyPositionException)
            {
                string error = this.resourceProvider.ResourceString("InvalidTouchKeyPositionException.Error");
                return this.helper.CreateResponse<TResponse>(
                    error, ResponseStatus.Error);
            }

            if (ex is InvalidOperationDateException)
            {
                string error = this.resourceProvider.ResourceString("InvalidOperationDateException.Error");
                return this.helper.CreateResponse<TResponse>(
                    error, ResponseStatus.Error);
            }

            if (ex is InvalidOperationDateRangeException)
            {
                string error = this.resourceProvider.ResourceString("InvalidOperationDateRangeException.Error");
                return this.helper.CreateResponse<TResponse>(
                    error, ResponseStatus.Error);
            }

            if (ex is InvalidOperationHourException)
            {
                string error = this.resourceProvider.ResourceString("InvalidOperationHourException.Error");
                return this.helper.CreateResponse<TResponse>(
                    error, ResponseStatus.Error);
            }

            if (ex is InvalidOperationHourLimitException)
            {
                string error = this.resourceProvider.ResourceString("InvalidOperationHourLimitException.Error");
                return this.helper.CreateResponse<TResponse>(
                    error, ResponseStatus.Error);
            }

            if (ex is InvalidLockStatException)
            {
                string error = this.resourceProvider.ResourceString("InvalidLockStatException.Error");
                return this.helper.CreateResponse<TResponse>(
                    error, ResponseStatus.Error);
            }

            if (ex is DuplicateOperationCodeException)
            {
                string error = this.resourceProvider.ResourceString("DuplicateOperationCodeException.Error");
                return this.helper.CreateResponse<TResponse>(
                    error, ResponseStatus.Error);
            }

            if (ex is CodeAlreadyClosedException)
            {
                string error = this.resourceProvider.ResourceString("CodeAlreadyClosedException.Error");
                return this.helper.CreateResponse<TResponse>(
                    error, ResponseStatus.Error);
            }

            return default(TResponse);
        }
    }
}