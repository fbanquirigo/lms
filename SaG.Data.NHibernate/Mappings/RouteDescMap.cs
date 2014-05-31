using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class RouteDescMap : ClassMap<RouteDesc> {
        
        public RouteDescMap() {
			Table("tblRouteDescs");
            Not.LazyLoad();
			Id(x => x.RouteEntity).GeneratedBy.Identity().Column("RouteEntity");
			Map(x => x.RouteId).Column("RouteID");
			Map(x => x.Description).Column("Description");
			Map(x => x.Location).Column("Location");
			Map(x => x.DateUpdate).Column("DateUpdate");
			Map(x => x.LocationId).Column("LocationID");
            this.MapAuditable();
        }
    }
}
