using System;

namespace SaG.Business.Models {
    
    public class OpCodeAudit : BaseEntity {
        public int OpCodeEntity { get; set; }
        public DateTime? StartDtTime { get; set; }
        public DateTime? EndDtTime { get; set; }
        public string AtmId { get; set; }
        public string CmdDesc { get; set; }
        public string RouteId { get; set; }
        public string TouchKeyId { get; set; }
        public string UserType { get; set; }
        public string OperCode { get; set; }
        public short? Duration { get; set; }
        public string LockId { get; set; }
        public string LockResult { get; set; }
        public DateTime? SessStartDtTime { get; set; }
        public DateTime? DtTmClosed { get; set; }
        public string UserName { get; set; }
        public string OperName { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string UserEmployeeId { get; set; }
        public string LinkDispId { get; set; }
        public string LocationId { get; set; }
    }
}
