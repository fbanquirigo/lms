using System.Web.Optimization;
using SaG.Core;

namespace SaG.API
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
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            this.bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // jQuery
            this.bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // jQuery validate
            this.bundles.Add(new ScriptBundle("~/bundles/jquery.validate").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // twitter bootstrap
            this.bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/bootstrap.css"));

            this.bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js"));

            // angular
            this.bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js"));

            // bootstrap + site
            this.bundles.Add(new StyleBundle("~/Content/site").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css"));     

            // bootstrap datepicker
            this.bundles.Add(new StyleBundle("~/Content/bootstrap-datepicker").Include(
                        "~/Content/bootstrap-datepicker.css"));
            this.bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
                "~/Scripts/bootstrap-datepicker.js"));
        }
    }
}