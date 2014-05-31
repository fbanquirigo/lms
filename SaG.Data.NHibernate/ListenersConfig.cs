using NHibernate.Cfg;
using NHibernate.Event;

namespace SaG.Data.NHibernate
{
    public class ListenersConfig
    {
        private readonly IPreUpdateEventListener preUpdateEventListener;
        private readonly IPreInsertEventListener preInsertEventListener;

        public ListenersConfig(IPreUpdateEventListener preUpdateEventListener,
            IPreInsertEventListener preInsertEventListener)
        {
            this.preUpdateEventListener = preUpdateEventListener;
            this.preInsertEventListener = preInsertEventListener;
        }

        public void Configure(Configuration config)
        {     
            config.EventListeners.PreUpdateEventListeners = new[] { this.preUpdateEventListener };
            config.EventListeners.PreInsertEventListeners = new[] { this.preInsertEventListener };
        }
    }
}
