using System;

namespace SaG.Core.Events
{
    public interface IEventSubscriber
    {
        void Invoke(string eventName, object sender, EventArgs e);

        void Invoke<TEventArgs>(string eventName, object sender, TEventArgs e);
    }
}
