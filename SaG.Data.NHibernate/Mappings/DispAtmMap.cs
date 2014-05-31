using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class DispAtmMap : ClassMap<DispAtm> {
        
        public DispAtmMap() {
			Table("tblDispATMs");
            Not.LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id");
			References(x => x.Atm).Column("AtmEntity");
			References(x => x.Dispatcher).Column("DispEntity");
			Map(x => x.KeyDispatcher0).Column("KeyDispatcher0");
			Map(x => x.KeyDispatcher1).Column("KeyDispatcher1");
			Map(x => x.AtmType).Column("AtmType").Not.Nullable();
			Map(x => x.StartDate).Column("StartDate").Not.Nullable();
			Map(x => x.EndDate).Column("EndDate").Not.Nullable();
			Map(x => x.ToRemove).Column("ToRemove").Not.Nullable();
            this.MapAuditable();
        }
    }
}
