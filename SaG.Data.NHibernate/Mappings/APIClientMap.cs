using FluentNHibernate.Mapping;
using SaG.Business.Models;

namespace SaG.Data.NHibernate.Mappings
{
    public class APIClientMap : ClassMap<APIClient>
    {
        public APIClientMap()
        {
            Table("APIClients");
            Not.LazyLoad();
            this.MapIdentifiable();
            Map(x => x.ConsumerKey).Column("ConsumerKey").Not.Nullable();
            Map(x => x.ConsumerSecret).Column("ConsumerSecret").Not.Nullable();
            Map(x => x.Domain).Column("Domain").Nullable();
            Map(x => x.Suspended).Column("Suspended").Not.Nullable();
            this.MapAuditable();  
        }
    }
}
