namespace SaG.Business.Models
{

    public class PendAuditStatus : BaseEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
