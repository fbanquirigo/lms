using StructureMapContainer = StructureMap.IContainer;

namespace SaG.Core.StructureMap
{
    public class ContainerContext : IContainerContext
    {
        public StructureMapContainer StructureMapContainer { get; private set; }

        public IContainer Container { get; private set; }

        public ContainerContext(StructureMapContainer structureMapContainer, IContainer container)
        {
            StructureMapContainer = structureMapContainer;
            Container = container;
        }

        public static ContainerContext Cast(IContainerContext context)
        {
            return (context is ContainerContext)
                ? (ContainerContext) context
                : null;
        }     
    }
}
