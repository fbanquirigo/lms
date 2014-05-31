using System;
using System.Web.Compilation;
using System.Web.Http;
using SaG.API.Helpers;
using SaG.API.Models;
using SaG.API.Models.Requests.ASeries;
using SaG.API.Models.Responses;
using SaG.Services.Contracts;
using SaG.Services.Exceptions;

namespace SaG.API.Controllers
{
    /// <summary>
    /// A series commands API methods.
    /// </summary>
    public class ASeriesController : ApiControllerBase
    {
        private readonly IResponseHelper helper;
        private readonly IOperationCodeService operationCodeService;
        private readonly ICloseCodeService closeCodeService;
        private readonly IResourceProvider resourceProvider;
        private readonly IEventLogService eventLogService;

        /// <summary>
        /// Constructor
        /// </summary>
        public ASeriesController(IResponseHelper helper,
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
        /// <param name="request">OpenLockARequest</param>
        /// <returns>OperationCodeResponse</returns>
        [Route("OPEN_LOCK_A")]
        public OperationCodeResponse OpenLockA(OpenLockARequest request)
        {
            if (!ModelState.IsValid)
                return this.helper.CreateResponse<OperationCodeResponse>(this.resourceProvider.ResourceString("RequiredFields.Error"), ResponseStatus.Error);

            try
            {
                int opCode = this.operationCodeService.GenerateOpenLockACode(request.AtmId, request.UserId, request.TouchKeyId,
                    request.Date, request.Hour, request.TimeBlock, request.LockStatus);

                var responseBody = new OperationCodeResponseBody {OperationCode = opCode};
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

        /// <summary>
        /// Generates an operation code to open the lock using the inputs ATM ID, USER ID, TIME, DATE and TIME BLOCK.
        /// </summary>
        /// <param name="request">OpenLockNoTouchKeyARequest</param>
        /// <returns>OperationCodeResponse</returns>
        [Route("OPEN_LOCK_NO_TOUCH_KEY_A")]
        public OperationCodeResponse OpenLockNoTouchKeyA(OpenLockNoTouchKeyARequest request)
        {
            if (!ModelState.IsValid)
                return this.helper.CreateResponse<OperationCodeResponse>(this.resourceProvider.ResourceString("RequiredFields.Error"), ResponseStatus.Error);

            try
            {
                int opCode = this.operationCodeService.GenerateOpenLockNoTouchKeyA(request.AtmId, request.UserId,
                    request.Date, request.Hour, request.TimeBlock);

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

        /// <summary>
        /// Generates an operation code to open the lock using the inputs ATM ID and USER ID.
        /// </summary>
        /// <param name="request">OpenLockNowARequest</param>
        /// <returns>OperationCodeResponse</returns>
        [Route("OPEN_LOCK_NOW_1_A")]
        public OperationCodeResponse OpenLockNowA(OpenLockNowARequest request)
        {
            if (!ModelState.IsValid)
                return this.helper.CreateResponse<OperationCodeResponse>(this.resourceProvider.ResourceString("RequiredFields.Error"), ResponseStatus.Error);

            try
            {
                int opCode = this.operationCodeService.GenerateOpenLockNow1A(request.AtmId, request.UserId);

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

        /// <summary>
        /// Generates an operation code to open the lock using the inputs ATM ID and USER ID (2A).
        /// </summary>
        /// <param name="request">OpenLockNow2ARequest</param>
        /// <returns>OperationCodeResponse</returns>
        [Route("OPEN_LOCK_NOW_2_A")]
        public OperationCodeResponse OpenLockNow2A(OpenLockNow2ARequest request)
        {
            if (!ModelState.IsValid)
                return this.helper.CreateResponse<OperationCodeResponse>(this.resourceProvider.ResourceString("RequiredFields.Error"), ResponseStatus.Error);

            try
            {
                int opCode = this.operationCodeService.GenerateOpenLockNow2A(request.AtmId, request.UserId);

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

        /// <summary>
        /// Closes an active operation code.
        /// </summary>
        /// <param name="request">CloseCodeARequest</param>
        /// <returns>CloseCodeResponse</returns>
        [Route("CLOSE_CODE_A")]
        public CloseCodeResponse CloseCodeA(CloseCodeARequest request)
        {
            if (!ModelState.IsValid)
                return this.helper.CreateResponse<CloseCodeResponse>(this.resourceProvider.ResourceString("RequiredFields.Error"), ResponseStatus.Error);
            
            try
            {
                bool success = this.closeCodeService.CloseCodeA(request.OperationCode, request.AtmId, request.OperationResult);
                var responseBody = new CloseCodeResponseBody { CodeClosed = success };
                return this.helper.CreateResponse<CloseCodeResponse, CloseCodeResponseBody>(string.Empty,
                    ResponseStatus.Ok, responseBody);
            }
            catch (BaseException ex)
            {
                return CreateErrorResponse<CloseCodeResponse>(ex);
            }
            catch (Exception ex)
            {
                string errorId = this.eventLogService.LogUnhandledException(request, ex);
                return this.helper.CreateUnhandledResponse<CloseCodeResponse>(errorId);
            }   
        }

        /// <summary>
        /// Closes an operation code using the A-Seal value.
        /// </summary>
        /// <param name="request">CloseCodeViaSealARequest</param>
        /// <returns>CloseCodeResponse</returns>
        [Route("CLOSE_CODE_A_SEAL_A")]
        public CloseCodeResponse CloseCodeViaSealA(CloseCodeViaSealARequest request)
        {
            if (!ModelState.IsValid)
                return this.helper.CreateResponse<CloseCodeResponse>(this.resourceProvider.ResourceString("RequiredFields.Error"), ResponseStatus.Error);

            try
            {
                bool success = this.closeCodeService.CloseCodeViaSealA(request.UserId, request.OperationResult);
                var responseBody = new CloseCodeResponseBody { CodeClosed = success };
                return this.helper.CreateResponse<CloseCodeResponse, CloseCodeResponseBody>(string.Empty,
                    ResponseStatus.Ok, responseBody);
            }
            catch (BaseException ex)
            {
                return CreateErrorResponse<CloseCodeResponse>(ex);
            }
            catch (Exception ex)
            {
                string errorId = this.eventLogService.LogUnhandledException(request, ex);
                return this.helper.CreateUnhandledResponse<CloseCodeResponse>(errorId);
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