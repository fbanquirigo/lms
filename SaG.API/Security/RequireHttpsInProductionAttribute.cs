using System.Web.Mvc;

namespace SaG.API.Security
{
    public class RequireHttpsInProductionAttribute : RequireHttpsAttribute
    {
        private bool IsProduction { get { return false; } }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsProduction)
                return;

            base.OnAuthorization(filterContext);
        }
    }
}