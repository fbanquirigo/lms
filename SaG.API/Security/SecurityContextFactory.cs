using SaG.Core;
using SaG.Core.Security;

namespace SaG.API.Security
{
    public class SecurityContextFactory : ISecurityContextFactory
    {
        private readonly IContainer container;

        public SecurityContextFactory(IContainer container)
        {
            this.container = container;  
        }

        public ISecurityContext CreateContext()
        {
            return this.container.GetInstance<SecurityContext>();  
        }
    }
}