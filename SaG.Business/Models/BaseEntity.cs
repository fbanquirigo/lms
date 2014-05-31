using System;
using SaG.Core.Security;

namespace SaG.Business.Models
{
    public class BaseEntity : IAuditable
    {
        public virtual DateTime? DateCreated { get; set; }

        public virtual ISystemUser UserCreated { get; set; }

        public virtual DateTime? DateModified { get; set; }

        public virtual ISystemUser UserModified { get; set; }
    }
}
