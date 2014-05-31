using System.Linq;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class APIAccessTokenRepository : Repository<APIAccessToken>, IAPIAccessTokenRepository
    {    
        public APIAccessTokenRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {  
        }

        public bool AccessTokenExists(string accessToken, string clientId)
        {
            return Query.Any(x => x.AccessToken == accessToken
                                                                 && x.Client.ConsumerKey == clientId);
        }

        public APIAccessToken GetAccessToken(string accessToken, string clientId)
        {
            return Query.SingleOrDefault(x => x.AccessToken == accessToken
                                                                        && x.Client.ConsumerKey == clientId);
        } 

        public APIAccessToken GetAccessToken(string accessToken)
        {
            return Query.SingleOrDefault(x => x.AccessToken == accessToken);
        }
    }
}