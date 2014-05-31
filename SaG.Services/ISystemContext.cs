using System;

namespace SaG.Services
{
    public interface ISystemContext
    {
        bool SouthernHemisphere { get; } 

        TimeZoneInfo SystemTimeZone { get; }

        string LocationId { get;  }
    }
}