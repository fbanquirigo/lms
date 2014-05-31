using System.Web.Mvc;

namespace SaG.API.Areas.Management.Controllers
{
    [RouteArea("Management", AreaPrefix = "management")]
    public class HomeController : ControllerBase
    {
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }
    }
}