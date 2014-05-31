namespace SaG.Core.Security
{
    public interface ISecurityContextFactory
    {
        ISecurityContext CreateContext();
    }
}