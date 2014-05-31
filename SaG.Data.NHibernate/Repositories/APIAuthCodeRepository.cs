using System.Linq;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class APIAuthCodeRepository : Repository<APIAuthCode>, IAPIAuthCodeRepository
    {
        public APIAuthCodeRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {   
        }

        public bool AuthCodeExists(string authCode)
        {
            return Query.Any(x => x.AuthCode == authCode);
        }       

        public APIAuthCode GetAuthCode(string authCode)
        {
            return Query.SingleOrDefault(x => x.AuthCode == authCode);
        }
    }
}
