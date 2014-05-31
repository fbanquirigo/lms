using FluentNHibernate.Mapping;
using SaG.Business.Models;

namespace SaG.Data.NHibernate.Mappings
{
    public class ErrorLogMap : ClassMap<ErrorLog>
    {
        public ErrorLogMap()
        {
            Table("ErrorLogs");
            Not.LazyLoad();
            this.MapIdentifiable();
            Map(x => x.ErrorId).Column("ErrorId").Not.Nullable();
            Map(x => x.DateOccured).Column("DateOccured").Not.Nullable();
            Map(x => x.ConsumerKey).Column("ConsumerKey").Nullable();
            Map(x => x.User).Column("UserAccount").Nullable();
            Map(x => x.Request).Column("Request").Nullable();
            Map(x => x.Exception).Column("Exception").Nullable();
            this.MapAuditable();
        }
    }
}