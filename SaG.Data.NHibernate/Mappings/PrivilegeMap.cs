using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class PrivilegeMap : ClassMap<Privilege> {
        
        public PrivilegeMap() {
			Table("tblPrivileges");
            Not.LazyLoad();
			CompositeId().KeyProperty(x => x.DispEntity, "DispEntity")
			             .KeyProperty(x => x.CmdId, "CmdID");
			References(x => x.Dispatcher).Column("DispEntity");
			References(x => x.Cmd).Column("CmdID");
            this.MapAuditable();
        }
    }
}
