using SaG.Core;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace SaG.API
{
    public class BootstrapperConfig
    {
        public static void Boot()
        {  
            ObjectFactory.Initialize(x => x.AddRegistry<BootStrapperRegistry>());
            var bootStrapper = ObjectFactory.Container.GetInstance<IBootStrapper>();
            bootStrapper.BootStrap();
        }

        public static void CleanUp()
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }
    }

    sealed class BootStrapperRegistry : Registry
    {
        public BootStrapperRegistry()
        {
            For<Core.IContainer>().Singleton().Use<Core.StructureMap.Container>();
            For<IBootStrapper>().Use<BootStrapper>();
            For<IContainerInitializer>().Add<StructureMapBootstrapper>();
        }
    }
}