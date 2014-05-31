namespace SaG.Business.Models
{
    public class TouchKey : BaseEntity
    {
        public string TouchKeyId { get; set; }
        public Accessor Accessor { get; set; }
        public string TypeKey { get; set; }
        public int? BlockCount { get; set; }
        public bool Status { get; set; }
        public string LocationId { get; set; }
    }
}
