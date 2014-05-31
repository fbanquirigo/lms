using System.Reflection;
using FluentNHibernate.Cfg;

namespace SaG.Data.NHibernate
{
    public class MappingConfig
    {
        public void Configure(MappingConfiguration config)
        {
            Assembly mapAssembly = Assembly.GetAssembly(typeof (SessionManager));
            config.FluentMappings.AddFromAssembly(mapAssembly);
        }
    }
}
