using FluentNHibernate.Mapping;
using SaG.Business;
using SaG.Business.Models;

namespace SaG.Data.NHibernate.Mappings
{
    public static class Extensions
    {
        public static void MapAuditable<TEntity>(this ClassMap<TEntity> map)
            where TEntity : IAuditable
        {
            map.References<Operator>(x => x.UserCreated).Column("UserCreated").Nullable();
            map.Map(x => x.DateCreated).Column("DateCreated").Nullable();
            map.References<Operator>(x => x.UserModified).Column("UserModified").Nullable();
            map.Map(x => x.DateModified).Column("DateModified").Nullable();
        }

        public static void MapIdentifiable<TEntity>(this ClassMap<TEntity> map)
            where TEntity : IIdentifiable
        {
            map.Id(x => x.Id).Access.CamelCaseField().Column("Id");
        }
    }
}
