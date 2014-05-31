using System.Web.Optimization;
using SaG.Core;

namespace SaG.API.Areas.APIClient
{
    public class BundleConfig : IInitializer
    {
        private readonly BundleCollection bundles;

        public BundleConfig(BundleCollection bundles)
        {
            this.bundles = bundles;
        }

        public void Initialize()
        {
            this.bundles.Add(new ScriptBundle("~/bundles/api-client").Include(  
                "~/Areas/APIClient/Scripts/components.js",
                "~/Areas/APIClient/Scripts/forms.js",
                "~/Areas/APIClient/Scripts/controllers.js",
                "~/Areas/APIClient/Scripts/app.js"));   
        }
    }
}