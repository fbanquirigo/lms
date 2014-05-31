using System;

namespace SaG.Business.Models {
    
    public class Alarm : BaseEntity {
        public int AlarmId { get; set; }
        public DateTime DateRecorded { get; set; }
        public string AlarmType { get; set; }
        public string AlarmKey { get; set; }
        public string AlarmDesc { get; set; }
        public bool AcknowledgedFlag { get; set; }
        public DateTime? DateAcknowledged { get; set; }
        public string OperatorName { get; set; }
    }
}
