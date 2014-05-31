using System.Web.Mvc;
using SaG.API.Areas.APIClient.Models;

namespace SaG.API.Areas.APIClient.Controllers
{
    [RouteArea("APIClient", AreaPrefix = "client")]
    public class TemplateController : ControllerBase
    {
        private readonly IMenuManager menuManager;
        private readonly IHttpContextProvider httpContext;

        public TemplateController(IMenuManager menuManager, IHttpContextProvider httpContext)
        {
            this.menuManager = menuManager;
            this.httpContext = httpContext;
        }

        [Route("templates/{template}")]
        [Route("templates/{template}/{debug}")]
        public ActionResult Template(string template, string debug)
        {
            if ((debug ?? string.Empty).ToLower() == "debug")
                TempData["Debug"] = true;
            switch (template.ToLower())
            {
                case "tabs":
                    return PartialView("Templates/_tabs");
                case "pane":
                    return PartialView("Templates/_pane");
                case "panel":
                    return PartialView("Templates/_panel");
                case "requestcontrol":
                    return PartialView("Templates/_requestControl");
                default:
                    return new HttpNotFoundResult();
            }
        }

        [Route("forms/{formName}")]
        [Route("forms/{formName}/{debug}")]
        public ActionResult Form(string formName, string debug)
        {
            if((debug ?? string.Empty).ToLower() == "debug")
                TempData["Debug"] = true;
            switch (formName.ToLower())
            {
                // browse
                case "atms":
                    return PartialView("Forms/_Atms");
                case "users":
                    return PartialView("Forms/_Users");

                // A Series
                case "openlocka":
                    return PartialView("Forms/_OpenLockA");
                case "openlocknotouchkeya":
                    return PartialView("Forms/_OpenLockNoTouchKeyA");
                case "openlocknow1a":
                    return PartialView("Forms/_OpenLockNow1A");
                case "openlocknow2a":
                    return PartialView("Forms/_OpenLockNow2A");
                case "closecodea":
                    return PartialView("Forms/_CloseCodeA");
                case "closecodeviaaseala":
                    return PartialView("Forms/_CloseCodeViaASealA");

                // B Series
                case "openlockb":
                    return PartialView("Forms/_OpenLockB");
                case "openlocknotouchkeyb":
                    return new HttpNotFoundResult();
                case "openlocknow1b":
                    return PartialView("Forms/_OpenLockNow1B");
                case "closecodeb":
                    return new HttpNotFoundResult();
                case "closecodeviaasealb":
                    return new HttpNotFoundResult();

                // C Series
                case "openlockc":
                    return PartialView("Forms/_OpenLockC");
                case "openlocknotouchkeyc":
                    return new HttpNotFoundResult();
                case "openlocknow1c":
                    return new HttpNotFoundResult();
                case "closecodec":
                    return new HttpNotFoundResult();
                case "closecodeviaasealc":
                    return new HttpNotFoundResult();

                // misc
                case "error":
                    return PartialView("Forms/_Error");   
                default:
                    return PartialView("Forms/_Error");
            } 
        }

        [Route("forms/methodlist/{series}")]
        [Route("forms/methodlist/{series}/{debug}")]
        public ActionResult MethodList(string series, string debug)
        {
            if ((debug ?? string.Empty).ToLower() == "debug")
                TempData["Debug"] = true;
            string methodsPathConfig = this.httpContext.HttpContext.Server.MapPath(Url.Content(string.Format("~/Areas/APIClient/{0}-methods.xml", series)));
            if(!System.IO.File.Exists(methodsPathConfig))
                return new HttpNotFoundResult();

            MethodList methodList = this.menuManager.GetMethodList(methodsPathConfig);
            if(methodList == null)
                return new HttpNotFoundResult();

            return PartialView("Forms/_MethodList", methodList);
        }
    }
}