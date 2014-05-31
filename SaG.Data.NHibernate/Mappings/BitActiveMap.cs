using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class BitActiveMap : ClassMap<BitActive> {
        
        public BitActiveMap() {
			Table("tblBitActive");
            Not.LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id");
			Map(x => x.Status).Column("Status");
			Map(x => x.Description).Column("Description");
            this.MapAuditable();
        }
    }
}
