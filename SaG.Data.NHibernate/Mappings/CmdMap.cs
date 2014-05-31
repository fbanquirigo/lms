using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class CmdMap : ClassMap<Cmd> {
        
        public CmdMap() {
			Table("tblCmds");
            Not.LazyLoad();
			Id(x => x.CmdId).GeneratedBy.Identity().Column("CmdID");
			References(x => x.Level).Column("Level");
			Map(x => x.CmdHex).Column("CmdHex");
			Map(x => x.Description).Column("Description");
			Map(x => x.CmdSeqNo).Column("CmdSeqNo");
			Map(x => x.CmdSeqHex).Column("CmdSeqHex");
            this.MapAuditable();
        }
    }
}
