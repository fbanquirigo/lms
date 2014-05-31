using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using SaG.API.Environments;
using SaG.Core;

namespace SaG.API
{
    public class WebApplicationConfig : IInitializer
    {
        private readonly IDependencyResolver resolver;
        private readonly APICompositionRoot compositionRoot;
        private readonly IApplicationEnvironment environment;

        public WebApplicationConfig(DependencyResolver resolver, APICompositionRoot compositionRoot, IApplicationEnvironment environment)
        {
            this.resolver = resolver;
            this.compositionRoot = compositionRoot;
            this.environment = environment;
        }

        public void Initialize()
        {
            AreaRegistration.RegisterAllAreas(this.environment);
            System.Web.Mvc.DependencyResolver.SetResolver(this.resolver);
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                this.compositionRoot);
        }
    }
}