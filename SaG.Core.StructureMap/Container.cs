using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap.Pipeline;
using StructureMapContainer = StructureMap.IContainer;

namespace SaG.Core.StructureMap
{
    public class Container : IContainer
    {
        private readonly StructureMapContainer container;
        private readonly IContainerContext configurationContext;

        public Container(StructureMapContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            this.container = container;
            this.configurationContext = new ContainerContext(this.container, this);
        }

        public IEnumerable<TType> GetAllInstances<TType>()
        {
            return this.container.GetAllInstances<TType>();
        }

        public IEnumerable<object> GetAllInstances(Type pluginType)
        {
            if (pluginType == null)
                throw new ArgumentNullException("pluginType");
            return this.container.GetAllInstances(pluginType).Cast<object>().ToList();
        }

        public object GetInstance(Type pluginType)
        {
            if (pluginType == null)
                throw new ArgumentNullException("pluginType");
            return this.container.GetInstance(pluginType);
        }

        public TType GetInstance<TType>()
        {
            return this.container.GetInstance<TType>();
        }    

        public object GetInstance(Type pluginType, Dictionary<string, object> arguments)
        {
            return this.container.GetInstance(pluginType, new ExplicitArguments(arguments));
        }

        public TType GetInstance<TType>(Dictionary<string, object> arguments)
        {
            return this.container.GetInstance<TType>(new ExplicitArguments(arguments));
        }

        public object TryGetInstance(Type pluginType)
        {
            if (pluginType == null)
                throw new ArgumentNullException("pluginType");
            return this.container.TryGetInstance(pluginType);
        }

        public TType TryGetInstance<TType>()
        {
            return this.container.TryGetInstance<TType>();
        }

        public void Initialize(Action<IContainerContext> context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.Invoke(this.configurationContext);
        }

        public void Configure(Action<IContainerConfigurationExpression> config)
        {
            config.Invoke(new ContainerConfigurationExpression(this.container));
        }


        public void Release(object instance)
        {
            if (!(instance is IDisposable))
                return;

            (instance as IDisposable).Dispose();
        }
    }
}
