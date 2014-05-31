namespace SaG.Business.Models {
    
    public class ExceptionLimit : BaseEntity {
        public int ExceptionId { get; set; }
        public string LimitType { get; set; }
        public int LimitValue { get; set; }
    }
}
