using System;
using SaG.Core.Security;

namespace SaG.Business
{
    public interface IAuditable
    {
        DateTime? DateCreated { get; set; }

        ISystemUser UserCreated { get; set; }

        DateTime? DateModified { get; set; }

        ISystemUser UserModified { get; set; }
    }  
}