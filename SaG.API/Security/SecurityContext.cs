using SaG.Core.Security;

namespace SaG.API.Security
{
    public class SecurityContext : ISecurityContext
    {   
        public ISystemUser User
        {
            get; set;
        }
    }
}