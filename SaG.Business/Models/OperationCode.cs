using System;


namespace SaG.Business.Models {
    
    public class OperationCode : BaseEntity {
        public int OpCodeEntity { get; set; }
        public Atm Atm { get; set; }
        public Cmd Cmd { get; set; }
        public TouchKey TouchKey { get; set; }
        public RouteDesc RouteDesc { get; set; }
        public Accessor OpCodeRecipient { get; set; }
        public Accessor OpCodeCreator { get; set; }
        public string UserType { get; set; }
        public int? Code { get; set; }
        public DateTime? DateAssigned { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime? DateClosed { get; set; }
        public short? Duration { get; set; }
        public string LockResult { get; set; }
        public string CloseStatus { get; set; }
        public int? InitLockEntity { get; set; }
        public DateTime? SessionStart { get; set; }
        public string UserEmployeeId { get; set; }
        public string LinkDispId { get; set; }
        public string LocationId { get; set; }
    }
}
