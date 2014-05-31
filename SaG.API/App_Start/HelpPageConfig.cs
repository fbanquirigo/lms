using System.Web;
using System.Web.Http;
using SaG.API.Documentation;
using SaG.Core;
using WebGrease.Css.Extensions;

namespace SaG.API
{
    /// <summary>
    /// HelpPage Configuration
    /// </summary>
    public class HelpPageConfig : IInitializer
    {  
        private readonly HttpConfiguration config;
        private readonly IContainer container;

        /// <summary>
        /// HelpPage Configuration Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="container"></param>
        public HelpPageConfig(HttpConfiguration config, IContainer container)
        {
            this.config = config;
            this.container = container;
        }

        /// <summary>
        /// Configures HelpPage
        /// </summary>
        public void Initialize()
        {
            this.config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/SaG.API.xml")));
            var documenters = this.container.GetAllInstances<IAPIMethodDocumenter>();
            documenters.ForEach(x => x.Document(this.config)); 
        }
    }
}