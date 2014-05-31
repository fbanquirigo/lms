using FluentNHibernate.Mapping;
using SaG.Business.Models;

namespace SaG.Data.NHibernate.Mappings
{
    public class OperatorMap : ClassMap<Operator>
    {
        public OperatorMap()
        {
            Table("tblOperators");
            Not.LazyLoad();
            Id(x => x.AccessorId).Column("AccessorID");
            Map(x => x.Login).Column("Login");
            Map(x => x.Password).Column("Password");
            Map(x => x.PriorityLevel).Column("PriorityLevel");
            Map(x => x.LocationId).Column("LocationID");
            this.MapAuditable();
        }
    }
}
