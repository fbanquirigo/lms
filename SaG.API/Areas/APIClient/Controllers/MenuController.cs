using System.Web.Mvc;
using SaG.API.Areas.APIClient.Models;

namespace SaG.API.Areas.APIClient.Controllers
{
    [RouteArea("APIClient", AreaPrefix = "client")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuManager menuManager;
        private readonly IHttpContextProvider httpContext;

        public MenuController(IMenuManager menuManager, IHttpContextProvider httpContext)
        {
            this.menuManager = menuManager;
            this.httpContext = httpContext;
        }

        [Route("menu")]
        public ActionResult Index()
        {
            const string menuConfig = "menu.xml";
             
            string menuPathConfig = this.httpContext.HttpContext.Server.MapPath(Url.Content(string.Format("~/Areas/APIClient/{0}", menuConfig)));
            if(!System.IO.File.Exists(menuPathConfig))
                return new HttpNotFoundResult();

            SiteMenu siteMenu = this.menuManager.GetMenu(menuPathConfig);  
            if(siteMenu == null)
                return new HttpNotFoundResult();  
            return Json(siteMenu.Menus, JsonRequestBehavior.AllowGet);
        }
    }
}