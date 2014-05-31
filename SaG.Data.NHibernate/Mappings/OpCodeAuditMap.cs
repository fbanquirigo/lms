using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class OpCodeAuditMap : ClassMap<OpCodeAudit> {
        
        public OpCodeAuditMap() {
			Table("tblOpCodeAudit");
            Not.LazyLoad();
			Id(x => x.OpCodeEntity).GeneratedBy.Identity().Column("OpCodeEntity");
			Map(x => x.StartDtTime).Column("StartDtTime");
			Map(x => x.EndDtTime).Column("EndDtTime");
			Map(x => x.AtmId).Column("AtmID");
			Map(x => x.CmdDesc).Column("CmdDesc");
			Map(x => x.RouteId).Column("RouteID");
			Map(x => x.TouchKeyId).Column("TouchKeyID");
			Map(x => x.UserType).Column("UserType");
			Map(x => x.OperCode).Column("OperCode");
			Map(x => x.Duration).Column("Duration");
			Map(x => x.LockId).Column("LockID");
			Map(x => x.LockResult).Column("LockResult");
			Map(x => x.SessStartDtTime).Column("SessStartDtTime");
			Map(x => x.DtTmClosed).Column("DtTmClosed");
			Map(x => x.UserName).Column("UserName");
			Map(x => x.OperName).Column("OperName");
			Map(x => x.SiteName).Column("SiteName");
			Map(x => x.SiteAddress).Column("SiteAddress");
			Map(x => x.UserEmployeeId).Column("UserEmployeeID");
			Map(x => x.LinkDispId).Column("LinkDispID");
			Map(x => x.LocationId).Column("LocationID");
            this.MapAuditable();
        }
    }
}
