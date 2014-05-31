namespace SaG.Business.Models {
    
    public class BitActive : BaseEntity {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public string Description { get; set; }
    }
}
