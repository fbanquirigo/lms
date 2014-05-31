using System;

namespace SaG.Business.Models
{

    public class AppSystem : BaseEntity
    {
        public int SystemId { get; set; }
        public string ServerName { get; set; }
        public string BackupPath { get; set; }
        public bool? SouthernHemisphere { get; set; }
        public bool? Alarms { get; set; }
        public int? BankModeLimit { get; set; }
        public int TimeoutValue { get; set; }
        public int SystemTimeZone { get; set; }
        public string APITimeZone { get; set; }
        public DateTime DstStart { get; set; }
        public DateTime DstEnd { get; set; }
        public string Location { get; set; }
    }
}
