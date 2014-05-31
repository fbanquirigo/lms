using System;
using System.Web.Http;
using SaG.API.Models;
using SaG.API.Models.Responses;
using SaG.API.Security;
using SaG.Core.Logging;
using SaG.Services.Contracts;

namespace SaG.API.Controllers
{
    /// <summary>
    /// System information API methods
    /// </summary>
    public class SystemInfoController : ApiControllerBase
    {
        private readonly ILogger logger;
        private readonly ISystemInformationService informationService;
        private readonly IResponseHelper helper;

        /// <summary>
        /// Creates a new instance of SystemInfoController
        /// </summary>
        public SystemInfoController(ILogger logger, ISystemInformationService informationService,
            IResponseHelper helper)
        {
            this.logger = logger;
            this.informationService = informationService;
            this.helper = helper;
        }

        /// <summary>
        /// Returns the API's system information.
        /// </summary>
        /// <returns>SystemInfoResponse</returns>
        [Route("SystemInfo")]
        [SkipTokenCheck]
        public SystemInfoResponse Get()
        {
            this.logger.InfoFormat("System Information Requested on {0}", DateTime.Now);
            var responseBody = new SystemInfoResponseBody
                   {
                       SystemVersion = this.informationService.GetSystemVersion(),
                       ProductName = this.informationService.GetProductName()
                   };
            return this.helper.CreateResponse<SystemInfoResponse, SystemInfoResponseBody>(responseBody);
        }
    }
}