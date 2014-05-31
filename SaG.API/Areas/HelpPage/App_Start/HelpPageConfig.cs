using System.Web;
using System.Web.Http;
using SaG.Core;
using WebGrease.Css.Extensions;

namespace SaG.API.Areas.HelpPage
{
    public class HelpPageConfig : IInitializer
    {
        private readonly HttpConfiguration config;
        private readonly IContainer container;

        public HelpPageConfig(IContainer container, HttpConfiguration config)
        {
            this.config = config;
            this.container = container;
        }

        public void Initialize()
        {
            var documenters = this.container.GetAllInstances<IApiDocumenter>();
            documenters.ForEach(x => x.Document());
            this.config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/SaG.API.xml")));
        }
    }
}