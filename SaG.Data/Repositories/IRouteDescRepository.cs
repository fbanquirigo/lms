using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface IRouteDescRepository : IRepository<RouteDesc>
    {
        RouteDesc GetByRouteId(string routeId);
    }
}