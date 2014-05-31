using System.Reflection;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class SystemInformationService : ISystemInformationService
    {
        private readonly Assembly assembly;

        public SystemInformationService()
        {
            this.assembly = Assembly.GetExecutingAssembly();
        }

        public string GetSystemVersion()
        {
            return assembly.GetName().Version.ToString();
        }

        public string GetProductName()
        {
            return "Sargent and Greenleaf Lock Management API";
        }
    }
}
