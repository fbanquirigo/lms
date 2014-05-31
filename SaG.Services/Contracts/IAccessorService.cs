using SaG.Business.Models;

namespace SaG.Services.Contracts
{
    public interface IAccessorService
    {
        Accessor GetAccessor(int accessorId);
    }
}