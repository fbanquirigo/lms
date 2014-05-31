using System;
using SaG.Business.Models;

namespace SaG.Business
{
    public static class ExpirableExtensions
    {
        public static bool IsExpired(this IExpirable expirable)
        {
            return DateTime.UtcNow >= expirable.ExpiresOn || expirable.IsExpired;
        }
    }
}
