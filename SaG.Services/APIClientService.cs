using SaG.Business.Models;
using SaG.Data.Repositories;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class APIClientService : IAPIClientService
    {
        private readonly IAPIClientRepository repository;

        public APIClientService(IAPIClientRepository repository)
        {
            this.repository = repository;
        }

        public bool ValidClient(string clientId)
        {
            return this.repository.ClientExists(clientId);
        } 

        public bool ValidateClient(string clientId, string clientSecret)
        {
            APIClient client = this.repository.GetApiClient(clientId);
            if (client == null)
                return false;

            return client.ConsumerSecret == clientSecret;
        }   

        public APIClient GetClient(string consumerKey)
        {
            return this.repository.GetApiClient(consumerKey);
        }
    }
}
