using System.Linq;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class APIClientRepository : Repository<APIClient>, IAPIClientRepository
    {
        public APIClientRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {   
        }

        public APIClient GetApiClient(string clientId)
        {
            return Query.SingleOrDefault(x => x.ConsumerKey == clientId);
        }    

        public bool ClientExists(string clientId)
        {
            return Query.Any(x => x.ConsumerKey == clientId);
        }
    }
}
