using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class BankOperDescMap : ClassMap<BankOperDesc> {
        
        public BankOperDescMap() {
			Table("tblBankOperDescs");
            Not.LazyLoad();
			Id(x => x.BankOperId).GeneratedBy.Assigned().Column("BankOperID");
			Map(x => x.Description).Column("Description");
            this.MapAuditable();
        }
    }
}
