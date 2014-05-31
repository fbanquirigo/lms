namespace SaG.Business.Models {
    
    public class LinkOperID : BaseEntity {
        public string DispId { get; set; }
        public string Password { get; set; }
        public int? Priority { get; set; }
        public string Description { get; set; }
        public bool? Enable { get; set; }
        public string LocationId { get; set; }
        public string LogOn { get; set; }
    }
}
