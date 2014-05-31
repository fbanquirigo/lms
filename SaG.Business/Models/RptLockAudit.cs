namespace SaG.Business.Models
{

    public class RptLockAudit : BaseEntity
    {
        public int AuditId { get; set; }
        public string User { get; set; }
        public string Operation { get; set; }
        public string Result { get; set; }
        public string UploadDate { get; set; }
        public string Duration { get; set; }
        public string KeyIdBankUser { get; set; }
        public string KeyType { get; set; }
        public string DispatcherId { get; set; }
    }
}
