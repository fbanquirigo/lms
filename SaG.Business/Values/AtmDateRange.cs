using System;

namespace SaG.Business.Values
{
    public class AtmDateRange
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool InRange(DateTime dateTime)
        {
            return dateTime >= StartDate && dateTime < EndDate;
        }
    }
}
