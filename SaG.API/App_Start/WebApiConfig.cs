using System.Web.Http;
using SaG.Core;

namespace SaG.API
{
    public class WebApiConfig : IInitializer
    {   
        public void Initialize()
        {
            GlobalConfiguration.Configure(Register);
        }

        private static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();   
        }
    }
}
