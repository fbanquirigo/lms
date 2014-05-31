using System.Web;
using StackExchange.Profiling;

namespace SaG.API
{ 
    public class WebApiApplication : HttpApplication
    { 
        protected void Application_Start()
        {
            BootstrapperConfig.Boot();   
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal) MiniProfiler.Start(); 
        }

        protected void Application_EndRequest()
        {
            BootstrapperConfig.CleanUp();
            MiniProfiler.Stop(); 
        }
    }
}