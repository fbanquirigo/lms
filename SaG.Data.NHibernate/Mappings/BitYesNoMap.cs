using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class BitYesNoMap : ClassMap<BitYesNo> {
        
        public BitYesNoMap() {
			Table("tblBitYesNo");
            Not.LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id");
			Map(x => x.Bit).Column("Bit");
			Map(x => x.Description).Column("Description");
            this.MapAuditable();
        }
    }
}
