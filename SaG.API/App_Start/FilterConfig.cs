using System.Web.Http.Filters;
using System.Web.Mvc;
using SaG.API.Filters;
using SaG.Core;

namespace SaG.API
{
    public class FilterConfig : IInitializer
    {
        private readonly GlobalFilterCollection filters;
        private readonly ResourceFilter resourceFilter;
        private readonly TokenAuthorizationFilter tokenAuthorizationFilter;
        private readonly APIControllerResourceFilter apiControllerResourceFilter;
        private readonly HttpFilterCollection httpFilters;
        private readonly HandleAndLogErrorAttribute handleErrorAttribute;

        public FilterConfig(GlobalFilterCollection filters, 
            HttpFilterCollection httpFilters,
            ResourceFilter resourceFilter, 
            TokenAuthorizationFilter tokenAuthorizationFilter,
            APIControllerResourceFilter apiControllerResourceFilter,
            HandleAndLogErrorAttribute handleErrorAttribute)
        {
            this.filters = filters;
            this.httpFilters = httpFilters;
            this.resourceFilter = resourceFilter;
            this.tokenAuthorizationFilter = tokenAuthorizationFilter;
            this.apiControllerResourceFilter = apiControllerResourceFilter;
            this.handleErrorAttribute = handleErrorAttribute;
        }

        public void Initialize()
        {
            this.filters.Add(this.handleErrorAttribute);
            this.filters.Add(this.resourceFilter);
            this.httpFilters.Add(this.tokenAuthorizationFilter);
            this.httpFilters.Add(this.apiControllerResourceFilter);
        }
    }
}