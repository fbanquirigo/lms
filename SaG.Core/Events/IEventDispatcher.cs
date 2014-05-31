  using System;

namespace SaG.Core.Events
{
    public interface IEventDispatcher
    {
        void RaiseEvent(string eventName, object sender, EventArgs e);

        void RaiseEvent<TEventArgs>(string eventName, object sender, TEventArgs e);
    }
}
