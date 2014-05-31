using SaG.Business.Models;

namespace SaG.Services.Contracts
{
    public interface IAPIClientService
    {
        bool ValidClient(string clientId);

        bool ValidateClient(string clientId, string clientSecret);

        APIClient GetClient(string consumerKey);
    }
}