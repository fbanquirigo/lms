using System;
using StructureMapContainer = StructureMap.IContainer;

namespace SaG.Core.StructureMap
{
    public class ContainerConfigurationExpression : IContainerConfigurationExpression
    {
        private readonly StructureMapContainer container;

        public ContainerConfigurationExpression(StructureMapContainer container)
        {
            this.container = container;
        }

        public ICreatePluginExpression For<TPluginType>()
        {
            return For(typeof (TPluginType));
        }

        public ICreatePluginExpression For(Type pluginType)
        {
            return new CreatePluginExpression(pluginType, this.container, PluginInstanceType.Instance);
        }

        public ICreatePluginExpression ForSingleton<TPluginType>()
        {
            return ForSingleton(typeof(TPluginType));
        }

        public ICreatePluginExpression ForSingleton(Type pluginType)
        {
            return new CreatePluginExpression(pluginType, this.container, PluginInstanceType.Singleton);
        }

        public ICreatePluginExpression ForHttpContextScoped<TPluginType>()
        {
            return ForHttpContextScoped(typeof(TPluginType));
        }

        public ICreatePluginExpression ForHttpContextScoped(Type pluginType)
        {
            return new CreatePluginExpression(pluginType, this.container, PluginInstanceType.HttpContext);
        }

        public ICreatePluginExpression ForHybridHttpOrThreadLocalScoped<TPluginType>()
        {
            return ForHybridHttpOrThreadLocalScoped(typeof(TPluginType));
        }

        public ICreatePluginExpression ForHybridHttpOrThreadLocalScoped(Type pluginType)
        {
            return new CreatePluginExpression(pluginType, this.container, PluginInstanceType.HybridHttpOrThreadLocal);
        }   
    }
}
