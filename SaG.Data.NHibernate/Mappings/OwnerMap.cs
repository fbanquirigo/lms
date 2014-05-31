using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class OwnerMap : ClassMap<Owner> {
        
        public OwnerMap() {
			Table("tblOwners");
            Not.LazyLoad();
			Id(x => x.OwnerEntity).GeneratedBy.Identity().Column("OwnerEntity");
			Map(x => x.OwnerId).Column("OwnerID");
			Map(x => x.Name).Column("Name");
			Map(x => x.Location).Column("Location");
			Map(x => x.ContactName).Column("ContactName");
			Map(x => x.PhoneNo).Column("PhoneNo");
			Map(x => x.SystemOwner).Column("SystemOwner").Not.Nullable();
			Map(x => x.MasterKey0).Column("MasterKey0");
			Map(x => x.MasterKey1).Column("MasterKey1");
            this.MapAuditable();
        }
    }
}
