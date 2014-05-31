using System.Linq;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class RouteDescRepository : Repository<RouteDesc>, IRouteDescRepository
    {
        public RouteDescRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {   
        }

        public RouteDesc GetByRouteId(string routeId)
        {
            return Query.FirstOrDefault(x => x.RouteId == routeId);
        }
    }
}
