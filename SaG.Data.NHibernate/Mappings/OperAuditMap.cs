using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class OperAuditMap : ClassMap<OperAudit> {
        
        public OperAuditMap() {
			Table("tblOperAudit");
            Not.LazyLoad();
			Id(x => x.AuditId).GeneratedBy.Identity().Column("AuditID");
			Map(x => x.OperatorName).Column("OperatorName");
			Map(x => x.AuditDateTime).Column("AuditDateTime");
			Map(x => x.ChangeType).Column("ChangeType").Not.Nullable();
			Map(x => x.SubjectId).Column("SubjectID").Not.Nullable();
			Map(x => x.FunctionKey).Column("FunctionKey");
			Map(x => x.FunctionId).Column("FunctionID");
			Map(x => x.LocationId).Column("LocationID");
            References(x => x.APIClient).Column("APIClientId").Not.Nullable();
            References(x => x.Operator).Column("AccessorID").Not.Nullable();
            this.MapAuditable();
        }
    }
}
