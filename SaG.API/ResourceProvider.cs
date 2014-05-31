using System;
using System.Resources;
using System.Web.Compilation;

namespace SaG.API
{
    public class ResourceProvider : IResourceProvider
    {
        private readonly ResourceManager resourceManager;

        public ResourceProvider(ResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        public object GetObject(string resourceKey, System.Globalization.CultureInfo culture)
        {
            return this.resourceManager.GetObject(resourceKey, culture);
        }

        public IResourceReader ResourceReader
        {
            get { throw new NotImplementedException(); }
        }
    }
}