using System.Web.Compilation;
using System.Web.Mvc;

namespace SaG.API.Filters
{
    public class ResourceFilter : IResultFilter
    {
        private readonly IResourceProvider resourceProvider;

        public ResourceFilter(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.ResourceProvider = this.resourceProvider;
        }
    }
}