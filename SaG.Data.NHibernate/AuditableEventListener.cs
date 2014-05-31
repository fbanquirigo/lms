using System;
using NHibernate.Event;
using SaG.Business;
using SaG.Core.Security;

namespace SaG.Data.NHibernate
{
    public class AuditableEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        private readonly ISecurityContextFactory contextFactory;

        public AuditableEventListener(ISecurityContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public bool OnPreInsert(PreInsertEvent eventItem)
        {
            ISecurityContext context = this.contextFactory.CreateContext();
            if (context == null)
                return false;

            var auditable = eventItem.Entity as IAuditable;
            if (auditable == null)
                return false;

            if (context.User != null)
                auditable.UserCreated = context.User;
            auditable.DateCreated = DateTime.Now;
            return false;
        }

        public bool OnPreUpdate(PreUpdateEvent eventItem)
        {
            ISecurityContext context = this.contextFactory.CreateContext();
            if (context == null)
                return false;

            var auditable = eventItem.Entity as IAuditable;
            if (auditable == null)
                return false;
            if (context.User != null)
                auditable.UserModified = context.User;
            auditable.DateModified = DateTime.Now;
            return false;
        }
    }
}
