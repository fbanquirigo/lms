using System.Web.Mvc;

namespace SaG.API.Areas.Management
{
    public class ManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Management";  }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
        }
    }
}