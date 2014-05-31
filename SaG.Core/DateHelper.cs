using System;

namespace SaG.Core
{
    public class DateHelper : IDateHelper
    {
        public DateTime GetIssuedDate()
        {
            return DateTime.UtcNow;
        }

        public DateTime GetExpirationDate(DateTime issuedDate, int minutes)
        {
            return issuedDate.AddMinutes(minutes);
        }
    }
}
