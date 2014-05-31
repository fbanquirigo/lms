using System;

namespace SaG.Business.Models {
    
    public class Lock : BaseEntity {
        public int LockEntity { get; set; }
        public Owner Owner { get; set; }
        public string LockId { get; set; }
        public string KeyLockOwner0 { get; set; }
        public string KeyLockOwner1 { get; set; }
        public string BankModeStatus { get; set; }
        public DateTime? BankModeStart { get; set; }
        public DateTime? BankModeEnd { get; set; }
        public string TampResetStatus { get; set; }
        public string AuditStatus { get; set; }
        public bool LockInitialize { get; set; }
        public int? PCcode { get; set; }
        public int? OCcode { get; set; }
        public bool ErasePcoc { get; set; }
        public string PendBankModeStatus { get; set; }
        public DateTime? PendBankModeStart { get; set; }
        public DateTime? PendBankModeEnd { get; set; }
        public string PendTampResetStatus { get; set; }
        public string PendAuditStatus { get; set; }
        public bool PendLockInitialize { get; set; }
        public bool PendLockUnInstall { get; set; }
        public int? PendPCcode { get; set; }
        public int? PendOCcode { get; set; }
        public bool PendErasePcoc { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool ChangeStatus { get; set; }
        public short? SetClockCalSeqNo { get; set; }
        public string LocationId { get; set; }
    }
}
