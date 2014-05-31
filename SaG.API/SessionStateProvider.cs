using System.Web;

namespace SaG.API
{
    public class SessionStateProvider : ISessionStateProvider
    {

        public object this[string key]
        {
            get
            {
                return HttpContext.Current.Session[key];
            }
            set
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
}