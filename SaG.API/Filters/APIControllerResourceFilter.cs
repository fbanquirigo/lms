using System.Web.Compilation;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SaG.API.Filters
{
    public class APIControllerResourceFilter : ActionFilterAttribute
    {
        private readonly IResourceProvider resourceProvider;

        public APIControllerResourceFilter(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!(actionContext.ControllerContext.Controller is ApiControllerBase))
                return;

            var apiController = actionContext.ControllerContext.Controller as ApiControllerBase;
            apiController.ResourceProvider = resourceProvider;
        }
    }
}