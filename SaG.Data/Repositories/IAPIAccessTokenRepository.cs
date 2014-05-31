using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface IAPIAccessTokenRepository : IRepository<APIAccessToken>
    {
        bool AccessTokenExists(string accessToken, string clientId);

        APIAccessToken GetAccessToken(string accessToken, string clientId);

        APIAccessToken GetAccessToken(string accessToken);
    }
}