using System;
using System.Collections.Generic;

namespace SaG.Core
{
    public sealed class ServiceLocator
    {
        private readonly IContainer container;
        private static IContainer Container { get; set; }
        private static ServiceLocator serviceLocator;

        public IEnumerable<TType> GetAllInstances<TType>()
        {
            return this.container.GetAllInstances<TType>();
        }

        public IEnumerable<Object> GetAllInstances(Type pluginType)
        {
            return this.container.GetAllInstances(pluginType);
        }

        public object GetInstance(Type pluginType)
        {
            return this.container.GetInstance(pluginType);
        }

        public TType GetInstance<TType>()
        {
            return this.container.GetInstance<TType>();
        }

        public object GetInstance(Type pluginType, Dictionary<string, object> arguments)
        {
            return this.container.GetInstance(pluginType, arguments);
        }

        public TType GetInstance<TType>(Dictionary<string, object> arguments)
        {
            return this.container.GetInstance<TType>(arguments);
        }

        private ServiceLocator(IContainer container)
        {
            if(container == null)
                throw new NullReferenceException();
            this.container = container;
        }

        public static void SetContainer(IContainer container)
        {
            if(container == null)
                throw new ArgumentException("container must be set to an instance object.");
            Container = container;
        }

        public static ServiceLocator Current
        {
            get
            {
                serviceLocator = serviceLocator ?? new ServiceLocator(Container);
                return serviceLocator;
            }
        }
    }
}
