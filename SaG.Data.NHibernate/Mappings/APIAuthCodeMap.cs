using FluentNHibernate.Mapping;
using SaG.Business.Models;

namespace SaG.Data.NHibernate.Mappings
{
    public class APIAuthCodeMap : ClassMap<APIAuthCode>
    {
        public APIAuthCodeMap()
        {
            Table("APIAuthCodes");
            Not.LazyLoad();
            this.MapIdentifiable();
            References(x => x.Client).Column("ClientId").Not.Nullable();
            Map(x => x.AuthCode).Column("AuthCode").Not.Nullable();
            References(x => x.Operator).Column("AccessorID").Not.Nullable();
            Map(x => x.IssuedOn).Column("IssuedOn").Not.Nullable();
            Map(x => x.ExpiresOn).Column("ExpiresOn").Not.Nullable();
            Map(x => x.Tokenized).Column("IsTokenized").Not.Nullable();
            Map(x => x.IsExpired).Column("IsExpired").Not.Nullable();
            this.MapAuditable();
        }
    }
}
