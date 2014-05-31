using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class RptTkUserAuditMap : ClassMap<RptTkUserAudit> {
        
        public RptTkUserAuditMap() {
			Table("tblRptTkUserAudit");
            Not.LazyLoad();
			Id(x => x.AuditId).GeneratedBy.Identity().Column("AuditID");
			Map(x => x.AtmId).Column("AtmID");
			Map(x => x.SiteName).Column("SiteName");
			Map(x => x.LockId).Column("LockID");
			Map(x => x.Operation).Column("Operation");
			Map(x => x.Result).Column("Result");
			Map(x => x.UploadDate).Column("UploadDate");
			Map(x => x.Duration).Column("Duration");
            this.MapAuditable();
        }
    }
}
