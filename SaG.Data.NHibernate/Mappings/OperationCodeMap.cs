using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class OperationCodeMap : ClassMap<OperationCode> {
        
        public OperationCodeMap() {
			Table("tblOperationCodes");
            Not.LazyLoad();
			Id(x => x.OpCodeEntity).GeneratedBy.Identity().Column("OpCodeEntity");
			References(x => x.Atm).Column("AtmEntity");
			References(x => x.Cmd).Column("CmdID");
			References(x => x.TouchKey).Column("TouchKeyID");
			References(x => x.RouteDesc).Column("RouteEntity");
			References(x => x.OpCodeRecipient).Column("OpCodeRecipient");
			References(x => x.OpCodeCreator).Column("OpCodeCreator");
			Map(x => x.UserType).Column("UserType");
			Map(x => x.Code).Column("OperationCode");
			Map(x => x.DateAssigned).Column("DateAssigned");
			Map(x => x.StartDateTime).Column("StartDateTime");
			Map(x => x.EndDateTime).Column("EndDateTime");
			Map(x => x.DateClosed).Column("DateClosed");
			Map(x => x.Duration).Column("Duration");
			Map(x => x.LockResult).Column("LockResult");
			Map(x => x.CloseStatus).Column("CloseStatus");
			Map(x => x.InitLockEntity).Column("InitLockEntity");
			Map(x => x.SessionStart).Column("SessionStart");
			Map(x => x.UserEmployeeId).Column("UserEmployeeID");
			Map(x => x.LinkDispId).Column("LinkDispID");
			Map(x => x.LocationId).Column("LocationID");    
            this.MapAuditable();
        }
    }
}
