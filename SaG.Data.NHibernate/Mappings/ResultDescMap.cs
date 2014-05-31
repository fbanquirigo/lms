using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class ResultDescMap : ClassMap<ResultDesc> {
        
        public ResultDescMap() {
			Table("tblResultDescs");
            Not.LazyLoad();
			Id(x => x.ResultId).GeneratedBy.Assigned().Column("ResultID");
			Map(x => x.Description).Column("Description");
            this.MapAuditable();
        }
    }
}
