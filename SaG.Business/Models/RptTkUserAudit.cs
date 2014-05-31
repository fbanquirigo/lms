namespace SaG.Business.Models
{    
    public class RptTkUserAudit : BaseEntity
    {
        public int AuditId { get; set; }
        public string AtmId { get; set; }
        public string SiteName { get; set; }
        public string LockId { get; set; }
        public string Operation { get; set; }
        public string Result { get; set; }
        public string UploadDate { get; set; }
        public string Duration { get; set; }
    }
}
