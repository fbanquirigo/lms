namespace SaG.Business.Models {
    
    public class Accessor : BaseEntity {
        public int AccessorId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public string AccessorType { get; set; }
    }
}
