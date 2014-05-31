namespace SaG.Core.Security
{
    public interface ISecurityContext
    {
        ISystemUser User { get; }     
    }
}