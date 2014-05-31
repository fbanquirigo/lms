using System.Web.Compilation;
using System.Web.Http;

namespace SaG.API
{
    /// <summary>
    /// API Controller base class
    /// </summary>
    public abstract class ApiControllerBase : ApiController
    {
        /// <summary>
        /// Resource provider
        /// </summary>
        public IResourceProvider ResourceProvider { get; set; }
    }
}