using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface IAPIAuthCodeRepository : IRepository<APIAuthCode>
    {
        bool AuthCodeExists(string authCode);

        APIAuthCode GetAuthCode(string authCode);
    }
}