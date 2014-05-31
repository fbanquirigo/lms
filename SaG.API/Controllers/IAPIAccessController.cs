using SaG.API.Models.Requests;
using SaG.API.Models.Responses;

namespace SaG.API.Controllers
{
    /// <summary>
    /// IAPIAccessController
    /// </summary>
    public interface IAPIAccessController
    {
        /// <summary>
        /// Returns an AccessTokenResponse based on the AccessTokenRequest
        /// </summary>
        /// <param name="request">AccessTokenRequest</param>
        /// <returns>AccessTokenResponse</returns>
        AccessTokenResponse GetAccessToken(AccessTokenRequest request);

        /// <summary>
        /// Kills an access token
        /// </summary>
        /// <returns>AccessTokenExpiresResponse</returns>
        AccessTokenExpiresResponse KillAccessToken();
    }
}