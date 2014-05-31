using System.Web;

namespace SaG.API
{
    public class HttpContextProvider : IHttpContextProvider
    {
        public HttpContext HttpContext
        {
            get { return HttpContext.Current; }
        }
    }
}