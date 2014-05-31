using System.Web.Mvc;

namespace SaG.API.Controllers
{
    /// <summary>
    /// HomeController
    /// </summary>
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Index
        /// </summary>
        /// <returns>ViewResult</returns>
        [Route("")]
        public ViewResult Index()
        {   
            return View();
        }      
    }
}
