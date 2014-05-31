using System;

namespace SaG.Business.Models
{     
    public class Transaction : BaseEntity
    {
        public int EventId { get; set; }
        public Operator Operator { get; set; }
        public string EventType { get; set; }
        public int? TransCode { get; set; }
        public int? RetCode { get; set; }
        public DateTime? Posted { get; set; }
        public int? ReqCount { get; set; }
        public string DispId { get; set; }
        public string LockId { get; set; }
        public string AtmId { get; set; }
        public string UserId { get; set; }
        public string RouteId { get; set; }
        public string TkId { get; set; }
        public string OperDate { get; set; }
        public string OperHour { get; set; }
        public string OperHourLimit { get; set; }
        public string LockStat { get; set; }
        public string StatusRet { get; set; }
        public string OperCode { get; set; }
        public string OperRet { get; set; }
        public string OperResult { get; set; }
        public string Description { get; set; }
    }
}
