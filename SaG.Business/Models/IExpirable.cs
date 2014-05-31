using System;

namespace SaG.Business.Models
{
    public interface IExpirable
    {
        DateTime ExpiresOn { get; }
        bool IsExpired { get; }
    }
}