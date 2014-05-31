using System.Globalization;
using System.Web.Compilation;
using System.Web.Mvc;

namespace SaG.API
{
    /// <summary>
    /// Web View base class
    /// </summary>
    public abstract class BaseWebViewPage<T> : WebViewPage<T>
    {
        /// <summary>
        /// Resources
        /// </summary>
        public IResourceProvider Resources
        {
            get
            {
                return ViewBag.ResourceProvider as IResourceProvider;
            }
        }

        /// <summary>
        /// Returns a string resource based on a given key.
        /// </summary>
        /// <param name="resourceKey">string</param>
        /// <returns>string</returns>
        public string ResourceString(string resourceKey)
        {
            return ResourceString(resourceKey, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns a string resource based on a given key and culture.
        /// </summary>
        /// <param name="resourceKey">string</param>
        /// <param name="culture">CultureInfo</param>
        /// <returns>string</returns>
        public string ResourceString(string resourceKey, CultureInfo culture)
        {
            object resource = Resources.GetObject(resourceKey, culture);
            return resource is string ? resource.ToString() : string.Format("##{0}", resourceKey); 
        }
    }

    /// <summary>
    /// Web view base class
    /// </summary>
    public abstract class BaseWebViewPage : BaseWebViewPage<object>
    {   
    }
}