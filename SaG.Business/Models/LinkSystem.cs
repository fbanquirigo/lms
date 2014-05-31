namespace SaG.Business.Models {
    
    public class LinkSystem : BaseEntity {
        public int Id { get; set; }
        public int? PollingTime { get; set; }
        public string PathTransDir { get; set; }
        public bool? RecordTransactions { get; set; }
        public bool? Encrypt { get; set; }
        public string SendExtension { get; set; }
        public string ReceiveExtension { get; set; }
    }
}
