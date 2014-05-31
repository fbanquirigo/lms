using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class LinkOperIDMap : ClassMap<LinkOperID> {
        
        public LinkOperIDMap() {
			Table("tblLinkOperIDs");
            Not.LazyLoad();
			Id(x => x.DispId).GeneratedBy.Assigned().Column("Disp_ID");
			Map(x => x.Password).Column("Password");
			Map(x => x.Priority).Column("Priority");
			Map(x => x.Description).Column("Description");
			Map(x => x.Enable).Column("Enable");
			Map(x => x.LocationId).Column("LocationID");
			Map(x => x.LogOn).Column("LogOn");
            this.MapAuditable();
        }
    }
}
