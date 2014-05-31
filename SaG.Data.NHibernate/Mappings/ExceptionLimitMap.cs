using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class ExceptionLimitMap : ClassMap<ExceptionLimit> {
        
        public ExceptionLimitMap() {
			Table("tblExceptionLimit");
            Not.LazyLoad();
			Id(x => x.ExceptionId).GeneratedBy.Identity().Column("ExceptionID");
			Map(x => x.LimitType).Column("LimitType");
			Map(x => x.LimitValue).Column("LimitValue").Not.Nullable();
            this.MapAuditable();
        }
    }
}
