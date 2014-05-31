using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface IAPIClientRepository : IRepository<APIClient>
    {
        APIClient GetApiClient(string clientId);

        bool ClientExists(string clientId);
    }
}