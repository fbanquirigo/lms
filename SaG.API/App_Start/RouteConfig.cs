using System.Web.Mvc;
using System.Web.Routing;
using SaG.Core;

namespace SaG.API
{
    public class RouteConfig : IInitializer
    {
        private readonly RouteCollection routes;

        public RouteConfig(RouteCollection routes)
        {
            this.routes = routes;
        }

        public void Initialize()
        {
            this.routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            this.routes.MapMvcAttributeRoutes();   
        }
    }
}