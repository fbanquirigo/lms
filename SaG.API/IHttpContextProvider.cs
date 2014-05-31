using System.Web;

namespace SaG.API
{
    public interface IHttpContextProvider
    {
        HttpContext HttpContext { get; }  
    }
}