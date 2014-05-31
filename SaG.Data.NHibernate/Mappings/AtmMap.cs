using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class AtmMap : ClassMap<Atm> {
        
        public AtmMap() {
			Table("tblATMs");
            Not.LazyLoad();
			Id(x => x.AtmEntity).GeneratedBy.Identity().Column("AtmEntity");
			References(x => x.Owner).Column("OwnerEntity");
			References(x => x.Lock).Column("LockEntity");
			Map(x => x.AtmId).Column("AtmID");
			Map(x => x.TermSerialNo).Column("TermSerialNo");
			Map(x => x.SiteName).Column("SiteName");
			Map(x => x.SiteAddress).Column("SiteAddress");
			Map(x => x.SiteNo).Column("SiteNo");
			Map(x => x.PhoneNo).Column("PhoneNo");
			Map(x => x.MfgModel).Column("MfgModel");
			Map(x => x.ContactName).Column("ContactName");
			Map(x => x.TypeService).Column("TypeService");
			Map(x => x.UserDefined1).Column("UserDefined1");
			Map(x => x.UserDefined2).Column("UserDefined2");
			Map(x => x.TimeOffset).Column("TimeOffset");
			Map(x => x.Status).Column("Status").Not.Nullable();
			Map(x => x.DaylightSavingsObserved).Column("DaylightSavingsObserved").Not.Nullable();
			Map(x => x.PrevAtmid).Column("PrevATMID");
			Map(x => x.AtmidChgDate).Column("ATMIDChgDate");
			Map(x => x.LocationId).Column("LocationID");
			Map(x => x.AtmTimeZone).Column("AtmTimeZone").Not.Nullable();
            this.MapAuditable();
        }
    }
}
