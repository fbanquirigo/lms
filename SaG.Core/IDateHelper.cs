using System;

namespace SaG.Core
{
    public interface IDateHelper
    {
        DateTime GetIssuedDate();

        DateTime GetExpirationDate(DateTime issuedDate, int minutes);
    }
}