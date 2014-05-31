using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SaG.API.Security;
using SaG.Business;
using SaG.Core;

namespace SaG.API
{
    public class WebDependencyConfig : IContainerConfigurator
    {
        public void Configure(IContainerConfigurationExpression config)
        {
            config.For<HttpContext>().Use(HttpContext.Current);
            config.ForSingleton<RouteCollection>().Use(RouteTable.Routes);
            config.ForSingleton<GlobalFilterCollection>().Use(GlobalFilters.Filters);
            config.ForSingleton<HttpFilterCollection>().Use(GlobalConfiguration.Configuration.Filters);
            config.ForSingleton<HttpConfiguration>().Use(GlobalConfiguration.Configuration);
            config.ForSingleton<BundleCollection>().Use(BundleTable.Bundles);
            config.ForHybridHttpOrThreadLocalScoped<SecurityContext>().Use<SecurityContext>();    
            config.ForHybridHttpOrThreadLocalScoped<IOperatorContext>().Use<OperatorContext>();
            config.ForHybridHttpOrThreadLocalScoped<IConsumerContext>().Use<ConsumerContext>();
            config.ForHybridHttpOrThreadLocalScoped<IClientContext>().Use<ClientContext>();
            config.ForHybridHttpOrThreadLocalScoped<IAccessTokenContext>().Use<AccessTokenContext>();
        }
    }
}