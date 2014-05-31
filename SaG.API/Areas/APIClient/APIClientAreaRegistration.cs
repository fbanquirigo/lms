using System.Web.Mvc;

namespace SaG.API.Areas.APIClient
{
    public class APIClientAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "APIClient";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
        }
    }
}
