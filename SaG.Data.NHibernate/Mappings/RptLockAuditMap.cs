using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class RptLockAuditMap : ClassMap<RptLockAudit> {
        
        public RptLockAuditMap() {
			Table("tblRptLockAudit");
            Not.LazyLoad();
			Id(x => x.AuditId).GeneratedBy.Identity().Column("AuditID");
			Map(x => x.User).Column("User");
			Map(x => x.Operation).Column("Operation");
			Map(x => x.Result).Column("Result");
			Map(x => x.UploadDate).Column("UploadDate");
			Map(x => x.Duration).Column("Duration");
			Map(x => x.KeyIdBankUser).Column("KeyID_BankUser");
			Map(x => x.KeyType).Column("KeyType");
			Map(x => x.DispatcherId).Column("DispatcherID");
            this.MapAuditable();
        }
    }
}
