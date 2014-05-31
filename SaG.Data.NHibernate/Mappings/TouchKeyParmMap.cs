using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class TouchKeyParmMap : ClassMap<TouchKeyParm> {
        
        public TouchKeyParmMap() {
			Table("tblTouchKeyParms");
            Not.LazyLoad();
			CompositeId().KeyProperty(x => x.DispEntity, "DispEntity")
			             .KeyProperty(x => x.TouchKeyId, "TouchKeyID")
			             .KeyProperty(x => x.CmdId, "CmdID");
			Map(x => x.BankModeStatus).Column("BankModeStatus");
			Map(x => x.AuditStatus).Column("AuditStatus");
			Map(x => x.TampResetStatus).Column("TampResetStatus");
			Map(x => x.TimeStartBankAccess).Column("TimeStartBankAccess");
			Map(x => x.TimeEndBankAccess).Column("TimeEndBankAccess");
			Map(x => x.EraseCodes).Column("EraseCodes").Not.Nullable();
			Map(x => x.NewPcCode).Column("NewPCCode");
			Map(x => x.NewOcCode).Column("NewOCCode");
			Map(x => x.TimeStartSetClock).Column("TimeStartSetClock");
			Map(x => x.SequenceNum).Column("SequenceNum");
			Map(x => x.AddRevDispEntity).Column("AddRevDispEntity");
            this.MapAuditable();
        }
    }
}
