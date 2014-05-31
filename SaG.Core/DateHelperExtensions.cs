using System;

namespace SaG.Core
{
    public static class DateHelperExtensions
    {
        public static DateTime GetExpirationDate(this IDateHelper helper, DateTime issuedDate)
        {
            return helper.GetExpirationDate(issuedDate, 30);
        }
    }
}
