using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class UserMap : ClassMap<User> {
        
        public UserMap() {
			Table("tblUsers");
            Not.LazyLoad();
			Id(x => x.AccessorId).GeneratedBy.Identity().Column("AccessorID");
			References(x => x.Accessor).Column("AccessorID");
			References(x => x.Level).Column("Level");
			Map(x => x.Location).Column("Location");
			Map(x => x.Pin).Column("PIN");
			Map(x => x.GroupId).Column("GroupID");
			Map(x => x.PhoneNo).Column("PhoneNo");
			Map(x => x.PagerNo).Column("PagerNo");
			Map(x => x.UserType).Column("UserType").Not.Nullable();
			Map(x => x.Status).Column("Status").Not.Nullable();
			Map(x => x.LocationId).Column("LocationID");
            this.MapAuditable();
        }
    }
}
