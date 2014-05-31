using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class TouchKeyPoMap : ClassMap<TouchKeyPos> {
        
        public TouchKeyPoMap() {
			Table("tblTouchKeyPos");
            Not.LazyLoad();
			CompositeId().KeyProperty(x => x.TouchKeyId, "TouchKeyID")
			             .KeyProperty(x => x.PositionNo, "PositionNo");
			References(x => x.Dispatcher).Column("DispEntity");
			References(x => x.TouchKey).Column("TouchKeyID");
			References(x => x.CmdId0).Column("CmdID0");
			References(x => x.CmdId1).Column("CmdID1");
			References(x => x.CmdId2).Column("CmdID2");
			References(x => x.CmdId3).Column("CmdID3");
            this.MapAuditable();
        }
    }
}
