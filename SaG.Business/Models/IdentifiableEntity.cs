using System;
using SaG.Core.Security;

namespace SaG.Business.Models
{
    public abstract class IdentifiableEntity : IIdentifiable, IAuditable
    {
        private int id;

        public virtual int Id
        {
            get { return this.id; }
        }

        public virtual DateTime? DateCreated { get; set; }

        public virtual ISystemUser UserCreated { get; set; }

        public virtual DateTime? DateModified { get; set; }

        public virtual ISystemUser UserModified { get; set; }
    }
}
