using System.Web.Http;
using System.Web.Mvc;
using SaG.API.Environments;

namespace SaG.API.Areas.RouteDebugger
{
    public class RouteDebuggerAreaRegistration : AreaRegistration
    {
        private IApplicationEnvironment environment;

        public override string AreaName
        {
            get
            {
                return "RouteDebugger";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            if (context.State is IApplicationEnvironment)
                this.environment = context.State as IApplicationEnvironment;


            if (this.environment != null && this.environment.Name == "Production")
                return;

            context.MapRoute(
                "RouteDebugger_default",
                "rd/{action}",
                new { controller = "RouteDebugger", action = "Index" });
            RouteDebuggerConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
