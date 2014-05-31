using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class LockResultMap : ClassMap<LockResult> {
        
        public LockResultMap() {
			Table("tblLockResult");
            Not.LazyLoad();
			Id(x => x.ResultCode).GeneratedBy.Assigned().Column("ResultCode");
			Map(x => x.ResultDesc).Column("ResultDesc");
            this.MapAuditable();
        }
    }
}
