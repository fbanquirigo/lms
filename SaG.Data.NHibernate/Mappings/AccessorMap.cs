using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class AccessorMap : ClassMap<Accessor> {
        
        public AccessorMap() {
			Table("tblAccessor");
            Not.LazyLoad();
			Id(x => x.AccessorId).GeneratedBy.Identity().Column("AccessorID");
			Map(x => x.FirstName).Column("FirstName");
			Map(x => x.MiddleName).Column("MiddleName");
			Map(x => x.LastName).Column("LastName");
			Map(x => x.EmployeeId).Column("EmployeeID");
			Map(x => x.AccessorType).Column("AccessorType").Not.Nullable();
			this.MapAuditable();
        }
    }
}
