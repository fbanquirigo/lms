using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SaG.Core;

namespace SaG.API
{
    /// <summary>
    /// Dependency Resolver
    /// </summary>
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IContainer container;

        /// <summary>
        /// Creates a new instance of DependencyResolver.
        /// </summary>
        /// <param name="container"></param>
        public DependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsInterface || serviceType.IsAbstract)
            {
                return GetInterfaceService(serviceType);
            }
            return GetConcreteService(serviceType);
        }

        private object GetConcreteService(Type serviceType)
        {
            try
            {
                return this.container.GetInstance(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private object GetInterfaceService(Type serviceType)
        {
            return this.container.TryGetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.GetAllInstances(serviceType);
        }
    }
}