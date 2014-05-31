using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class RouteAtmMap : ClassMap<RouteAtm> {
        
        public RouteAtmMap() {
			Table("tblRouteATMs");
            Not.LazyLoad();
			CompositeId().KeyProperty(x => x.AtmEntity, "AtmEntity")
			             .KeyProperty(x => x.RouteEntity, "RouteEntity");
			References(x => x.AtM).Column("AtmEntity");
			References(x => x.RouteDesc).Column("RouteEntity");
            this.MapAuditable();
        }
    }
}
