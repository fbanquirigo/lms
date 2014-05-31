using SaG.Business.Models;

namespace SaG.Services.Contracts
{
    public interface IAuthenticationService
    {
        string GenerateAuthCode(APIClient client, Operator user);

        bool ValidateAuthCode(string authCode, string clientId);

        string GenerateAccessToken(string authCode, string clientId);

        bool KillAccessToken(string accessToken);

        bool ValidAccessToken(string accessToken);

        APIAccessToken GetAccessToken(string accessToken);
    }
}