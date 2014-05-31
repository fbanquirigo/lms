using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface ITouchKeyRepository : IKeyedRepository<TouchKey, string>
    {
        TouchKey Get(int accessorId);

        TouchKey Get(string touchKey, int accessorId);
    }
}