using System;
using SaG.Business.Models;
using SaG.Data;

namespace SaG.Services
{
    public class SystemContext : ISystemContext
    {
        private readonly AppSystem system;
        private readonly TimeZoneInfo timeZoneInfo;
        private readonly string locationId;

        public SystemContext(IRepository<AppSystem> systemRepository)
        {
            this.system = systemRepository.GetById(1);
            const string defaultTimeZone = "Eastern Standard Time";
            this.timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(defaultTimeZone);


            if (!string.IsNullOrEmpty(this.system.APITimeZone))
            {
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(this.system.APITimeZone);
                if (tz != null)
                    this.timeZoneInfo = tz;
            }

            this.locationId = this.system.Location;
        }

        public bool SouthernHemisphere
        {
            get { return this.system.SouthernHemisphere ?? false; }
        }

        public TimeZoneInfo SystemTimeZone
        {
            get { return this.timeZoneInfo; }
        }  

        public string LocationId
        {
            get { return this.locationId; }
        }
    }
}
