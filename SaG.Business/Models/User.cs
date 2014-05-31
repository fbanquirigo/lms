namespace SaG.Business.Models
{

    public class User : BaseEntity
    {
        public int AccessorId { get; set; }
        public Accessor Accessor { get; set; }
        public Level Level { get; set; }
        public string Location { get; set; }
        public string Pin { get; set; }
        public string GroupId { get; set; }
        public string PhoneNo { get; set; }
        public string PagerNo { get; set; }
        public string UserType { get; set; }
        public bool Status { get; set; }
        public string LocationId { get; set; }
    }
}
