using System.ComponentModel.DataAnnotations;
using System.Web.Compilation;
using SaG.API.Helpers;
using SaG.Core;

namespace SaG.API.Validators
{
    public class ParamRequiredAttribute : RequiredAttribute
    {
        private IResourceProvider resourceProvider;

        private IResourceProvider ResourceProvider
        {
            get
            {
                resourceProvider = resourceProvider ?? ServiceLocator.Current.GetInstance<IResourceProvider>();
                return resourceProvider;
            }
        }
        public ParamRequiredAttribute(string resourceName)
        {
            ErrorMessage = ResourceProvider.ResourceString(resourceName);
        }

        public ParamRequiredAttribute()
        {
            ErrorMessage = ResourceProvider.ResourceString("Required.Text");
        }
    }
}