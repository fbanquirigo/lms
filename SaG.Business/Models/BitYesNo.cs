namespace SaG.Business.Models {
    
    public class BitYesNo : BaseEntity {
        public int Id { get; set; }
        public bool? Bit { get; set; }
        public string Description { get; set; }
    }
}
