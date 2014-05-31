using System;
using System.Collections.Generic;
using System.Linq;

namespace SaG.Core.Events
{
    public abstract class EventSubscriber : IEventSubscriber
    {
        private Dictionary<string, HashSet<Delegate>> handlers;

        private Dictionary<string, HashSet<Delegate>> Handlers
        {
            get
            {
                this.handlers = this.handlers ?? new Dictionary<string, HashSet<Delegate>>();
                return this.handlers;
            }
        }   

        protected void HandleEvent(string eventName, EventHandler eventHandler)
        {
            if (!Handlers.ContainsKey(eventName))
            {
                var hashSet = new HashSet<Delegate>();
                Handlers.Add(eventName, hashSet);
            }

            if (Handlers[eventName].Contains(eventHandler))
                return;

            Handlers[eventName].Add(eventHandler);    
        }

        protected void HandleEvent<TEventArgs>(string eventName, EventHandler<TEventArgs> eventHandler)
        {
            if (!Handlers.ContainsKey(eventName))
            {
                var hashSet = new HashSet<Delegate>();
                Handlers.Add(eventName, hashSet);
            }

            if (Handlers[eventName].Contains(eventHandler))
                return;

            Handlers[eventName].Add(eventHandler);       
        }
           
        public void Invoke(string eventName, object sender, EventArgs e)
        {
            if (!Handlers.ContainsKey(eventName))
                return;

            foreach (var handler in Handlers[eventName]
                .Where(eventHandler => eventHandler is EventHandler)
                .Cast<EventHandler>())
            {
                handler.Invoke(sender, e);   
            }
        }

        public void Invoke<TEventArgs>(string eventName, object sender, TEventArgs e)
        {
            if (!Handlers.ContainsKey(eventName))
                return;

            foreach (var handler in Handlers[eventName]
                .Where(eventHandler => eventHandler is EventHandler<TEventArgs>)
                .Cast<EventHandler<TEventArgs>>())
            {
                handler.Invoke(sender, e);
            }
        }
    }
}
