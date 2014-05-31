using System;
using StructureMapContainer = StructureMap.IContainer;

namespace SaG.Core.StructureMap
{
    public class CreatePluginExpression : ICreatePluginExpression
    {
        private readonly Type pluginType;
        private readonly StructureMapContainer container;
        private readonly PluginInstanceType pluginInstanceType;

        public CreatePluginExpression(Type pluginType, 
            StructureMapContainer container, PluginInstanceType pluginInstanceType)
        {
            this.pluginType = pluginType;
            this.container = container;
            this.pluginInstanceType = pluginInstanceType;
        }

        public void Use<TConcreteType>()
        {
            Use(typeof(TConcreteType));
        }

        public void Use(Type concreteType)
        {
            switch (this.pluginInstanceType)
            {
                case PluginInstanceType.Instance:
                    this.container.Configure(c => c.For(this.pluginType).Use(concreteType));
                    break;
                case PluginInstanceType.Singleton:  
                    this.container.Configure(c => c.For(this.pluginType).Singleton().Use(concreteType));
                    break;
                case PluginInstanceType.HttpContext:
                    this.container.Configure(c => c.For(this.pluginType).HttpContextScoped().Use(concreteType));
                    break;
                case PluginInstanceType.HybridHttpOrThreadLocal:
                    this.container.Configure(c => c.For(this.pluginType).HybridHttpOrThreadLocalScoped().Use(concreteType));
                    break;
            }
        }

        public void Use(object instance)
        {
            switch (this.pluginInstanceType)
            {
                case PluginInstanceType.Instance:
                    this.container.Configure(c => c.For(this.pluginType).Use(instance));
                    break;
                case PluginInstanceType.Singleton:
                    this.container.Configure(c => c.For(this.pluginType).Singleton().Use(instance));
                    break;
                case PluginInstanceType.HttpContext:
                    this.container.Configure(c => c.For(this.pluginType).HttpContextScoped().Use(instance));
                    break;
                case PluginInstanceType.HybridHttpOrThreadLocal:
                    this.container.Configure(c => c.For(this.pluginType).HybridHttpOrThreadLocalScoped().Use(instance));
                    break;
            } 
        }  

        public void Add<TConreteType>()
        {
            Add(typeof(TConreteType));    
        }

        public void Add(Type conreteType)
        {
            this.container.Configure(c => c.For(this.pluginType).Add(conreteType));
        }       

        public void Add(object instance)
        {
            this.container.Configure(c => c.For(this.pluginType).Add(instance));
        }
    }
}
