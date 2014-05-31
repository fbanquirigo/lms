using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class TouchKeyMap : ClassMap<TouchKey> {
        
        public TouchKeyMap() {
			Table("tblTouchKeys");
            Not.LazyLoad();
			Id(x => x.TouchKeyId).GeneratedBy.Assigned().Column("TouchKeyID");
			References(x => x.Accessor).Column("AccessorID");
			Map(x => x.TypeKey).Column("TypeKey");
			Map(x => x.BlockCount).Column("BlockCount");
			Map(x => x.Status).Column("Status").Not.Nullable();
			Map(x => x.LocationId).Column("LocationID");
            this.MapAuditable();
        }
    }
}
