using SaG.API.Models;

namespace SaG.API.Controllers
{
    /// <summary>
    /// AtmController
    /// </summary>
    public class AtmController : ApiControllerBase
    {
        private readonly IResponseHelper helper;

        /// <summary>
        /// Creates a new instance of AtmController
        /// </summary>
        public AtmController(IResponseHelper helper)
        {
            this.helper = helper;
        }
    }
}