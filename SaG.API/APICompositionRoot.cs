using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using IContainer = SaG.Core.IContainer;

namespace SaG.API
{
    /// <summary>
    /// API Controller Activator
    /// </summary>
    public class APICompositionRoot : IHttpControllerActivator
    {
        private readonly IContainer container;

        /// <summary>
        /// Creates a new instance of APICompositionRoot
        /// </summary>
        public APICompositionRoot(IContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController) this.container.GetInstance(controllerType);
            request.RegisterForDispose(
                new Release(this.container.Release, controller));

            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action<object> release;
            private readonly IHttpController controller;

            public Release(Action<object> release, IHttpController controller)
            {
                this.release = release;
                this.controller = controller;
            }

            public void Dispose()
            {
                this.release(this.controller);
            }
        }
    }
}