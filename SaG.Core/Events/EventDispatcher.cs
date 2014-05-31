using System;
using System.Collections.Generic;

namespace SaG.Core.Events
{
    public sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IContainer container;

        public EventDispatcher(IContainer container)
        {
            if(container == null)
                throw new ArgumentNullException("container");
            this.container = container;
        }

        public void RaiseEvent(string eventName, object sender, EventArgs e)
        {
            IEnumerable<IEventSubscriber> subcribers = this.container.GetAllInstances<IEventSubscriber>();
            foreach (var subscriber in subcribers)
            {
                subscriber.Invoke(eventName, sender, e);    
            }
        }

        public void RaiseEvent<TEventArgs>(string eventName, object sender, TEventArgs e)
        {
            IEnumerable<IEventSubscriber> subcribers = this.container.GetAllInstances<IEventSubscriber>();
            foreach (var subscriber in subcribers)
            {
                subscriber.Invoke(eventName, sender, e);    
            }
        }
    }
}
