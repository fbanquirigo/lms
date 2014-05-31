using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class LevelMap : ClassMap<Level> {
        
        public LevelMap() {
			Table("tblLevel");
            Not.LazyLoad();
			Id(x => x.Name).GeneratedBy.Assigned().Column("Level");
			Map(x => x.Description).Column("Description");
            this.MapAuditable();
        }
    }
}
