using SaG.API.Areas.HelpPage;
using SaG.API.Validators;
using StructureMap.Graph;
using SaG.Core;
using SaG.Core.StructureMap;
using IContainer = StructureMap.IContainer;
using SaG.Core.Events;
using WebGrease.Css.Extensions;

namespace SaG.API
{
    public class StructureMapBootstrapper : IContainerInitializer
    {
        public void Initialize(IContainerContext context)
        {
            if (!(context is ContainerContext))
                return;

            IContainer container = (context as ContainerContext).StructureMapContainer;

            container.Configure(c =>
                c.Scan(scanner =>
                {
                    var assemblies = new[]
                        {
                            "SaG.Core", 
                            "SaG.Core.StructureMap",
                            "SaG.Core.Log4Net",
                            "SaG.Encrypt",
                            "SaG.Business", 
                            "SaG.Data",
                            "SaG.Data.Migrations",
                            "SaG.Data.NHibernate",
                            "SaG.Services", 
                            "SaG.API"
                        };
                    scanner.TheCallingAssembly();
                    assemblies.ForEach(scanner.Assembly);
                    scanner.WithDefaultConventions();
                    RegisterApplicationHandlerTypes(scanner);
                }));

            ServiceLocator.SetContainer(context.Container);
        }

        private static void RegisterApplicationHandlerTypes(IAssemblyScanner scanner)
        {
            scanner.AddAllTypesOf<IInitializer>();
            scanner.AddAllTypesOf<IEventSubscriber>();
            scanner.AddAllTypesOf<IContainerConfigurator>();
            scanner.AddAllTypesOf(typeof(IModelValidator<>));
            scanner.AddAllTypesOf<IApiDocumenter>();
        }
    }
}