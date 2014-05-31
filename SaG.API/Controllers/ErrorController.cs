using System.Web.Mvc;

namespace SaG.API.Controllers
{
    /// <summary>
    /// ErrorController
    /// </summary>
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// Default Error Page
        /// </summary>
        [Route("error")]
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// Error Pages
        /// </summary>
        [Route("error/{code}")]
        public ActionResult Error(int code)
        { 
            switch (code)
            {
                case 404:
                    return View("Error404");
                case 500:
                    return View("Error500");
                default:
                    return View("Index");
            }

        }
    }
}