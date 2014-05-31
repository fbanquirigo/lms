using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class SystemMap : ClassMap<AppSystem> {
        
        public SystemMap() {
			Table("tblSystem");
            Not.LazyLoad();
			Id(x => x.SystemId).GeneratedBy.Identity().Column("SystemID");
			Map(x => x.ServerName).Column("ServerName");
			Map(x => x.BackupPath).Column("BackupPath");
			Map(x => x.SouthernHemisphere).Column("SouthernHemisphere");
			Map(x => x.Alarms).Column("Alarms");
			Map(x => x.BankModeLimit).Column("BankModeLimit");
			Map(x => x.TimeoutValue).Column("TimeoutValue").Not.Nullable();
			Map(x => x.SystemTimeZone).Column("SystemTimeZone").Not.Nullable();
			Map(x => x.DstStart).Column("DSTStart").Not.Nullable();
			Map(x => x.DstEnd).Column("DSTEnd").Not.Nullable();
            Map(x => x.APITimeZone).Column("APITimeZone").Nullable();
            Map(x => x.Location).Column("LocationId").Nullable();
            this.MapAuditable();
        }
    }
}
