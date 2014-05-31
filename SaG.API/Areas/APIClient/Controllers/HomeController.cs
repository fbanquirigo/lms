using System.Web.Mvc;

namespace SaG.API.Areas.APIClient.Controllers
{
    [RouteArea("APIClient", AreaPrefix = "client")]
    public class HomeController : ControllerBase
    {
        private readonly ISessionStateProvider session;

        public HomeController(ISessionStateProvider session)
        {
            this.session = session;
        }

        [Route("")]
        public ActionResult Index()
        {
            return (this.session["accessToken"] == null)
                ? RedirectToAction("Login", "Client")
                : RedirectToAction("Dashboard", "Client");
        }

    }
}
