using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class DispatcherMap : ClassMap<Dispatcher> {
        
        public DispatcherMap() {
			Table("tblDispatchers");
            Not.LazyLoad();
			Id(x => x.DispEntity).GeneratedBy.Identity().Column("DispEntity");
			References(x => x.Owner).Column("OwnerEntity");
			Map(x => x.DispatchId).Column("DispatchID");
			Map(x => x.Name).Column("Name");
			Map(x => x.Location).Column("Location");
			Map(x => x.PhoneNo).Column("PhoneNo");
			Map(x => x.StartDate).Column("StartDate");
			Map(x => x.EndDate).Column("EndDate");
			Map(x => x.LastExport).Column("LastExport");
			Map(x => x.DispatcherBlock).Column("DispatcherBlock");
			Map(x => x.SystemOwner).Column("SystemOwner").Not.Nullable();
			Map(x => x.ExportStartDate).Column("ExportStartDate").Not.Nullable();
			Map(x => x.ExportEndDate).Column("ExportEndDate").Not.Nullable();
            this.MapAuditable();
        }
    }
}
