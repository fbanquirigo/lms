using FluentNHibernate.Mapping;
using SaG.Business.Models;

namespace SaG.Data.NHibernate.Mappings
{
    public class APIAccessTokenMap : ClassMap<APIAccessToken>
    {
        public APIAccessTokenMap()
        {
            Table("APIAccessTokens");
            Not.LazyLoad();
            this.MapIdentifiable();
            References(x => x.Client).Column("ClientId").Not.Nullable();
            References(x => x.AuthCode).Column("AuthCodeId").Not.Nullable();
            References(x => x.Operator).Column("AccessorID").Not.Nullable();
            Map(x => x.AccessToken).Column("AccessToken").Not.Nullable();
            Map(x => x.IssuedOn).Column("IssuedOn").Not.Nullable();
            Map(x => x.ExpiresOn).Column("ExpiresOn").Not.Nullable();
            Map(x => x.LastUsedOn).Column("LastUsedOn").Nullable();
            Map(x => x.IsExpired).Column("IsExpired").Not.Nullable();
            this.MapAuditable();
        }
    }
}
