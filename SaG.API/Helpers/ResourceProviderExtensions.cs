using System.Globalization;
using System.Web.Compilation;

namespace SaG.API.Helpers
{
    public static class ResourceProviderExtensions
    {
        public static string ResourceString(this IResourceProvider resourceProvider, string resourceKey)
        {
            return ResourceString(resourceProvider, resourceKey, CultureInfo.CurrentCulture);
        }

        public static string ResourceString(this IResourceProvider resourceProvider, 
            string resourceKey, CultureInfo culture)
        {
            object resource = resourceProvider.GetObject(resourceKey, culture);
            return resource is string ? resource.ToString() : string.Format("##{0}", resourceKey);     
        }
    }
}