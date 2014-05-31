
using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class AlarmMap : ClassMap<Alarm> {
        
        public AlarmMap() {
			Table("tblAlarms");
            Not.LazyLoad();
			Id(x => x.AlarmId).GeneratedBy.Identity().Column("AlarmID");
			Map(x => x.DateRecorded).Column("DateRecorded").Not.Nullable();
			Map(x => x.AlarmType).Column("AlarmType");
			Map(x => x.AlarmKey).Column("AlarmKey");
			Map(x => x.AlarmDesc).Column("AlarmDesc");
			Map(x => x.AcknowledgedFlag).Column("AcknowledgedFlag").Not.Nullable();
			Map(x => x.DateAcknowledged).Column("DateAcknowledged");
			Map(x => x.OperatorName).Column("OperatorName");
            this.MapAuditable();
        }
    }
}
